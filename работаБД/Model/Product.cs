using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApi2.Model
{
    public class Product
    {

        [Key]
        public int IdProduct { get; set; }

        public string NameProduct { get; set; } = null!;

        public string? Description { get; set; }

        public decimal Price { get; set; }
        [ForeignKey("category")]
        public int? IdCategory { get; set; }

        


    }

}

