using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.FileHelper;
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


        //[CacheRemoveAspect("ICarImageService.Get")]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(
                CheckUploadedImagesLimit(carImage.CarId)
                );

            if (result != null)
            {
                return result;
            }

            carImage.ImagePath = FileHelper.AddAsync(file);
            _imageDal.Add(carImage);
            return new SuccessResult();
        }


        public IResult Delete(CarImage carImage)
        {
            var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_imageDal.Get(p => p.ImageId == carImage.ImageId).ImagePath}";
            FileHelper.DeleteAsync(oldpath);

            _imageDal.Delete(carImage);
            return new SuccessResult();
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll());
        }

        [CacheAspect(duration: 10)]
        public IDataResult<List<CarImage>> GetByCarId(int carId)
        {
            var result = _imageDal.GetAll(c => c.CarId == carId).Any();
            if (!result)
            {
                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage { CarId = carId, ImagePath = @"\Images\logo.jpg" });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(p => p.CarId == carId));
        }


        [CacheRemoveAspect("ICarImageService.Get")]
        public IResult Update(IFormFile file, CarImage carImage)
        {
            var oldpath = $@"{Environment.CurrentDirectory}\wwwroot{_imageDal.Get(p => p.ImageId == carImage.ImageId).ImagePath}";
            carImage.ImagePath = FileHelper.UpdateAsync(oldpath, file);

            _imageDal.Update(carImage);
            return new SuccessResult();
        }

        public IDataResult<CarImage> Get(int id)
        {
            return new SuccessDataResult<CarImage>(_imageDal.Get(i => i.ImageId == id));
        }

        public IDataResult<List<CarImage>> GetImagesByCarId(int CarId)
        {
            var result = _imageDal.GetAll(c => c.CarId == CarId).Any();
            if (!result)
            {
                List<CarImage> carimage = new List<CarImage>();
                carimage.Add(new CarImage { CarId = CarId, ImagePath = @"\Images\logo.jpg" });
                return new SuccessDataResult<List<CarImage>>(carimage);
            }
            return new SuccessDataResult<List<CarImage>>(_imageDal.GetAll(p => p.CarId == CarId));
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
