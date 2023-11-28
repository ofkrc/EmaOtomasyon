using EmaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EmaAPI.Controllers
{
	[ApiController]
	[Route("api/[controller]")]
	public class InvoiceController : ControllerBase
	{
		private readonly IInvoiceService _invoiceService;

		public InvoiceController(IInvoiceService invoiceService)
		{
			_invoiceService = invoiceService;
		}
	}
}

