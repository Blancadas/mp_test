using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class Currency
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public Currency()
        {
            
        }

        public Currency(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}