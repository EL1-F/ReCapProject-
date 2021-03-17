using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int brandıd);
        IDataResult<List<Car>> GetAllByColorId(int colorId);
        IDataResult<List<Car>> GetByDailyPrice(decimal min, decimal max);
        IDataResult<List<CarDetailDto>> GetCarDetail(Expression<Func<Car, bool>> filter = null);
        IDataResult<List<CarImageDetailDto>> GetCarImageDetail(Expression<Func<Car, bool>> filter = null);
        

        IDataResult<Car> GetById(int carId);

        IResult Add(Car car);
        IResult Delete(Car car);
        IResult Update(Car car);

    }
}
