using EmaAPI.Models;
using EmaAPI.Models.Request.User;
using EmaAPI.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
	private readonly IUserService _userService;

	public UserController(IUserService userService)
	{
		_userService = userService;
	}

	[HttpPost("Insert")]
	public ActionResult<User> Insert([FromBody] UserRequestModel request)
	{
		var newUser = _userService.Insert(request);

		return CreatedAtAction(nameof(Insert), new { id = newUser.RecordId }, newUser);
	}

	[HttpGet("Search")]
	public ActionResult<List<User>> SearchUsers([FromQuery] string searchTerm)
	{
		var users = _userService.SearchUsers(searchTerm);
		return Ok(users);
	}

	[HttpGet("GetAllUsers")]
	public IActionResult GetAllUsers()
	{
		var users = _userService.GetAllUsers();
		return Ok(users);
	}

	[HttpGet("GetAllUsers/{userId}")]
	[NonAction]
	public IActionResult GetUserById(int recordId)
	{
		var user = _userService.GetUserById(recordId);

		if (user == null)
		{
			return NotFound();
		}

		return Ok(user);
	}

	[HttpPost("Update")]
	public IActionResult UpdateUser([FromBody] UserRequestModel request)
	{
		try
		{
			// Güncellenmek istenen kullanıcının kaydını al
			var updatedUser = _userService.Update(request);

			// Kullanıcı bulunamazsa 404 Not Found döndür
			if (updatedUser == null)
			{
				return NotFound();
			}

			return Ok(updatedUser);
		}
		catch (Exception ex)
		{
			return StatusCode(500, $"Internal Server Error: {ex.Message}");
		}
	}


	[HttpDelete("Delete/{recordId}")]
	public IActionResult Delete(int recordId)
	{
		var user = _userService.GetUserById(recordId);
		if (user == null)
		{
			return NotFound();
		}

		_userService.Delete(user);
		return NoContent();
	}
}
