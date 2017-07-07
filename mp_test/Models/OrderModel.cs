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
        }
        public string orderTitle { get; set; }
        public int cathegoryId { get; set; }
        public int typeId { get; set; }
        public List<ServiceCathegory> orderCathegoryList { get; set; }
        public List<ServiceType> orderTypeList { get; set; }

        [DataType(DataType.MultilineText)]
        public string orderDescription { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public DateTime? OrderDueDateTime { get; set; }

        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string ContactTitle { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public decimal? OrderCost { get; set; }
        public Currency OrderCurrency { get; set; }

        public HttpPostedFileBase uploadedFile { get; set; }
    }
}