using EmaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmaAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class CompanyController : ControllerBase
	{
		private readonly ICompanyService _companyService;

		public CompanyController(ICompanyService companyService)
		{
			_companyService = companyService;
		}
	}
}
