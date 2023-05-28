using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace WarehouseApi2.Model
{
    public partial class Warehouse
    {
        [Key]
        public Guid id_warehouse { get; set; }
        public string name_warehouse { get; set; } = null!;

        public string address_warehouse { get; set; } = null!;

    }
}
