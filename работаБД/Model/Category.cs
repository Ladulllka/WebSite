using System.ComponentModel.DataAnnotations;

namespace WarehouseApi2.Model
{
    public class Category
    {
        [Key]
        public int IdCategory { get; set; }

        public string NameCategory { get; set; } = null!;

       
    }
}
