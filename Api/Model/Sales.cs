using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApi2.Model
{
    public class Sales
    {
        [Key]
        public Guid id_sales { get; set; }
        [ForeignKey("Product")]
        public Guid id_product { get; set; }
        [ForeignKey("Warehouse")]
        public Guid id_warehouse { get; set; }

        [ForeignKey("Counterparty")]
        public Guid? id_counterparty { get; set; }

        public int quanity { get; set; }

        public double cost { get; set; }

        public double total { get; set; }

        //public virtual int NewIndex() // метод определения нового перчивного ключа для таблицы Carryng
        //{
        //    using (ContextDB db = new ContextDB())
        //    {
        //        int Max = -1;
        //        var SalesList = db.sales.ToList();
        //        Console.WriteLine("MAX:");
        //        foreach (Sales p in SalesList)
        //        {
        //            if (p.id_sales > Max) Max = p.id_sales;
        //        }
        //        return (Max + 1);
        //    }
        //}
        //public virtual void AddNew(int idCounterparty, int idProduct, int idWarehouse, int quanity, int cost) // метод добавления новой записи в таблицу Carryng
        //{

        //    Sales newData = new Sales();
        //    newData.id_counterparty = idCounterparty;
        //    newData.id_sales = newData.NewIndex();
        //    newData.id_product = idProduct;
        //    newData.id_warehouse = idWarehouse;
        //    newData.quanity = quanity;
        //    newData.cost = cost;
        //    using (ContextDB db = new ContextDB())
        //    {
        //        db.Add(newData);
        //        db.SaveChanges();
        //    }
        //}

        public virtual List<Sales> GetAll() //метод вывода всей таблицы Carryng
        {
            using (ContextDB db = new ContextDB())
            {
                return db.sales.ToList();
            }
        }

        public virtual void DeleteById(int id_sales) // метод удаления записи в таблицы Carryng по ID
        {
            using (ContextDB db = new ContextDB())
            {
                Sales data = db.sales.Find(id_sales);
                if (data != null)
                {
                    db.sales.Remove(data);
                    db.SaveChanges();
                }
            }
        }
    }
}
