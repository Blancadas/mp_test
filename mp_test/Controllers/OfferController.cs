using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mp_test.Models;
using mp_test.DAL;

namespace mp_test.Controllers
{
  public class OfferController : Controller
  {
    public int ordersDone;

    // GET: Offer
    public ActionResult Index()
    {
      return View();
    }

    public ActionResult CreateOffer(int orderId)
    {
      OfferModel newOffer = new OfferModel();
      newOffer.order.orderId = orderId;

      return View(newOffer);
    }

    public ActionResult OffersByOrder(int orderId)
    {
      var curOfferListModel = new OfferListModel();

      using (MPContext dbContext = new MPContext())
      {
        var curOrder = dbContext.Order.Include("ServiceType")
          .Include("ServiceType.ServiceCathegory")
          .Include("OrderCurrency")
          .First(order => order.Id == orderId);

        curOfferListModel.order = curOrder;

        var offerList = dbContext.Offer.Include("Executor").Where(offer => offer.Order.Id == orderId);
        
        foreach (var offer in offerList)
        {
          OfferModel mOffer = new OfferModel();
          mOffer.Id = offer.Id;
          mOffer.executor = offer.Executor;
          mOffer.description = offer.Description;

          var tracking = dbContext.OfferTracking.Include("Status").Where(o => o.Offer.Id == offer.Id).OrderByDescending(o => o.Id);

          var offerStatus = tracking.FirstOrDefault();

          if (offerStatus != null)
          {
            mOffer.offerStatus = offerStatus.Status.Title;
            curOfferListModel.offers.Add(mOffer);
          }
        }
      }

      return View("OffersByOrder", curOfferListModel);
    }

    public ActionResult OfferAcceptanceForm(int offerId)
    {
      ViewBag.ordersDone = 0;

      var curOfferModel = new OfferModel();

      using (MPContext dbContext = new MPContext())
      {
        var curOffer = dbContext.Offer.Include("Executor").First(offer => offer.Id == offerId);
        curOfferModel.executor.Title = curOffer.Executor.Title;
        curOfferModel.description = curOffer.Description;
        curOfferModel.executor.Rating = curOffer.Executor.Rating;
      }

      return View("OfferAcceptanceForm", curOfferModel);
    }

    public ActionResult AcceptOffer(int offerId)
    {
      using (MPContext dbContext = new MPContext())
      {
        var curOffer = dbContext.Offer.Include("Executor").First(offer => offer.Id == offerId);

        OfferTracking newOfferTracking = new OfferTracking();
        newOfferTracking.Offer = curOffer;
        newOfferTracking.Created = DateTime.Now;
        newOfferTracking.Status = new OfferStatus("Accepted");
        dbContext.OfferTracking.Add(newOfferTracking);

        dbContext.SaveChanges();

      }

      return RedirectToAction("ShowMyOrders", "Orders");
    }
  }
}
