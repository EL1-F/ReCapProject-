using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
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

        [SecuredOperation("admin")]
        [ValidationAspect(typeof(BrandValidator))]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Add(Brand brand)
        {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.Added);  
        }


        [SecuredOperation("admin")]
        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.Deleted);
        }

        public IDataResult<Brand> GetBrand(int brandId)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b=>b.BrandId == brandId));
        }

        [CacheAspect]
        [PerformanceAspect(5)]
        public IDataResult<List<Brand>> GetAll()
        {
            if (DateTime.Now.Hour ==4)
            {
                return new ErrorDataResult<List<Brand>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.Listed);
        }


        [SecuredOperation("admin")]
        [CacheRemoveAspect("IBrandService.Get")]
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.Updated);
        }
    }
}
