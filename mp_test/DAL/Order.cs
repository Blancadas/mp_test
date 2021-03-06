﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class Order
    {
        public Order()
        {
            ExecutorList = new HashSet<Executor>();
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? OrderDateTime { get; set; }
        public DateTime? OrderDueDateTime { get; set; }
        public ICollection<Executor> ExecutorList { get; set; }
        public virtual ServiceType ServiceType { get; set; }
        public string SourceAddress { get; set; }
        public string DestinationAddress { get; set; }
        public string ContactTitle { get; set; }
        public string ContactEmail { get; set; }
        public string ContactPhoneNumber { get; set; }
        public decimal? OrderCost { get; set; }
        public virtual Currency OrderCurrency { get; set; }

    }

    [NotMapped]
    public class OrderWithOffers : Order
    {
        public OrderWithOffers()
        {
            Offers = new List<Offer>();
        }
        public List<Offer> Offers { get; set; }
    }
}