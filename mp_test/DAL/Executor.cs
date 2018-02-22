using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace mp_test.DAL
{
  public class Executor
  {
    public Executor()
    {

    }

    public int Id { get; set; }
    public string UserId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public PackageType PackageType { get; set; }
    public int Rating { get; set; }
  }
}