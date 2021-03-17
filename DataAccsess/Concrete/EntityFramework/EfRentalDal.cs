using Core.DataAccsess.EntityFramework;
using DataAccsess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccsess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, ProjectContext>, IRentalDal
    {
        public List<RentDetailDto> GetRentDetail(Expression<Func<Rental, bool>> filter = null)
        {
            using (ProjectContext context = new ProjectContext())
            {
                var result = from r in filter == null ? context.Rentals : context.Rentals.Where(filter)
                             join cs in context.Customers
                             on r.CustomerId equals cs.CustomerId
                             join u in context.Users
                             on cs.UserId equals u.Id
                             join c in context.Cars
                             on r.CarId equals c.CarId
                             join b in context.Brands
                             on c.BrandId equals b.BrandId
                             select new RentDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CarName = b.BrandName,
                                 CustomerName= u.FirstName+ " "+u.LastName,
                                 Company=cs.CompanyName,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };

                return result.ToList();
            }
        }
    }
}
