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
	public class EfCarDal : EfEntityRepositoryBase<Car,ReCapProjectContext>, ICarDal
	{
		
		public List<CarDetailDto> GetCarDetails()
		{
			using (ReCapProjectContext context = new ReCapProjectContext())
			{
				var resut = from c in context.Cars 
							join b in context.Brands on c.BrandId equals b.Id
							join r in context.Colors on c.ColorId equals r.Id select new CarDetailDto

							{
								Id = c.Id,
								BrandName = b.BrandName,
								DailyPrice = c.DailyPrice,
								ColorName = r.ColorName
								


							};

				return resut.ToList();
			}
		}

		
	}
}
