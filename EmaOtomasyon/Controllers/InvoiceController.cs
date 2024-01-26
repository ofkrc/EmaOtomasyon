using Microsoft.AspNetCore.Mvc;

namespace EmaOtomasyon.Controllers
{
    public class InvoiceController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
