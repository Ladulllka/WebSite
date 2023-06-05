namespace WarehouseApi2.Model
{
 
   public class StockViewModel
    {
        public string ProductName { get; set; }
        public string WarehouseName { get; set; }
        public int? Quantity { get; set; }

        public override string ToString()
        {
            return $"Product: {ProductName}, Warehouse: {WarehouseName}, Quantity: {Quantity}";
        }
    }

}
