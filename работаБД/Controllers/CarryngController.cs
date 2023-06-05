using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WarehouseApi2;
using WarehouseApi2.Model;

namespace MyWebAPI.Controllers
{
    // Атрибут ApiController включает некоторые функции Web API
    [ApiController]
    

    public class CarryngController : ControllerBase
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddCarryng([FromBody]Carryngs NewCarryng)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB db = new ContextDB())
            {
                NewCarryng.id_carryng = Guid.NewGuid();
                db.Add(NewCarryng);
                db.SaveChanges();
            }
            return Ok();
        }

       

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
      
            ContextDB DB = new ContextDB();
       
            var carryngs = DB.carryng.ToList();
           

           
 
            return Ok(carryngs);
        }

        [Route("Delete/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCarryng(Guid id_carryng)
        {
            using(ContextDB db = new ContextDB())
            {
                Carryngs DelCarryng = db.carryng.Find(id_carryng);
                if (DelCarryng != null)
                {
                    db.Remove(DelCarryng);
                    db.SaveChanges();
                    return Ok();
                }

                return BadRequest(ModelState);  
            }
          
        }

        [Route("Update/[controller]")]
        [HttpPut]
        public IActionResult UpdateCounterparty([FromBody] Carryngs UpdateCarryngs)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (ContextDB db = new ContextDB())
            {
              
              


                var FindCarryng = db.carryng.Find(UpdateCarryngs.id_carryng);
                if (FindCarryng == null)
                {
                    return NotFound();
                }
                var FindStock = db.stock.Find(UpdateCarryngs.id_product, UpdateCarryngs.id_warehouse);

                if (FindStock == null) // проверяем, что FindStock не равен null
                {
                    return NotFound(); // возвращаем статус 404, если объект не найден
                }
                FindStock.quanity = (FindStock.quanity - FindCarryng.quanity) + UpdateCarryngs.quanity;

                if (UpdateCarryngs.id_counterparty.ToString() != "3fa85f64-5717-4562-b3fc-2c963f66afa6") FindCarryng.id_counterparty = UpdateCarryngs.id_counterparty;

                if (UpdateCarryngs.id_product.ToString() != "3fa85f64-5717-4562-b3fc-2c963f66afa6") FindCarryng.id_product = UpdateCarryngs.id_product;

                if (UpdateCarryngs.id_warehouse.ToString() != "3fa85f64-5717-4562-b3fc-2c963f66afa6") FindCarryng.id_warehouse = UpdateCarryngs.id_warehouse;

                if (UpdateCarryngs.quanity != 0) FindCarryng.quanity = UpdateCarryngs.quanity;

                if (UpdateCarryngs.cost != 0 ) FindCarryng.quanity = UpdateCarryngs.quanity;

                
               
            
                db.Update(FindCarryng);
                db.Update(FindStock);
                db.SaveChanges();





                //if (UpdateCounterparty.name_counterparty != "string") FindCounterparty.name_counterparty = UpdateCounterparty.name_counterparty;

                //if (UpdateCounterparty.phone != "string") FindCounterparty.phone = UpdateCounterparty.phone;

            

                db.SaveChanges();
            }
            return Ok();
        }

    }
}
