using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApi2.Model
{
    public class Category
    {
        [Key]
        public Guid id_category { get; set; } = Guid.NewGuid();

        public string name_category { get; set; } = null!;

       
    }
}
