using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class OfferTracking
    {
        public int Id { get; set; }
        public DateTime Created { get; set; }
        public Offer Offer { get; set; }
        public OfferStatus Status { get; set; }
    }
}