using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BrandsController : ControllerBase
	{
		IBrandService _brandService;

		public BrandsController(IBrandService brandService)
		{
			_brandService = brandService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _brandService.GetAll();
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}

		[HttpGet("GetById")]
		public IActionResult GetById(int id)
		{
			var result = _brandService.GetById(id);
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}



		[HttpPost("Add")]
		public IActionResult Add(string brandName)
		{
			Brand brand = new Brand();

			brand.BrandName = brandName;

			var result = _brandService.Add(brand);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Update")]
		public IActionResult Update(int BrandId,string newBrandName)
		{
			var result1 = _brandService.GetById(BrandId);
			result1.Data.BrandName = newBrandName;

			var result = _brandService.Update(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Delete")]
		public IActionResult Delete(int deletedbrandId)
		{

			var result1 = _brandService.GetById(deletedbrandId);
			var result = _brandService.Delete(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}
	}
}
