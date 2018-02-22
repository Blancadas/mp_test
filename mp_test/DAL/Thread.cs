using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class Thread
    {
        public int Id { get; set; }
        public string AuthorId { get; set; }
        public string RecepientId { get; set; }
        public Offer Offer { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}