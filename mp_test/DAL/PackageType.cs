using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
    public class PackageType
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public PackageCathegory PackageCathegory { get; set; }
    }
}