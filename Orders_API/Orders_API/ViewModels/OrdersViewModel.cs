using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Orders_API.Models;


namespace Orders_API.ViewModels
{
    public class OrdersViewModel
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        public void LoadData(orderdbEntities db, List<Sales> sales)
        {
            foreach(var x in db.Orders)
            {
                Order o = new Order();
                o.Sales = sales.Find(y => y.Sales_Id == x.SalesID);
                o.mail = x.mail;
                o.OrderDate = x.OrderDate;
                o.phone = x.phone;
                o.SalesID = x.SalesID;
                Orders.Add(o);
            }
        }
    }
}