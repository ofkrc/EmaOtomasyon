// EmaOtomasyon projesi içinde
using EmaAPI.Models.Request.User;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmaOtomasyon.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;

        public LoginController()
        {
            _httpClient = new HttpClient();
            //_httpClient.BaseAddress = new Uri("http://localhost:5001/");
            _httpClient.BaseAddress = new Uri("http://localhost:5000/"); // API'nin adresine uygun şekilde değiştirin
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

                var endpoint = "api/User/Login"; 

                var response = await _httpClient.PostAsJsonAsync(endpoint, loginModel);

                if (response.IsSuccessStatusCode)
                {
                    var tokenResponse = await response.Content.ReadAsStringAsync();
                    var token = JsonConvert.DeserializeObject<TokenModel>(tokenResponse);

                    HttpContext.Session.SetString("AccessToken", token.result.authToken);
                    return RedirectToAction("Index","Home");
                }
                else
                {
                    var errorMessage = await response.Content.ReadAsStringAsync();

                    throw new Exception(errorMessage);
                }
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = "Hatalı kullanıcı adı veya şifre.";
                return View("Index");
            }
        }

    }
}
