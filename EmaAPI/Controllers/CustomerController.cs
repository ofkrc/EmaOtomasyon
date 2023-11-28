using EmaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmaAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CustomerController : ControllerBase
	{
		private readonly ICustomerService _customerService;

		public CustomerController(ICustomerService customerService)
		{
			_customerService = customerService;
		}
	}
}
