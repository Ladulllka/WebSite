using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WarehouseApi2.Model;

namespace WebSite.Controllers
{
    public class SellController : Controller
    {
        public async Task<IActionResult> SellPage()
        {
            // Десериализовать JSON в список объектов
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7188/Show/Stock");
            string json = await response.Content.ReadAsStringAsync();
            List<StockViewModel> data = JsonConvert.DeserializeObject<List<StockViewModel>>(json);

            foreach (var item in data)
            {
                Debug.WriteLine(item); // или Trace.WriteLine(item)
            }
            ViewBag.Data = data; 
            return View(data);
        }
    }
}
