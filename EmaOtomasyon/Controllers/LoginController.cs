using EmaAPI.Models.Request.User;
using EmaOtomasyon.Models;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace EmaOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public IActionResult Index()
        {
            return View();
        }

    }
}
