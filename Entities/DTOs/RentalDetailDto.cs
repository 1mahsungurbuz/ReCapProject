using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs
{
	public class RentalDetailDto:IDto
	{
		public int Id { get; set; }
		public string BrandName { get; set; } // Brands
		public string ColorName { get; set; } // Colors
		public string CompanyName { get; set; } // Customer
		public decimal DailyPrice { get; set; } // Cars
		public string Email { get; set; } // User
		public string FirstName { get; set; } // User
		public string LastName { get; set; } // User
		public int ModelYear { get; set; } // Cars
		public DateTime RentDate { get; set; }
		public int ReturnDate { get; set; }  

	}
}
