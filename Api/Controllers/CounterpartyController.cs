using Microsoft.AspNetCore.Mvc;
using WarehouseApi2.Model;

namespace WarehouseApi2.Controllers
{
    public class CounterpartyController : Controller
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult AddNew([FromBody] Counterparty newCounterparty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB db = new ContextDB())
            {
                newCounterparty.id_counterparty = Guid.NewGuid();
                db.Add(newCounterparty);
                db.SaveChanges();
            }
            return Ok();

        }

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult GetAll()
        {
            using (ContextDB db = new ContextDB())
            {
                var CounerpartyList = db.counterparty.ToList();
                return Ok(CounerpartyList);
            }

        }

        [Route("Dell/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCounterpartyByID(Guid id_counterparty)
        {
            using (ContextDB db = new ContextDB())
            {
                Counterparty data = db.counterparty.Find(id_counterparty);

                if (data != null)
                {
                    db.counterparty.Remove(data);
                }

               
                db.SaveChanges();

                return Ok();
            }

      
        }

        [Route("Update/[controller]")]
        [HttpPut]
        public IActionResult UpdateCounterparty([FromBody] Counterparty UpdateCounterparty)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (ContextDB db = new ContextDB())
            {
                var FindCounterparty = db.counterparty.Find(UpdateCounterparty.id_counterparty);

                if (FindCounterparty == null)
                {
                    return NotFound();
                }

                if (UpdateCounterparty.name_counterparty != "string") FindCounterparty.name_counterparty = UpdateCounterparty.name_counterparty;

                if (UpdateCounterparty.phone != "string") FindCounterparty.phone = UpdateCounterparty.phone;

                db.Update(FindCounterparty);

                db.SaveChanges();
            }
            return Ok();
        }
    }
}
