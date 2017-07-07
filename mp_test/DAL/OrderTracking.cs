using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class OrderTracking
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public Order Order { get; set; }
        public OrderStatus Status { get; set; }
    }
}