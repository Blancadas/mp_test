using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class Offer
    {
        public int Id { get; set; }
        public Executor Executor { get; set; }
        public string Description { get; set; }
        public Order Order { get; set; }
        
    }
}