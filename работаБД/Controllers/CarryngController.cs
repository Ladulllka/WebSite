using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WarehouseApi2;
using WarehouseApi2.Model;

namespace MyWebAPI.Controllers
{
    // Атрибут ApiController включает некоторые функции Web API
    [ApiController]
    // Атрибут Route указывает шаблон URL для контроллера

    public class CarryngController : ControllerBase
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddCarryng(int idProduct, int idWarehouse, int quanity)
        {
        
            Carryngs newCarryng = new Carryngs();
            newCarryng.AddNew(idProduct, idWarehouse, quanity); //С помощью методов класса Carryng добавляем в БД 
         
            return Ok(newCarryng.GetAll());
        }

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            ContextDB DB = new ContextDB();
            var sale = DB.sales.ToList();
            var carryngs = DB.carryng.ToList();
            var categoryes = DB.category.ToList();
            var products = DB.product.ToList();
            var warehouses = DB.warehouse.ToList();// Создаем новый объект Carryng из параметров запроса
            Carryngs newCarryng = new Carryngs();
            return Ok(newCarryng.GetAll());
        }
        [Route("Delete/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCarryng(int id_carryng)
        {
            Carryngs newCarryng = new Carryngs();
            newCarryng.DeleteById(id_carryng);
            return Ok(newCarryng.GetAll());
        }

    }
}
