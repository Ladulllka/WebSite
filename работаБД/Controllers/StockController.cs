using Microsoft.AspNetCore.Mvc;
using WarehouseApi2.Model;
using Microsoft.EntityFrameworkCore;

namespace WarehouseApi2.Controllers
{
    public class StockController : Controller
    {
        [Route("Show/[controller]")]
        [HttpGet]
        public async Task<IActionResult> ShowAsync()
        {
            using (ContextDB db = new ContextDB())
            {
                var stockList = await db.stock
                .Include(s => s.product) // включение данных из таблицы Product
                .Include(s => s.warehouse) // включение данных из таблицы Warehouse
                .ToListAsync();
                
                
                
                var stockViewModelList = stockList.Select(s => new StockViewModel
                {
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
