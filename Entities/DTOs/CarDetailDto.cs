using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class CarDetailDto:IDto
	{
		public int Id { get; set; }  // Cars
		public string BrandName { get; set; } // Brands
		public string ColorName { get; set; } // Colors
		public decimal DailyPrice { get; set; } // Cars

	}
}
