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
        public IActionResult AddCarryng(int idCounterparty, int idProduct, int idWarehouse, int quanity, int cost)
        {
        
            Carryngs newCarryng = new Carryngs();
            newCarryng.AddNew(idCounterparty, idProduct, idWarehouse, quanity, cost); //С помощью методов класса Carryng добавляем в БД 
         
            return Ok(newCarryng.GetAll());
        }

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            ContextDB DB = new ContextDB();
            // Создаем новый объект Carryng из параметров запроса
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
