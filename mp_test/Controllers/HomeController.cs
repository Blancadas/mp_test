using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mp_test.DAL;
using mp_test.Models;

namespace mp_test.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            using (var ctx = new MPContext())
            {
                var cust = new Customer();
                cust.Title = "New customer";

                //ctx.Customer.Add(cust);
                //ctx.SaveChanges();
                
                //// Display all Blogs from the database 
                //var query = from b in ctx.Customer
                //            orderby b.Title
                //            select b;

                //Console.WriteLine("All blogs in the database:");
                //foreach (var item in query)
                //{
                //    var test = item.Title;
                //}
            }

            return View();
        }

        [HttpPost]
        public ActionResult GoOrder(FormCollection form)
        {
            var orderTitle = form["orderTitle"].ToString();

            OrderModel newOrder = new OrderModel();
            newOrder.orderTitle = orderTitle;

            using (var ctx = new MPContext())
            {
                var query = from cathegory in ctx.ServiceCathegory
                            orderby cathegory.Id
                    select cathegory;


                foreach (var item in query)
                {
                    var cathegoryId = item.Id;
                    var cathegoryTitle = item.Title;

                    ServiceCathegory newCat = new ServiceCathegory(cathegoryId, cathegoryTitle);
                    newOrder.orderCathegoryList.Add(newCat);
                }

                var typeQuery = from type in ctx.ServiceType
                    orderby type.Title
                    select type;

                foreach (var typeItem in typeQuery)
                {
                    ServiceType newType = new ServiceType(typeItem.Id, typeItem.Title, typeItem.ServiceCathegory);
                    newOrder.orderTypeList.Add(newType);
                }

                var currencyQuery = from currency in ctx.Currency
                    orderby currency.Title
                    select currency;

                foreach (var currencyItem in currencyQuery)
                {
                    Currency newCurrency = new Currency(currencyItem.Id, currencyItem.Title);
                    newOrder.currencyList.Add(newCurrency);
                }
            }

            return View(newOrder);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            return View();
        }

        [HttpPost]
        public ActionResult SubmitOrder(OrderModel order)
        {
            if (ModelState.IsValid)
            {
                using (MPContext dbContext = new MPContext())
                {
                    dbContext.Order.Add(order.GetOrderInfo(dbContext));
                    dbContext.SaveChanges();
                }

                return RedirectToAction("Index", "Orders");
            }

            return View("GoOrder", order);
        }
    }
}