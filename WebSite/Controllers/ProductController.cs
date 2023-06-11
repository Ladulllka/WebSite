using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WarehouseApi2.Model;

namespace WebSite.Controllers
{
    public class ProductController : Controller
    {
        public async Task<IActionResult> ProductPageAsync()
        {
            
                HttpClient client = new HttpClient();

                HttpResponseMessage Response = await client.GetAsync("https://localhost:7188/ShowView/Product");

                string json = await Response.Content.ReadAsStringAsync();

                List<ProductViewModel> dataProduct = JsonConvert.DeserializeObject<List<ProductViewModel>>(json);

                var products = dataProduct.ToList();

                ViewBag.Data = products;

                return View();
            
         
        }
    }
}
