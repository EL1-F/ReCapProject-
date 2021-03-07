using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService

    {
        ICarImageDal _imageDal;

        public CarImageManager(ICarImageDal imageDal)
        {
            _imageDal = imageDal;

        }


        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckUploadedImagesLimit(carImage.CarId));

            if (result != null)
            {
                return result;
            }

            var addedCarImage = CreatedFile(file,carImage).Data;
            _imageDal.Add(carImage);
            return new SuccessResult();
        }

        public IResult Delete(int id)
        {
            var deleted = _imageDal.Get(i => i.ImageId == id);
            File.Delete(deleted.ImagePath);  //görüntünün adresini siliyoruz
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(i => i.CarId == carId));
        }


        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file,CarImage carImage)
        {
            var carImageUpdate = UpdatedFile(file,carImage);
            _imageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_imageDal.Get(i => i.ImageId == id));
        }





        private IDataResult<CarImage> CreatedFile(IFormFile file,CarImage carImage)
        {
            var sourcepath = Path.GetTempFileName(); //geçici bir dosya yolu oluşturuyoruz sonradan atayabilmek için

            if (file.Length > 0)
            {//File Stream yapısı, doküman, resim, video vb. objeleri File system üzerinde file stream dosyaları oluşturur ve bu dosyaları veritabanının bir parçası yapar.
                using (var stream = new FileStream(sourcepath, FileMode.Create)) //FileMode.Create seçeneği ile yeni bir dosya oluşturulur, aynı dosya varsa üzerine yazılır.
                {
                    file.CopyTo(stream);
                }
            }

            FileInfo fi = new FileInfo(file.FileName); //dosya bilgisi istiyoruz
            string fileExtension = fi.Extension;//uzantısını alıyoruz
            

            var creatingUniqueFilename = Guid.NewGuid().ToString("N").ToUpper()
                                                               // N tiresiz 32 basamaklı onaltılık sayı sisteminde id oluştur demek>> örn:123E4567E89B12D3A456426655440000>> toUpper olduğu için harfler büyük
                                                               // D tireli  >> örn:123E4567E-89B-12D3-A456-426655440000 şeklinde olurdu.
                + "_" + DateTime.Now.Month          
                + "_" + DateTime.Now.Day 
                + "_" + DateTime.Now.Year   //id sonuna oluşturduğumuz tarihi ve dosya uzantısını atıyoruz 
                + fileExtension;

            //string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");
            //bir üst klasörün adresi ve görüntünün kayıtlı olduğu olduğu adresi getiriyoruz combine ile tek bir adres haline getiriyoruz
            //bu şekilde yapıldığında Solution altında Images adında klasöre giden adres oluşturuyoruz

            string path = Environment.CurrentDirectory + @"\Images\carImages"; //api altında dosya açtırıyoruz
            string result = $@"{path}\{creatingUniqueFilename}";

            File.Move(sourcepath, result); //dosyayı kaynaktan hedefe taşıma işlemi yapıyoruz

            carImage.ImagePath = result;
            carImage.Date = DateTime.Now;

            return new SuccessDataResult<CarImage>(carImage, Messages.ImagesAdded);
            //oluşturulan objeyi(CarImage) döndürüyoruz
        }



        private IDataResult<CarImage> UpdatedFile(IFormFile file, CarImage carImage)
        {
            FileInfo fi = new FileInfo(file.FileName); 
            string fileExtension = fi.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString("N").ToUpper()
                + "_" + DateTime.Now.Month
                + "_" + DateTime.Now.Day
                + "_" + DateTime.Now.Year   
                + fileExtension;

            string path = Environment.CurrentDirectory + @"\Images\carImages"; 
            string result = $@"{path}\{creatingUniqueFilename}";

            if (carImage.ImagePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(carImage.ImagePath);

            carImage.ImagePath = result;
            carImage.Date = DateTime.Now;

            return new SuccessDataResult<CarImage>(carImage);
            //güncelleme yapıp yeni CarImage döndürüyoruz
        }


        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"\Images\logo.jpg";
            //default yani görüntü yüklenmediğinde Images klasörü altındaki default isimli görüntüyü verecek olan adresi girdik

            var result = _imageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _imageDal.GetAll(p => p.CarId == id);
        }


        private IResult CheckUploadedImagesLimit(int carId)
        {
            var carImagecount = _imageDal.GetAll(p => p.CarId == carId).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.ImageUploadLimitOver);
            }

            return new SuccessResult();
        }

        
    }
}
