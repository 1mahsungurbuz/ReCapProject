using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ColorsController : ControllerBase
	{

		IColorService _colorService;

		public ColorsController(IColorService colorService)
		{
			_colorService = colorService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _colorService.GetAll();
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}

		[HttpGet("GetById")]
		public IActionResult GetById(int id)
		{
			var result = _colorService.GetById(id);
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}



		[HttpPost("Add")]
		public IActionResult Add(string colorName)
		{
			Color color = new Color();

			color.ColorName = colorName;

			var result = _colorService.Add(color);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Update")]
		public IActionResult Update(int colorId, string newColorName)
		{
			var result1 = _colorService.GetById(colorId);
			result1.Data.ColorName = newColorName; 
			 
			var result = _colorService.Update(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Delete")]
		public IActionResult Delete(int deletedColorId)
		{

			var result1 = _colorService.GetById(deletedColorId);
			var result = _colorService.Delete(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}
	}
}
