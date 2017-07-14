using mp_test.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mp_test.Models;

namespace mp_test.Controllers
{
    public class OrdersController : Controller
    {
        // GET: Orders
        public ActionResult Index()
        {
            var orderList = new OrderListModel();
            using (MPContext dbContext = new MPContext())
            {
                //IQueryable<Order> query = dbContext.Order.Include("ServiceType");
                foreach (var order in dbContext.Order.Include("ServiceType").Include("OrderCurrency"))
                {
                    orderList.Orders.Add(order);
                }
            }
            return View(orderList);
        }
    }
}