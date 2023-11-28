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

	[HttpPost]
	public ActionResult<User> Insert([FromBody] UserRequestModel request)
	{
		var newUser = _userService.Insert(request);

		return CreatedAtAction(nameof(Insert), new { id = newUser.RecordId }, newUser);
	}
}
