using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApi2.Model
{
    public class Stock
    {
        [Key]
        public int id_product { get; set; }
        [ForeignKey("Warehouse")]
        public int id_warehouse { get; set; }

        public int? quanity { get; set; }
    }
}
