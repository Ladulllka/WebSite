using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using WarehouseApi2.Model;

namespace WebSite.Controllers
{
    public class CarryngController : Controller
    {
        public async Task<IActionResult> CarryngPage()
        {


            HttpClient client = new HttpClient();

            HttpResponseMessage ResponseWarehouse = await client.GetAsync("https://localhost:7188/Show/Warehouse");

            string json = await ResponseWarehouse.Content.ReadAsStringAsync();

            List<Warehouse> dataWaregouse = JsonConvert.DeserializeObject<List<Warehouse>>(json);

            var warehouses = dataWaregouse.ToList();

            ViewBag.Warehouses = warehouses;
           


            HttpResponseMessage ResponseProduct = await client.GetAsync("https://localhost:7188/Show/Product");

            json = await ResponseProduct.Content.ReadAsStringAsync();

            List<Product> data = JsonConvert.DeserializeObject<List<Product>>(json);

            var products = data.ToList();

            ViewBag.Products = products;
               
                // Возвращаем представление Create
            return View();
            
          
        }
    }
}
