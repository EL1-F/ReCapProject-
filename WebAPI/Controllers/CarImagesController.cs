using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;


namespace WebAPI.Controllers
{
    [Route("api/[controller]")] //Domain yanına ,buraya ulaşmak için, konacak (istek)
    [ApiController]
    public class CarImagesController:ControllerBase
    {
        ICarImageService _imageService;
        IWebHostEnvironment _environment;
        //Dosyayı uygulamınızda bir dizine yüklemek istiyoruz, webroot yolunu almak için IHostingEnvironment'i injection ediyoruz.

        public CarImagesController(ICarImageService imageService,IWebHostEnvironment environment)
        {
            _imageService = imageService;
            _environment = environment;
        }



        
        [HttpPost("add")]
        public IActionResult AddAsync([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        //FromForm ile modele ve entities e bağlanıyoruz
        //IFormFile>>HttpRequest ile gönderilen dosyayı temsil eder.

        {
            var result = _imageService.Add(file,carImage); 
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpPost("delete")]
        public IActionResult Delete([FromForm(Name = ("Id"))] int id)
        {
            var carImage = _imageService.Get(id).Data;
            var result = _imageService.Delete(carImage);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("update")]
        public IActionResult Update([FromForm(Name = ("Image"))] IFormFile file, [FromForm] CarImage carImage)
        {
            var result = _imageService.Update(file, carImage);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _imageService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }



        [HttpGet("getbycarid")]
        public IActionResult GetByCarId(int carId)
        {
            var result = _imageService.GetByCarId(carId);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("getimagesbycaridform")]
        public IActionResult GetImagesByCarId([FromForm(Name = ("CarId"))] int CarId)
        {
            var result = _imageService.GetImagesByCarId(CarId);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


    }
}
