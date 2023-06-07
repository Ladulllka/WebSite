using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WarehouseApi2.Model;

namespace WebSite.Controllers
{
    public class WarehouseShowController : Controller
    {
      
        public async Task<IActionResult> ShowWarehouse()
        {
            // выполнить разную логику в зависимости от имени кнопки

            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7188/Show/Warehouse");
            string json = await response.Content.ReadAsStringAsync();
            List<Warehouse> data = JsonConvert.DeserializeObject<List<Warehouse>>(json);
            foreach (var item in data)
            {
                Debug.WriteLine(item); // или Trace.WriteLine(item)
            }
                         // вернуть представление с моделью
            return View(data); // добавить модель в качестве параметра
        }
    }
}
