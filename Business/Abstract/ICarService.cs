using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        List<Car> GetAll();
        List<Car> GetAllByBrandId(int brandıd);
        List<Car> GetAllByColorId(int colorId);
        List<Car> GetByDailyPrice(decimal min, decimal max);

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

    }
}
