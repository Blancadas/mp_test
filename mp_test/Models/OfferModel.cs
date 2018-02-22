using mp_test.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mp_test.Models
{
  public class OfferModel
  {
    public OfferModel()
    {
      order = new OrderModel();
      executor = new Executor();
    }

    public int Id { get; set; }
    public string description { get; set; }
    public OrderModel order { get; set; }
    public Executor executor { get; set; }
    public string offerStatus { get; set; }

  }

  public class OfferListModel
  {
    public OfferListModel()
    {
      order = new Order();
      offers = new List<OfferModel>();
    }

    public Order order { get; set; }
    public List<OfferModel> offers { get; set; }
  }
}