using Business.Abstract;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager:IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public void Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
            }
            else
            {
                Console.WriteLine("Marka adı minimum 2 karakter olmalıdır.\nİşlem başarısız.");
            }
        }
            

        public void Delete(Brand brand)
        {
            _brandDal.Delete(brand);
        }

        public Brand GetBrand(int brandId)
        {
            return _brandDal.Get(b=>b.BrandId == brandId);
        }

        public List<Brand> GetAll()
        {
            return _brandDal.GetAll();
        }

        
        public void Update(Brand brand)
        {
            _brandDal.Update(brand);
        }
    }
}
