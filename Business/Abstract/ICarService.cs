﻿using Entities.Concrete;
using Entities.DTOs;
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
        List<CarDetailDto> GetCarDetail();

        void Add(Car car);
        void Delete(Car car);
        void Update(Car car);

    }
}
