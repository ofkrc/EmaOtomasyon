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
            var response = await httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var responseBody = await response.Content.ReadAsStringAsync();
                var customer = JsonConvert.DeserializeObject<CustomerGetModel>(responseBody);
                return View(customer);
            }
            else
            {
                return RedirectToAction("Index"); 
            }
        }
        catch (HttpRequestException)
        {
            return StatusCode(500, "API ile iletişim kurulurken bir hata oluştu.");
        }
    }

    [HttpPost]
    public async Task<IActionResult> Update(CustomerGetModel model, int customerId)
    {
        var customerModel = new CustomerGetModel
        {
            Name = model.Name,
            Address = model.Address,
            CompanyId = model.CompanyId,
            Deleted = model.Deleted,
            Email = model.Email,
            PhoneNumber = model.PhoneNumber,
            Status = model.Status,
            Surname = model.Surname,
            UserId = model.UserId,
            RecordId = model.RecordId
        };

        var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;
        var endpoint = $"api/Customer/Update?customerId={model.RecordId}";

        try
        {
            var response = await httpClient.PutAsJsonAsync(endpoint,customerModel);

            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
        catch (HttpRequestException)
        {
            return StatusCode(500, "API ile iletişim kurulurken bir hata oluştu.");
        }
    }





}
