using mp_test.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mp_test.Models;
using Microsoft.AspNet.Identity;

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

        public ActionResult ShowOrder(int Id)
        {
            var curOrderModel = new OrderModel();

            using (MPContext dbContext = new MPContext())
            {
                var curOrder = dbContext.Order.Include("ServiceType").Include("ServiceType.ServiceCathegory").Include("OrderCurrency").First(order => order.Id == Id);

                curOrderModel.orderId = curOrder.Id;
                curOrderModel.cathegoryId = curOrder.ServiceType.ServiceCathegory.Id;
                curOrderModel.cathegoryTitle = curOrder.ServiceType.ServiceCathegory.Title;
                curOrderModel.orderTitle = curOrder.Title;
                curOrderModel.sourceAddress = curOrder.SourceAddress;
                curOrderModel.destinationAddress = curOrder.DestinationAddress;
                curOrderModel.orderDueDateTime = curOrder.OrderDueDateTime;
                curOrderModel.orderCost = curOrder.OrderCost;
                curOrderModel.orderCurrency = curOrder.OrderCurrency;
            }

            return View("Order", curOrderModel);
        }

        public ActionResult ShowMyOrders()
        {
            var myOrdersModel =  new OrderWithOffersListModel();
            var orderToPush = new OrderWithOffers(); 

            using (MPContext dbContext = new MPContext())
            {
                var currentUserId = User.Identity.GetUserId();

                var currentCustomer = dbContext.Customer.Include("OrderList").FirstOrDefault(cust => cust.UserId == currentUserId);

                if (currentCustomer != null)
                {
                    foreach (var order in currentCustomer.OrderList)
                    {
                        var offers = dbContext.Offer.Include("Order").Where(offer => offer.Order.Id == order.Id);

                        orderToPush.Id = order.Id;
                        orderToPush.ServiceType = order.ServiceType;
                        orderToPush.Title = order.Title;
                        orderToPush.SourceAddress = order.SourceAddress;
                        orderToPush.DestinationAddress = order.DestinationAddress;
                        orderToPush.OrderDueDateTime = order.OrderDueDateTime;
                        orderToPush.OrderCost = order.OrderCost;
                        orderToPush.OrderCurrency = order.OrderCurrency;
                        orderToPush.Offers = offers.ToList();

                        myOrdersModel.Orders.Add(orderToPush);
                    }

                }


                return View("MyOrders", myOrdersModel);
            }

        }

        [HttpPost]
        public ActionResult TakeOrder(int Id, FormCollection form)
        {
            var curOrderModel = new OrderModel();

            using (MPContext dbContext = new MPContext())
            {
                var currentUserId = User.Identity.GetUserId();

                var curOrder = dbContext.Order.Include("ServiceType").Include("ServiceType.ServiceCathegory").Include("OrderCurrency").First(order => order.Id == Id);

                var curExecutor = dbContext.Executor.FirstOrDefault(ex => ex.UserId == currentUserId);

                var newCreatedStatus = dbContext.OfferStatuse.FirstOrDefault(s => s.Title == "Created");

                string descriptionText = form["description"];

                Offer newOffer = new Offer();
                newOffer.Order = curOrder;
                newOffer.Description = descriptionText;
                newOffer.Executor = curExecutor;
                dbContext.Offer.Add(newOffer);
                dbContext.SaveChanges();

                OfferTracking newCreatedTracking = new OfferTracking();
                newCreatedTracking.Status = newCreatedStatus;
                newCreatedTracking.Created = DateTime.Now;
                newCreatedTracking.Offer = newOffer;
                dbContext.OfferTracking.Add(newCreatedTracking);
                dbContext.SaveChanges();

                //curOrderModel.cathegoryId = curOrder.ServiceType.ServiceCathegory.Id;
                //curOrderModel.cathegoryTitle = curOrder.ServiceType.ServiceCathegory.Title;
                //curOrderModel.orderTitle = curOrder.Title;//curOrderModel.sourceAddress = curOrder.SourceAddress;
                //curOrderModel.destinationAddress = curOrder.DestinationAddress;
                //curOrderModel.orderDueDateTime = curOrder.OrderDueDateTime;
                //curOrderModel.orderCost = curOrder.OrderCost;
                //curOrderModel.orderCurrency = curOrder.OrderCurrency;
            }

            return View("Order", curOrderModel);
        }
    }
}