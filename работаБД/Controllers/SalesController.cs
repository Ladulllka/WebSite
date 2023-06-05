using Microsoft.AspNetCore.Mvc;
using WarehouseApi2;
using WarehouseApi2.Model;

namespace MyWebAPI.Controllers
{
    // Атрибут ApiController включает некоторые функции Web API
    [ApiController]
    // Атрибут Route указывает шаблон URL для контроллера

    public class SalesController : ControllerBase
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddSales([FromBody] Sales NewSales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Создаем новый объект Sales из параметров запроса

            using (ContextDB db = new ContextDB()) {
                NewSales.id_sales = Guid.NewGuid();
                db.Add(NewSales);
                db.SaveChanges();
              
                }

                return Ok(NewSales);
        }

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            Sales newSales = new Sales();

            return Ok(newSales.GetAll());
        }

        [Route("Delete/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCarryng(int id_sales)
        {
            Sales newSales = new Sales();
            newSales.DeleteById(id_sales);

            return Ok(newSales.GetAll());
        }
        [Route("Update/[controller]")]
        [HttpPut]
        public IActionResult UpdateCounterparty([FromBody] Sales UpdateSales)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (ContextDB db = new ContextDB())
            {

                var FindSales = db.sales.Find(UpdateSales.id_sales);
                if (FindSales == null)
                {
                    return NotFound();
                }
                var FindStock = db.stock.Find(UpdateSales.id_product, UpdateSales.id_warehouse);

                if (FindStock == null) // проверяем, что FindStock не равен null
                {
                    return NotFound(); // возвращаем статус 404, если объект не найден
                }
                FindStock.quanity = (FindStock.quanity + FindSales.quanity) - UpdateSales.quanity;
                if (UpdateSales.id_counterparty.ToString() != "3fa85f64-5717-4562-b3fc-2c963f66afa6") FindSales.id_counterparty = UpdateSales.id_counterparty;

                if (UpdateSales.id_product.ToString() != "3fa85f64-5717-4562-b3fc-2c963f66afa6") FindSales.id_product = UpdateSales.id_product;

                if (UpdateSales.id_warehouse.ToString() != "3fa85f64-5717-4562-b3fc-2c963f66afa6") FindSales.id_warehouse = UpdateSales.id_warehouse;

                if (UpdateSales.quanity != 0) FindSales.quanity = UpdateSales.quanity;

                if (UpdateSales.cost != 0) FindSales.quanity = UpdateSales.quanity;



                Console.WriteLine((FindStock.quanity - FindSales.quanity) + UpdateSales.quanity);
                Console.WriteLine(FindStock.quanity);
                Console.WriteLine(FindSales.quanity);
                Console.WriteLine(UpdateSales.quanity);
                db.Update(FindSales);
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