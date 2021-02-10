using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager:ICarService
    {
        ICarDal _CarDal; //bir iş sınıfı başka bir sınıfı new'lemez injection yapıyoruz

        public CarManager(ICarDal carDal)
        {
            _CarDal = carDal;
        }

        public void Add(Car car)
        {
            if (car.DailyPrice >0)
            {
                _CarDal.Add(car);
            }
            else
            {
                Console.WriteLine("Sıfırdan farklı bir tutar giriniz.");
            }
            
        }

        public void Delete(Car car)
        {
            _CarDal.Delete(car);
        }

        public List<Car> GetAll()
        {
            return _CarDal.GetAll();
        }

        public List<Car> GetAllByBrandId(int brandId)
        {
            return _CarDal.GetAll(c => c.BrandId == brandId);
        }

        public List<Car> GetAllByColorId(int colorId)
        {
            return _CarDal.GetAll(c => c.ColorId == colorId);
        }

        public List<Car> GetByDailyPrice(decimal min, decimal max)
        {
            return _CarDal.GetAll(c => c.DailyPrice >= min && c.DailyPrice <= max);
        }

        public List<CarDetailDto> GetCarDetail()
        {
            return _CarDal.GetCarDetail();
        }

        public void Update(Car car)
        {
            _CarDal.Update(car);
        }

        
    }
}
