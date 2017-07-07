using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class ServiceTracking
    {
        public int Id { get; set; }
        public Executor Executor { get; set; }
        public Order Order { get; set; }
        public DateTime Created { get; set; }
        public ServiceType ServiceType { get; set; }
        public ServiceStatus ServiceStatus { get; set; }
    }
}