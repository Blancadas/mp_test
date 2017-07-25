using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.Models
{
    public class OfferModel
    {
        public OfferModel()
        {
            order = new OrderModel();
        }

        public string description { get; set; }
        public OrderModel order { get; set; }
    }
}