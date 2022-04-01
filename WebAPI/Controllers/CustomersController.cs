using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CustomersController : ControllerBase
	{
		ICustomerService _customerService;

		public CustomersController(ICustomerService customer)
		{
			_customerService = customer;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _customerService.GetAll();
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}

		[HttpGet("GetById")]
		public IActionResult GetById(int id)
		{
			var result = _customerService.GetById(id);
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}



		[HttpPost("Add")]
		public IActionResult Add(int userId,string companyName) 
		{
			Customer customer = new Customer
			{
				UserId = userId,
				CompanyName = companyName
			};


			var result = _customerService.Add(customer);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Update")]
		public IActionResult Update(int customerId, string newCompanyName)
		{
			var result1 = _customerService.GetById(customerId);
			result1.Data.CompanyName = newCompanyName;

			var result = _customerService.Update(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Delete")]
		public IActionResult Delete(int deletedCustomerId) 
		{

			var result1 = _customerService.GetById(deletedCustomerId);
			var result = _customerService.Delete(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}


	}
}
