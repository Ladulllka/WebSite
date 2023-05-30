﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WarehouseApi2.Model

{
  
    public class Carryngs
    {
        [Key]
        public Guid id_carryng { get; set; }

        [ForeignKey("Product")]
        public Guid? id_product { get; set; }

        [ForeignKey("Warehouse")]
        public Guid? id_warehouse { get; set; }

        [ForeignKey("Counterparty")]
        public Guid? id_counterparty { get; set; }

        public int quanity { get; set; }

        public double cost { get; set; }


        //public virtual int NewIndex() // метод определения нового перчивного ключа для таблицы Carryng
        //{
        //    using (ContextDB db = new ContextDB())
        //    {
        //        int Max = -1;
        //        var CarryngList = db.carryng.ToList();
        //        Console.WriteLine("MAX:");
        //        foreach (Carryngs p in CarryngList)
        //        {
        //            if (p.id_carryng > Max) Max = p.id_carryng;
        //        }
        //        return (Max + 1);
        //    }
        //}
        //public virtual void AddNew(int idCounterparty, int idProduct, int idWarehouse, int quanity, int cost) // метод добавления новой записи в таблицу Carryng
        //{

        //    Carryngs newData = new Carryngs();
        //    newData.id_counterparty = idCounterparty;
        //    newData.id_carryng = newData.NewIndex();
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

        //public virtual List<Carryngs> GetAll() //метод вывода всей таблицы Carryng
        //{
        //    using (ContextDB db = new ContextDB())
        //    {
        //        return db.carryng.ToList();
        //    }
        //}

        //public virtual void DeleteById(int id_carryng) // метод удаления записи в таблицы Carryng по ID
        //{
        //    using (ContextDB db = new ContextDB())
        //    {
        //        Carryngs data = db.carryng.Find(id_carryng);
        //        if (data != null)
        //        {
        //            db.carryng.Remove(data);
        //            db.SaveChanges();
        //        }
        //    }
        //}


    }
}