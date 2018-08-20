using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Orders_API.Models;
using Orders_API.ViewModels;
using Orders_API.Interfaces;

namespace Orders_API.Controllers
{
    public class OrderWebController : Controller
    {
        orderdbEntities db = new orderdbEntities();        
        // GET: OrderWeb
        public ActionResult Orders()
        {
            OrdersViewModel ordersViewModel = new OrdersViewModel();
            ISalesService ss = new SalesService();
            List<Sales> sales = ss.GetSales();
            ordersViewModel.LoadData(db, sales);
            return View(ordersViewModel);
        }

        public ActionResult NewOrder()
        {

            return View();
        }

        [HttpPost]
        public ActionResult NewOrder(Order order)
        {
            return View();
        }
    }
}