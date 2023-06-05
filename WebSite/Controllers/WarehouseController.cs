using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WarehouseApi2.Model;

namespace WebSite.Controllers
{
    public class WarehouseController : Controller
    {
        public IActionResult Index()
        {
            return View();
        } 
        public IActionResult SelectWarehouse()
        {
            return View();
        } 
        public IActionResult AddNewWarehouse()
        {
            return View();
        }
        public IActionResult UpdateWarehouse()
        {
            return View();
        }
        public IActionResult DeleteWarehouse()
        {
            return View();
        }

        public async Task<IActionResult> WarehouseAsync()
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
            return View(data);
        }

        //public async Task<IActionResult> ButtonAsync()
        //{
        //    // выполнить разную логику в зависимости от имени кнопки
        //    Console.WriteLine("!!!");
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync("https://localhost:7188/ShowId/Stock");
        //    string json = await response.Content.ReadAsStringAsync();
        //    List<Stock> data = JsonConvert.DeserializeObject<List<Stock>>(json);

        //    // вернуть представление
        //    return View(data);
        //}


    }
}
