using Microsoft.AspNetCore.Mvc;

namespace WarehouseApi2.Controllers
{
    public class StockController : Controller
    {
        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            using (ContextDB db = new ContextDB())
            {
                var StockList = db.stock.ToList();
                return Ok(StockList);
            }

        }
    }
}
