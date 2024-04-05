using EmaOtomasyon.Models.Item.Response;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace EmaOtomasyon.Controllers
{
    public class ItemController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ItemController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            try
            {
                var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;

                var endpoint = "api/Item/Get";

                var response = await httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var ItemsResponseList = JsonConvert.DeserializeObject<List<ItemResponseModel>>(responseContent);
                    return View(ItemsResponseList);
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
            var endpoint = $"api/Item/GetItemById?id={recordId}";

            try
            {
                var response = await httpClient.GetAsync(endpoint);

                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    var Item = JsonConvert.DeserializeObject<ItemResponseModel>(responseBody);
                    return View(Item);
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
        public async Task<IActionResult> Update(ItemResponseModel model, int ItemId)
        {
            var ItemModel = new ItemResponseModel
            {
                Name = model.Name,
                Code = model.Code,
                Description = model.Description,
                Deleted = model.Deleted,
                SalesPrice = model.SalesPrice,
                StockQuantity = model.StockQuantity,
                DiscountRate = model.DiscountRate,
                PurchasePrice = model.PurchasePrice,
                UserId = model.UserId,
                RecordId = model.RecordId,
                VatRate = model.VatRate,
                UpdatedDatetime = DateTime.UtcNow
            };

            var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;
            var endpoint = $"api/Item/Update?ItemId={model.RecordId}";

            try
            {
                var response = await httpClient.PutAsJsonAsync(endpoint, ItemModel);

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
        public async Task<IActionResult> AddItem()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddItem(ItemResponseModel model)
        {
            var ItemModel = new ItemResponseModel
            {
                Name = model.Name,
                Code = model.Code,
                Description = model.Description,
                Deleted = model.Deleted,
                SalesPrice = model.SalesPrice,
                StockQuantity = model.StockQuantity,
                DiscountRate = model.DiscountRate,
                PurchasePrice = model.PurchasePrice,
                VatRate = model.VatRate,
                RecordId = model.RecordId,
                CreatedDatetime = DateTime.UtcNow,
                UserId = Convert.ToInt32(HttpContext.Items["RecordId"])
            };

            var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;
            var endpoint = $"api/Item/Insert";

            try
            {
                var response = await httpClient.PostAsJsonAsync(endpoint, ItemModel);

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
        public async Task<IActionResult> Delete(int ItemId)
        {
            var httpClient = HttpContext.Items["MyHttpClient"] as HttpClient;
            var endpoint = $"api/Item/{ItemId}";

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
