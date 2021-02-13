using Core.DataAccsess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Abstract
{
    public interface IRentalDal:IEntityRepository<Rental>
    {
        List<RentDetailDto> GetRentDetail(Expression<Func<Rental, bool>> filter = null);
    }
}
