using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class PaymentTracking
    {
        public int Id { get; set; }
        public Executor Executor { get; set; }
        public DateTime PayDateTime { get; set; }
        public PaymentType PaymentType { get; set; }
        public Currency Currency { get; set; }
    }
}