using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		IUserService _userService;

		public UsersController(IUserService userService)
		{
			_userService = userService;
		}

		[HttpGet("GetAll")]
		public IActionResult GetAll()
		{
			var result = _userService.GetAll();
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}

		[HttpGet("GetById")]
		public IActionResult GetById(int id)
		{
			var result = _userService.GetById(id);
			if (result.Success == true)
			{
				return Ok(result);
			}

			return BadRequest(result.Message);

		}



		[HttpPost("Add")]
		public IActionResult Add(string firstName, string lastName, string email, int password)
		{
			User user = new User
			{
				FirstName = firstName,
				LastName = lastName,
				Email = email,
				Password = password
			};


			var result = _userService.Add(user);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}


		[HttpPost("Update")]
		public IActionResult Update(int userId, string newFirstName, string newLastName, string newEmail, int NewPassword)
		{
			var result1 = _userService.GetById(userId);
			result1.Data.FirstName = newFirstName;
			result1.Data.LastName = newLastName;
			result1.Data.Email = newEmail;
			result1.Data.Password = NewPassword;

			var result = _userService.Update(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

		[HttpPost("Delete")]
		public IActionResult Delete(int deletedUserId) 
		{

			var result1 = _userService.GetById(deletedUserId);
			var result = _userService.Delete(result1.Data);

			if (result.Success == true)
			{
				return Ok(result.Message);

			}

			return BadRequest(result.Message);

		}

	}
}
