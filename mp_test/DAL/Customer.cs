using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace mp_test.DAL
{
    public class Customer 
    {
        public Customer()
        {
            OrderList = new HashSet<Order>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public ICollection<Order> OrderList { get; set; }

    }
}