using Microsoft.AspNetCore.Mvc;
using WarehouseApi2.Model;

namespace WarehouseApi2.Controllers
{
    public class CategoryController : Controller
    {


        [Route("add/[controller]")]
        [HttpPost]
        public IActionResult AddCategory([FromBody] Category NewCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (ContextDB db = new ContextDB())
            {
                NewCategory.id_category = Guid.NewGuid();
               

                db.Add(NewCategory);
                db.SaveChanges();
            }
            return Ok();

        }

        [Route("Show/[controller]")]
        [HttpGet]
         public IActionResult GetAllCategory()
        {
            using (ContextDB db = new ContextDB())
            {
                var CategoryList = db.category.ToList();
                return Ok(CategoryList);
            }
            
        }

        [Route("Dell/[controller]")]
        [HttpDelete]
        public IActionResult DeleteCategoryByID(Guid id_category)
        {
            using (ContextDB db = new ContextDB())
            {
                Category data = db.category.Find(id_category);
                if (data != null)
                {
                    db.category.Remove(data);
                    db.SaveChanges();
                    return Ok();
                }
                return BadRequest(ModelState);
            
            }
        }

        [Route("Update/[controller]")]
        [HttpPut]
        public IActionResult UpdateCategory([FromBody] Category UpdateCategory)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            using (ContextDB db = new ContextDB())
            {
                var FindCategory = db.category.Find(UpdateCategory.id_category);

                if (FindCategory == null)
                {
                    return NotFound();
                }

                if (UpdateCategory.name_category != "string") FindCategory.name_category = UpdateCategory.name_category;

               

                db.Update(FindCategory);

                db.SaveChanges();
            }
            return Ok();
        }
    }
}
