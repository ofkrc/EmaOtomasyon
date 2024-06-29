using EmaOtomasyon.Models.Company.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmaOtomasyon.Controllers
{
    public class CompanyController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CompanyController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;

                var endpoint = "api/Company/Get";

                var response = await httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var CompanysResponseList = JsonConvert.DeserializeObject<List<CompanyResponseModel>>(responseContent);
                    return View(CompanysResponseList);
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
            var endpoint = $"api/Company/GetCompanyById?id={recordId}";

            try
            {
                var response = await httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var Company = JsonConvert.DeserializeObject<CompanyResponseModel>(responseBody);
                    return View(Company);
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
        public async Task<IActionResult> Update(CompanyResponseModel model, int CompanyId)
        {
            var CompanyModel = new CompanyResponseModel
            {
                CompanyName = model.CompanyName,
                Code = model.Code,
                Address = model.Address,
                Website = model.Website,
                Deleted = model.Deleted,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Status = model.Status,
                TaxOffice = model.TaxOffice,
                UserId = model.UserId,
                RecordId = model.RecordId,
                TaxNo = model.TaxNo,
                UpdatedDatetime = DateTime.Now,
                CreatedDatetime = model.CreatedDatetime
            };

            var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;
            var endpoint = $"api/Company/Update?CompanyId={model.RecordId}";

            try
            {
                var response = await httpClient.PutAsJsonAsync(endpoint, CompanyModel);

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

        [HttpGet]
        public async Task<IActionResult> AddCompany()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddCompany(CompanyResponseModel model)
        {
            var CompanyModel = new CompanyResponseModel
            {
                CompanyName = model.CompanyName,
                Address = model.Address,
                Website = model.Website,
                Deleted = false,
                Email = model.Email,
                PhoneNumber = model.PhoneNumber,
                Status = true,
                TaxOffice = model.TaxOffice,
                RecordId = model.RecordId,
                TaxNo = model.TaxNo,
                Code = model.Code,
                UpdatedDatetime = model.UpdatedDatetime,
                CreatedDatetime = DateTime.Now,
                UserId = Convert.ToInt32(HttpContext.Items["RecordId"])
            };

            var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;
            var endpoint = $"api/Company/Insert";

            try
            {
                var response = await httpClient.PostAsJsonAsync(endpoint, CompanyModel);

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

        [HttpPost]
        public async Task<IActionResult> Delete(int CompanyId)
        {
            var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;
            var endpoint = $"api/Company/{CompanyId}";

            try
            {
                var response = await httpClient.DeleteAsync(endpoint);

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
}
