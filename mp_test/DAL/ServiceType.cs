using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class ServiceType
    {
        public ServiceType()
        {
            
        }

        public ServiceType(int id, string title, ServiceCathegory cathegory)
        {
            Id = id;
            Title = title;
            ServiceCathegory = cathegory;
        }

        public int Id { get; set; }
        public string Title { get; set; }
        public ServiceCathegory ServiceCathegory { get; set; }
    }
}