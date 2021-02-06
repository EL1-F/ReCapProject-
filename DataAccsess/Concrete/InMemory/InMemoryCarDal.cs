using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Concrete.InMemory
{
    public class InMemoryCarDal : ICarDal
    {
        List<Car> _cars;
        InMemoryBrandDal memoryBrandDal = new InMemoryBrandDal();
        InMemoryColorDal memoryColorDal = new InMemoryColorDal();

        public InMemoryCarDal()
        {
            _cars = new List<Car>
            {
                new Car { CarId = 1, BrandId=1, ColorId =1, ModelYear=1999, DailyPrice=12000, Descriptions="Temiz araba ama çok kullanılmış."},
                new Car { CarId = 2, BrandId=2, ColorId =1, ModelYear=2018, DailyPrice=75000, Descriptions="Doktordan yeni hijyenik gibi araba."},
                new Car { CarId = 3, BrandId=1, ColorId =2, ModelYear=2002, DailyPrice=35000, Descriptions="Mühendisten makine gibi araba."},
                new Car { CarId = 4, BrandId=3, ColorId =1, ModelYear=2008, DailyPrice=50000, Descriptions="Öğretmenden öğrenci gibi araba."}
            };

        }
        public void Add(Car car)
        {
            _cars.Add(car);
        }


        public void Delete(Car Entity)
        {
            Car carToDelete;
            carToDelete = _cars.SingleOrDefault(c => c.CarId == Entity.CarId);
            _cars.Remove(carToDelete);
        }

        public Car Get(Expression<Func<Car, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Car> GetAll()
        {
            return _cars;
        }

        public List<Car> GetAll(Expression<Func<Car, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Car car)
        {
            Car carToUpdate;
            carToUpdate = _cars.SingleOrDefault(c => c.CarId == car.CarId);
            carToUpdate.BrandId = car.BrandId;
            carToUpdate.ColorId = car.ColorId;
            carToUpdate.ModelYear = car.ModelYear;
            carToUpdate.DailyPrice = car.DailyPrice;
            carToUpdate.Descriptions = car.Descriptions;
        }


    }
}
