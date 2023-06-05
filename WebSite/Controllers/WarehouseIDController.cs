﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using WarehouseApi2.Model;

namespace WebSite.Controllers
{
    public class WarehouseIDController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> WarehouseAsync()
        //{
        //    // Десериализовать JSON в список объектов
        //    HttpClient client = new HttpClient();
        //    HttpResponseMessage response = await client.GetAsync("https://localhost:7188/Show/Stock");
        //    string json = await response.Content.ReadAsStringAsync();
        //    List<StockViewModel> data = JsonConvert.DeserializeObject<List<StockViewModel>>(json);

        //    foreach (var item in data)
        //    {
        //        Debug.WriteLine(item); // или Trace.WriteLine(item)
        //    }
        //    return View(data);
        //}

        public async Task<IActionResult> WarehouseIDAsync()
        {
            // выполнить разную логику в зависимости от имени кнопки
      
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync("https://localhost:7188/ShowId/Stock");
            string json = await response.Content.ReadAsStringAsync();
            List<Stock> data = JsonConvert.DeserializeObject<List<Stock>>(json);
            foreach (var item in data)
            {
                Debug.WriteLine(item); // или Trace.WriteLine(item)
            }
            // вернуть представление
            return View(data);
        }


    }
}
