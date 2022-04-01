using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RentalsController : ControllerBase
	{

		IRentalService _rentalService;

		public RentalsController(IRentalService rentalService)
		{
			_rentalService = rentalService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _rentalService.GetAll();
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}

		[HttpGet("GetById")]
		public IActionResult GetById(int id)
		{
			var result = _rentalService.GetById(id);
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}

		

		public int ReturnDate { get; set; }

		[HttpPost("Add")]
		public IActionResult Add(int carId, int customerId, DateTime rentDate, int returnDate)
		{
			Rental rental = new Rental
			{
				CarId = carId,
				CustomerId = customerId,
				RentDate = rentDate,
				ReturnDate = returnDate
			};


			var result = _rentalService.Add(rental);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}


		[HttpPost("Update")]
		public IActionResult Update(int id,int newCarId, int newCustomerId, DateTime newRentDate, int newReturnDate)
		{
			var result1 = _rentalService.GetById(id);
			result1.Data.CarId = newCarId;
			result1.Data.CustomerId = newCustomerId;
			result1.Data.RentDate = newRentDate;
			result1.Data.ReturnDate = newReturnDate;

			var result = _rentalService.Update(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Delete")]
		public IActionResult Delete(int deletedRentalId) 
		{

			var result1 = _rentalService.GetById(deletedRentalId);
			var result = _rentalService.Delete(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpGet("RentalDetailDto")]
		public IActionResult RentalDetailDto()
		{
			var result = _rentalService.RentalDetailDto();
			if (result.Success)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}

	}
}
