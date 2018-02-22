using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using mp_test.DAL;

namespace mp_test.Models
{
    public class OrderModel
    {
        public OrderModel()
        {
            orderCathegoryList = new List<ServiceCathegory>();
            orderTypeList = new List<ServiceType>();
            currencyList = new List<Currency>();
        }

        public int orderId { get; set; }

        [Required]
        [Display(Name = "Order title")]
        public string orderTitle { get; set; }
        public int cathegoryId { get; set; }
        public string cathegoryTitle { get; set; }
        public int typeId { get; set; }
        public List<ServiceCathegory> orderCathegoryList { get; set; }
        public List<ServiceType> orderTypeList { get; set; }
        public List<Currency> currencyList { get; set; }

        [DataType(DataType.MultilineText)]
        public string orderDescription { get; set; }
        public DateTime? orderDateTime { get; set; }
        public DateTime? orderDueDateTime { get; set; }

        public string sourceAddress { get; set; }
        public string destinationAddress { get; set; }
        public string contactTitle { get; set; }
        public string contactEmail { get; set; }
        public string contactPhoneNumber { get; set; }
        public decimal? orderCost { get; set; }
        public Currency orderCurrency { get; set; }
        public int currencyId { get; set; }

        public HttpPostedFileBase uploadedFile { get; set; }

        public Order GetOrderInfo(MPContext mpContext)
        {
            Order newOrder = new Order();

            newOrder.Title = orderTitle;
            newOrder.Description = orderDescription;
            newOrder.OrderDateTime = orderDateTime;
            newOrder.OrderDueDateTime = orderDueDateTime;

            //ServiceCathegory selectedCathegory = mpContext.ServiceCathegory.Single(c => c.Id == cathegoryId);
            ServiceType selectedType = mpContext.ServiceType.First(c => c.Id == typeId);

            //mpContext.ServiceType.Attach(selectedType);
            newOrder.ServiceType = selectedType;

            newOrder.SourceAddress = sourceAddress;
            newOrder.DestinationAddress = destinationAddress;
            newOrder.ContactTitle = contactTitle;
            newOrder.ContactEmail = contactEmail;
            newOrder.ContactPhoneNumber = contactPhoneNumber;
            newOrder.OrderCost = orderCost;

            Currency selectedCurrency = mpContext.Currency.Single(c => c.Id == currencyId);
            //mpContext.Currency.Attach(selectedCurrency);
            newOrder.OrderCurrency = selectedCurrency;

            return newOrder;
        }
    }
}