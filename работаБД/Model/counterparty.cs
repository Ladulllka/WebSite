using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApi2.Model
{
    public class Counterparty
    {
        [Key]

         public Guid id_counterparty { get; set; }
        public string? name_counterparty { get; set; }
        
        public string? phone { get; set; }
    }
}
