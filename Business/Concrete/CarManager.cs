using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{ //Validation kullanımı ortak olduğu için core katmanında yapıyoruz
    public class CarManager:ICarService
    {
        ICarDal _CarDal; //bir iş sınıfı başka bir sınıfı new'lemez injection yapıyoruz

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }


        [SecuredOperation("admin")]
        [ValidationAspect(typeof(CarValidator))] //add metodunu doğrula carCalidator kullanarak
        public IResult Add(Car car)
        { //validation >> objeye işlem yapmak için iş kodlarının yapısal olarak uygunluğunu kontrol ediyoruz

                _CarDal.Add(car);
                return new SuccessResult(Messages.Added);
                  
        }


        [SecuredOperation("admin")]
        public IResult Delete(Car car)
        {
            _CarDal.Delete(car);
            return new SuccessResult(Messages.Deleted);
        }

        [SecuredOperation("Car.List,admin")]
        public IDataResult<List<Car>> GetAll()
        {
            if (DateTime.Now.Hour == 05)
            {
                return new ErrorDataResult<List<Car>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(),Messages.Listed);
        }

        public IDataResult<List<Car>> GetAllByBrandId(int brandId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.BrandId == brandId));
        }

        public IDataResult<List<Car>> GetAllByColorId(int colorId)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.ColorId == colorId));
        }

        public IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Car>>(_CarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max));
        }

        public IDataResult<Car> GetById(int carId)
        {
            return new SuccessDataResult<Car>(_CarDal.Get(c => c.CarId == carId));
        }

        public IDataResult<List<CarDetailDto>> GetCarDetail()
        {
            return new SuccessDataResult<List<CarDetailDto>>(_CarDal.GetCarDetail());
        }

        public IResult Update(Car car)
        {
            _CarDal.Update(car);
            return new SuccessResult(Messages.Updated);
        }

        
    }
}
