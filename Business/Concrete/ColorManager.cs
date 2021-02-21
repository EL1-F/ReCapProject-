﻿using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccsess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
   
        public class ColorManager : IColorService
        {
            IColorDal _colorDal;

            public ColorManager(IColorDal colorDal)
            {
                _colorDal = colorDal;
            }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.Added);
            }

            public IResult Delete(Color color)
            {
                _colorDal.Delete(color);
                 return new SuccessResult(Messages.Deleted);
            }

            public IDataResult<List<Color>> GetAll()
            {
                if (DateTime.Now.Hour==4)
                {
                    return new ErrorDataResult<List<Color>>(Messages.MaintenanceTime);
                }
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(),Messages.Listed);
            }

            public IDataResult<Color> GetColor(int colorId)
            {
                return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorId));
            }

            public IResult Update(Color color)
            {
                _colorDal.Update(color);
                return new SuccessResult(Messages.Updated);
            }
        }
}
