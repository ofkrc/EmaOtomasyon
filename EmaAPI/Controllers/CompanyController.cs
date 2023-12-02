using EmaAPI.Models.Request.Item;
using EmaAPI.Models;
using EmaAPI.Services;
using Microsoft.AspNetCore.Mvc;
using EmaAPI.Models.Request.Company;

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

		[HttpPost("Insert")]
		public ActionResult<Company> Insert([FromBody] CompanyRequestModel request)
		{
			var newItem = _companyService.Insert(request);

			return CreatedAtAction(nameof(Insert), new { id = newItem.RecordId }, newItem);
		}

		[HttpPut("Update")]
		public IActionResult Update(int companyId, [FromBody] CompanyRequestModel request)
		{
			var updatedCompany = _companyService.Update(companyId, request);
			if (updatedCompany != null)
			{
				return Ok(updatedCompany);
			}
			return NotFound();
		}

		[HttpGet("GetAllSearch")]
		public IActionResult Search()
		{
			try
			{
				var companies = _companyService.Search();
				return Ok(companies);
			}
			catch (Exception ex)
			{
				// Diğer olası hataları ele alabilirsiniz.
				return StatusCode(500, "Bir hata oluştu.");
			}
		}

		[HttpGet("SearchCompanies")]
		public IActionResult SearchCompanies(string searchTerm)
		{
			try
			{
				var companies = _companyService.SearchCompanies(searchTerm);
				return Ok(companies);
			}
			catch (Exception ex)
			{
				return StatusCode(500, "Bir hata oluştu.");
			}
		}

		[HttpDelete("{id}")]
		public IActionResult DeleteCompanies(int id)
		{
			try
			{
				_companyService.DeleteCompanies(id);
				return Ok("Ürün başarıyla silindi.");
			}
			catch (InvalidOperationException ex)
			{
				return NotFound(ex.Message);
			}
			catch (Exception ex)
			{
				// Diğer olası hataları ele alabilirsiniz.
				return StatusCode(500, "Bir hata oluştu.");
			}
		}
	}
}
