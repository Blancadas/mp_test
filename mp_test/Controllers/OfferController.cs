using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mp_test.Models;

namespace mp_test.Controllers
{
    public class OfferController : Controller
    {
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
    }
}