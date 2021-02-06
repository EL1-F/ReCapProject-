using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using DataAccsess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            CarManager carManager = new CarManager(new EfCarDal());

            //carManager.Add(new Car
            //{
            //    BrandId = 1,
            //    ColorId = 2,
            //    ModelYear = 2002,
            //    DailyPrice = 35000,
            //    Descriptions = "Öyle bir temiz anlatamam."
            //});

            //Console.WriteLine("*****************Mevcut arabalar****************");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
            //      , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);

            //}

            //carManager.Delete(new Car 
            //{
            //    CarId=6,
            //    BrandId = 1,
            //    ColorId = 2,
            //    ModelYear = 2002,
            //    DailyPrice = 35000,
            //    Descriptions = "Öyle bir temiz anlatamam."
            //});
            //Console.WriteLine("*****************Mevcut arabalar****************");
            //foreach (var car in carManager.GetAll())
            //{
            //    Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
            //      , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            //}


            Console.WriteLine("-------------ColorId--------------");
            foreach (var car in carManager.GetAllByColorId(4))
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }

            Console.WriteLine("\n-------------BrandId--------------");
            foreach (var car in carManager.GetAllByBrandId(1))
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }

            Console.WriteLine("\n-------------DailyPrice--------------");
            foreach (var car in carManager.GetByDailyPrice(50000,130000))
            {
                Console.WriteLine("Araba Id: {0}   Marka Id:{1}   Renk Id:{2}   Model Yılı: {3}  Fiyatı: {4} TL   Açıklama: {5}"
                  , car.CarId, car.BrandId, car.ColorId, car.ModelYear, car.DailyPrice, car.Descriptions);
            }

            Console.ReadKey();
        }
    }
}
