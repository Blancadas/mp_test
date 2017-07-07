using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class ServiceCathegory
    {
        public ServiceCathegory()
        {
            
        }

        public ServiceCathegory(int id, string title)
        {
            Id = id;
            Title = title;
        }

        public int Id { get; set; }
        public string Title { get; set; }
    }
}