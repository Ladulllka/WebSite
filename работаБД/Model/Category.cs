using System.ComponentModel.DataAnnotations;

namespace WarehouseApi2.Model
{
    public class Category
    {
        [Key]
        public int id_category { get; set; }

        public string name_category { get; set; } = null!;

       
    }
}
