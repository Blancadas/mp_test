using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.DAL
{
  public class OfferStatus
  {
    public int Id { get; set; }
    public string Title { get; set; }

    public OfferStatus()
    {
      
    }

    public OfferStatus(string statusName)
    {
      using (MPContext dbContext = new MPContext())
      {
        var curStatus = dbContext.OfferStatus.First(status => status.Title == statusName);
        Id = curStatus.Id;
        Title = curStatus.Title;
      }
    }
  }
}