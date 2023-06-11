using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WarehouseApi2.Model;

namespace WarehouseApi2.Controllers
{
    public class ProductController : Controller
    {
        [Route("Add/[controller]")]
        [HttpPost]
        public IActionResult Show([FromBody] Product newProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB db = new ContextDB())
            {
                newProduct.id_product = Guid.NewGuid();
                db.Add(newProduct);
                db.SaveChanges();
            }
            return Ok();

        }

        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            using (ContextDB db = new ContextDB())
            {
                var ProductList = db.product.ToList();
                return Ok(ProductList);
            }

        }
        
        [Route("ShowView/[controller]")]
        [HttpGet]
        public async Task<IActionResult> ShowViewAsync()
        {
            using (ContextDB db = new ContextDB())
            {



                var stockList = await db.product
               .Include(s => s.category) // включение данных из таблицы Product
               .ToListAsync();



                var stockViewModelList = stockList.Select(s => new ProductViewModel
                {
                    id_product = s.id_product,
                    name_product = s.name_product,
                    id_category = s.category.id_category,
                    name_category = s.category.name_category,
                    price = s.price

                }).ToList();




               
                return Ok(stockViewModelList);
            }
        }



        [Route("Dell/[controller]")]
        [HttpDelete]
        public IActionResult DeleteProductByID(Guid id_product)
        {
            using (ContextDB db = new ContextDB())
            {
                Product data = db.product.Find(id_product);
                if (data != null)
                {
                    db.product.Remove(data);
                }


                db.SaveChanges();
                return Ok();
            }


        }

        [Route("Update/[controller]")]
        [HttpPut]
        public IActionResult UpdateProduct([FromBody] Product UpdateProduct)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            using (ContextDB db = new ContextDB())
            {
                var FindProduct = db.product.Find(UpdateProduct.id_product);

                if (FindProduct == null)
                {
                    return NotFound();
                }



                if (UpdateProduct.name_product != "string") FindProduct.name_product = UpdateProduct.name_product;

                if (UpdateProduct.price != 0) FindProduct.price = UpdateProduct.price;

                if (UpdateProduct.description != "string") FindProduct.description = UpdateProduct.description;

                if (UpdateProduct.id_category.ToString() != "3fa85f64-5717-4562-b3fc-2c963f66afa6")



                    FindProduct.id_category = UpdateProduct.id_category;
                db.Update(FindProduct);
                db.SaveChanges();
            }
            return Ok();
        }
    }



}


