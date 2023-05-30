using Microsoft.AspNetCore.Mvc;
using WarehouseApi2.Model;

namespace WarehouseApi2.Controllers
{
    public class WarehouseController : Controller
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddWarehouse([FromBody] Warehouse NewWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB db = new ContextDB())
            {
                NewWarehouse.id_warehouse= Guid.NewGuid();
                db.Add(NewWarehouse);
                db.SaveChanges();
            }
            return Ok();
        }

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult GetAllWarehouse ()
        {
            using (ContextDB db = new ContextDB())
            {
                var WarehouseList = db.warehouse.ToList();
                return Ok(WarehouseList); ;
            }

        }

        [Route("Dell/[controller]")]
        [HttpDelete]
        public IActionResult DeleteWarehouseByID(Guid id_warehouse)
        {
            using (ContextDB db = new ContextDB())
            {
                Warehouse data = db.warehouse.Find(id_warehouse);
                if (data != null)
                {
                    db.warehouse.Remove(data);
                    db.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);

            }
        }

        [Route("Update/[controller]")]
        [HttpPut]
        public IActionResult UpdateWarehouse([FromBody] Warehouse UpdateWarehouse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (ContextDB db = new ContextDB())
            {
                var FindWarehouse = db.warehouse.Find(UpdateWarehouse.id_warehouse);

                if (FindWarehouse == null)
                {
                    return NotFound();
                }

                if (UpdateWarehouse.name_warehouse != "string") FindWarehouse.name_warehouse = UpdateWarehouse.name_warehouse;

                if (UpdateWarehouse.address_warehouse != "string") FindWarehouse.address_warehouse = UpdateWarehouse.address_warehouse;

                db.Update(FindWarehouse);

                db.SaveChanges();
            }
            return Ok();
        }

    }
}
