using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApi2.Model
{
    [PrimaryKey("id_product", "id_warehouse")]
    public class Stock
    {
        public Guid id_product { get; set; }

        public Guid id_warehouse { get; set; }
    
        public int? quanity { get; set; }
        public Product product { get; set; }
        public Warehouse warehouse { get; set; }
        
    }
}