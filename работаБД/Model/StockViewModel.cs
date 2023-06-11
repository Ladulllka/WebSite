namespace WarehouseApi2.Model
{
 
   public class StockViewModel
    {
        public Guid WarehouseID { get; set; }

        public Guid ProductID { get; set; }
        public string? ProductName { get; set; }
        public string? WarehouseName { get; set; }
        public int? Quantity { get; set; }

       
    }

}
 