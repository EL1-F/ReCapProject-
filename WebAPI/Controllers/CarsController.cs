using Business.Abstract;
using Business.Concrete;
using DataAccsess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //Domain yanına ,buraya ulaşmak için, konacak (istek)
    [ApiController]
    public class CarsController : ControllerBase
    {
        ICarService _carService;

        public CarsController(ICarService carService) //soyuta bağımlılık var
        {
            _carService = carService;
        }

        [HttpGet("getall")] //  /getall eklenecek
        public IActionResult GetAll()  
        {
           // ICarService carService = new CarManager(new EfCarDal());
            var result = _carService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("add")] //  /add eklenecek 
        public IActionResult Add(Car car)
        {
            var result = _carService.Add(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update(Car car)
        {
            var result = _carService.Update(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("delete")]
        public IActionResult Delete(Car car)
        {
            var result = _carService.Delete(car);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbyid")]  //  /getbyid?id=1  yazılır >> id si 1 olanı getir
        public IActionResult GetById(int id)
        {
            var result = _carService.GetCarImageDetail(c => c.CarId == id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbybrandid")] 
        public IActionResult GetByBrandId(int id)
        {
            var result = _carService.GetCarDetail(c=>c.BrandId==id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getbycolorid")]  
        public IActionResult GetByColorId(int id)
        {
            var result = _carService.GetCarDetail(c=>c.ColorId==id);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydailyprice")] 
        public IActionResult GetByDailyPrice(decimal min, decimal max)
        {
            var result = _carService.GetByDailyPrice(min, max);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getbydetail")]
        public IActionResult GetByDetail()
        {
            var result = _carService.GetCarDetail();

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

    }
}
