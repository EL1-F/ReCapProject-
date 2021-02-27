using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IDataResult<List<CarImage>> GetAll();
        IDataResult<CarImage> Get(int id);
        IDataResult<List<CarImage>> GetByCarId(int carId);

        IResult Add(IFormFile file, CarImage carImage);
        IResult Delete(int id);
        IResult Update(IFormFile file, CarImage carImage);
    }
}
