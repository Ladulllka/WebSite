using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApi2.Model
{
    public class Product
    {

        [Key]
        public int id_product { get; set; }

        public string name_product { get; set; } = null!;

        public string? description { get; set; }

        public decimal price { get; set; }
        [ForeignKey("category")]
        public int? id_category { get; set; }

        


    }

}

