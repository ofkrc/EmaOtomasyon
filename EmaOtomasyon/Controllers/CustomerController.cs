using EmaOtomasyon.Models.Customer.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class CustomerController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;

    public CustomerController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        try
        {
            var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;

            var endpoint = "api/Customer/Get";

            var response = await httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStringAsync();
                var CustomersResponseList = JsonConvert.DeserializeObject<List<CustomerGetModel>>(responseContent);
                return View(CustomersResponseList);
            }
            else
            {
                ViewBag.ErrorMessage = "Şuanda işleminizi gerçekleştiremiyoruz. Lütfen daha sonra tekrar deneyin.";
                return View();
            }
        }
        catch (Exception ex)
        {
            ViewBag.ErrorMessage = "Bir hata oluştu: " + ex.Message;
            return View();
        }
    }

    [HttpGet]
    public async Task<IActionResult> Update(int recordId)
    {
        var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;

        var endpoint = $"api/Customer/GetCustomerById?id={recordId}";

        try
        {
            var response = await httpClient.GetFromJsonAsync<CustomerGetModel>(endpoint);

            if (response != null)
            {
                return View(response);
            }
            else
            {
                return RedirectToAction("Index"); // Veya başka bir sayfaya yönlendirme yapabilirsiniz
            }
        }
        catch (HttpRequestException)
        {
            return StatusCode(500, "API ile iletişim kurulurken bir hata oluştu.");
        }
    }


}
