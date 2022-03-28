using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
	public class EfRentalDal : EfEntityRepositoryBase<Rental, ReCapProjectContext>, IRentalDal

	{
		public List<RentalDetailDto> RentalDetailDto()
		{
			using (ReCapProjectContext context=new ReCapProjectContext())
			{
				var result = from rntl in context.Rentals
							 join crs in context.Cars on rntl.CarId equals crs.Id
							 join cstmr in context.Customers on rntl.CustomerId equals cstmr.Id
							 join brnd in context.Brands on crs.BrandId equals brnd.Id
							 join clr in context.Colors on crs.ColorId equals clr.Id
							 join usr in context.Users on cstmr.UserId equals usr.Id

							 select new RentalDetailDto

							 {
								 Id = rntl.CarId,
								 BrandName = brnd.BrandName,
								 ColorName = clr.ColorName,
								 DailyPrice = crs.DailyPrice,
								 CompanyName = cstmr.CompanyName,
								 Email = usr.Email,
								 FirstName = usr.FirstName,
								 LastName = usr.LastName,
								 ModelYear = crs.ModelYear,
								 RentDate=rntl.RentDate,
								 ReturnDate=rntl.ReturnDate
								 
							 };

				return result.ToList();

			}



			//var result = from crs in context.Cars  //   Cars=brand+color   Rental=Cars+Customer
			//			 join brnd in context.Brands on crs.BrandId equals brnd.Id
			//			 join clr in context.Colors on crs.ColorId equals clr.Id
			//			 from rentl in context.Rentals
			//			 join cstmr in context.Customers on rentl.CustomerId equals cstmr.Id
			//			 join usr in context.Users on cstmr.UserId equals usr.Id
			//			 select new RentalDetailDto

			//			 {
			//				 Id = rentl.Id,
			//				 BrandName = brnd.BrandName,
			//				 ColorName = clr.ColorName,
			//				 CompanyName = cstmr.CompanyName,
			//				 DailyPrice = crs.DailyPrice,
			//				 Email = usr.Email,
			//				 FirstName = usr.FirstName,
			//				 LastName = usr.LastName,
			//				 ModelYear = crs.ModelYear
			//			 };



		}
	}
}
