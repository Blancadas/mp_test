using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using mp_test.DAL;

namespace mp_test.Models
{
    public class OrderListModel 
    {
        public OrderListModel()
        {
            Orders = new List<Order>();
        }
        public List<Order> Orders { get; set; }
    }

    public class OrderWithOffersListModel
    {
        public OrderWithOffersListModel()
        {
            Orders = new List<OrderWithOffers>();
        }
        public List<OrderWithOffers> Orders { get; set; }
    }
}