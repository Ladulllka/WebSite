using System.ComponentModel.DataAnnotations;

namespace WarehouseApi2.Model
{
    public class counterparty
    {
        [Key]
        public int id_counterparty { get; set; }
        public string? name_counterparty { get; set; }
        
        public string? phone { get; set; }
    }
}
