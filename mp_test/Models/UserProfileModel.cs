using mp_test.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.Models
{
    public class UserProfileModel
    {
        public UserProfileModel()
        {
            executor = new Executor();
        }
        public Executor executor { get; set; }
    }
}