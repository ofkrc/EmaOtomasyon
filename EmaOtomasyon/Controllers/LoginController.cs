// EmaOtomasyon projesi içinde
using EmaAPI.Models;
using EmaAPI.Models.Request.User;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace EmaOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("http://localhost:5001/"); // API'nin adresine uygun şekilde değiştirin
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            try
            {
                var loginModel = new UserLoginRequestModel
                {
                    UserName = username,
                    Password = password
                };

                var endpoint = "api/User/Login"; // API'nin belgesine uygun şekilde değiştirin

                var response = await _httpClient.PostAsJsonAsync(endpoint, loginModel);

                if (response.IsSuccessStatusCode)
                {
                    // Başarılı işlemler burada gerçekleştirilebilir
                    return RedirectToAction("Index");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();
                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("ErrorPage");
            }
        }

    }
}
