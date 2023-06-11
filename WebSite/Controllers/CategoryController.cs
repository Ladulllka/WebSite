using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WarehouseApi2.Model;

namespace WebSite.Controllers
{
    public class CategoryController : Controller
    {
        public async Task<IActionResult> CategoryPageAsync()
        {
            HttpClient client = new HttpClient();

            HttpResponseMessage Response = await client.GetAsync("https://localhost:7188/Show/Category");

            string json = await Response.Content.ReadAsStringAsync();

            List<Category> dataCategory = JsonConvert.DeserializeObject<List<Category>>(json);

            var categories = dataCategory.ToList();

            ViewBag.Data = categories;

            return View();
        }
    }
}
