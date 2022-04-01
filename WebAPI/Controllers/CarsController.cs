using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]



	public class CarsController : ControllerBase
	{

		ICarService _carService;

		public CarsController(ICarService carService)
		{
			_carService = carService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _carService.GetAll();
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}

		[HttpGet("GetById")]
		public IActionResult GetById(int id)
		{
			var result = _carService.GetById(id);
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}



		[HttpGet("GetCarsByBrandId")]
		public IActionResult GetCarsByBrandId(int id)
		{
			var result = _carService.GetCarsByBrandId(id);
			if (result.Success==true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);
			
		}

		[HttpGet("GetCarsByColorId")]
		public IActionResult GetCarsByColorId(int id)
		{
			var result = _carService.GetCarsByColorId(id);
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}


		[HttpGet("GetByUnitPrice")]
		public IActionResult GetByUnitPrice(decimal min , decimal max)
		{
			var result = _carService.GetByUnitPrice(min,max);
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}

		[HttpGet("GetCarDetails")]
		public IActionResult GetCarDetails()
		{
			var result = _carService.GetCarDetails();
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}


		[HttpPost("Add")]
		public IActionResult Add(int brandId, int colorId, int modelYear, decimal dailyPrice, string description)
		{
			Car car = new Car();
			car.BrandId = brandId;
			car.ColorId = colorId;
			car.ModelYear = modelYear;
			car.Description = description;
			car.DailyPrice = dailyPrice;


		var result = _carService.Add(car);

			if (result.Success==true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Update")]
		public IActionResult Update(int carId, int newBrandId, int newColorId)
		{
			var result1 = _carService.GetById(carId);

			result1.Data.BrandId = newBrandId;
			result1.Data.ColorId = newColorId;

			var result = _carService.Update(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Delete")]
		public IActionResult Delete(int deletedCarId)
		{

			var result1 = _carService.GetById(deletedCarId);
			var result = _carService.Delete(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}



	}
}
