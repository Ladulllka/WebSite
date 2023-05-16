using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WarehouseApi2.Model
{
    public partial class Warehouse
    {
        [Key]
        public int IdWarehouse { get; set; }

        public string NameWarehouse { get; set; } = null!;

        public string AddressWarehouse { get; set; } = null!;

      

    
    }
}
