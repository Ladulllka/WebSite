using Microsoft.AspNetCore.Mvc;
using WarehouseApi2.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Cors;

namespace WarehouseApi2.Controllers
{
    public class StockController : Controller
    {
        [Route("Show/[controller]/{id_warehouse}")] // Указываем id_warehouse в маршруте
        [HttpGet]
        [EnableCors(PolicyName = "AllowAll")]
        public async Task<IActionResult> ShowAsync([FromRoute] Guid id_warehouse) // Добавляем атрибут [FromRoute] к параметру
        {
            using (ContextDB db = new ContextDB())
            {
                var stockList = await db.stock
                .Include(s => s.product) // включение данных из таблицы Product
                .Include(s => s.warehouse) // включение данных из таблицы Warehouse
                .Where(s => s.warehouse.id_warehouse == id_warehouse) // фильтрация по id склада
                .ToListAsync();



                var stockViewModelList = stockList.Select(s => new StockViewModel
                {
                    WarehouseID = s.warehouse.id_warehouse,
                    ProductID = s.product.id_product,
                    ProductName = s.product.name_product,
                    WarehouseName = s.warehouse.name_warehouse,
                    Quantity = s.quanity

                }).ToList();



                return Ok(stockViewModelList);
                // возврат списка анонимных типов в качестве результата действия

            }


        }

        [Route("Show/[controller]")] // Указываем id_warehouse в маршруте
        [HttpGet]
        [EnableCors(PolicyName = "AllowAll")]
        public async Task<IActionResult> ShowAll() // Добавляем атрибут [FromRoute] к параметру
        {
            using (ContextDB db = new ContextDB())
            {

                var stockList = await db.stock
                .Include(s => s.product) // включение данных из таблицы Product
                .Include(s => s.warehouse) // включение данных из таблицы Warehouse
                .ToListAsync();



                var stockViewModelList = stockList.Select(s => new StockViewModel
                {
                    WarehouseID = s.warehouse.id_warehouse,
                    ProductID = s.product.id_product,
                    ProductName = s.product.name_product,
                    WarehouseName = s.warehouse.name_warehouse,
                    Quantity = s.quanity

                }).ToList();



                return Ok(stockViewModelList);
                // возврат списка анонимных типов в качестве результата действия

            }


        }

        [Route("ShowId/[controller]")]
        [HttpGet]
        public async Task<IActionResult> ShowAsyncId()
        {
            using (ContextDB db = new ContextDB())
            {
                var AllStock =  db.stock.ToList();


                return Ok(AllStock);
                // возврат списка анонимных типов в качестве результата действия

            }


        }
    }
}
