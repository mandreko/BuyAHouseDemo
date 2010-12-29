using System;
using System.Linq;
using System.Web.Mvc;
using BuyAHouse.Contracts;
using BuyAHouse.Models;

namespace BuyAHouse.Controllers
{
    public class OfferController : Controller
    {
        readonly Data.BuyAHouseDataEntitiesContainer _db = new Data.BuyAHouseDataEntitiesContainer();

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(OfferModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }


            var proxy = new OfferService.ServiceClient();
            var response = proxy.SubmitOffer(new SubmitOfferRequest
                                                 {
                                                     RequestId = Guid.NewGuid(),
                                                     Offer = new Offer
                                                                 {
                                                                     Amount = model.Amount,
                                                                     BuyerName = model.BuyerName,
                                                                     EmailAddress = model.EmailAddress,
                                                                 }
                                                 });


            ViewData["ResponseText"] = response.ResponseText;

            return View("Thanks");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            Data.Offer offer = _db.Offers.Single(o => o.OfferId == id);

            OfferModel model = new OfferModel
                                   {
                                       Amount = offer.Amount,
                                       BuyerName = offer.BuyerName,
                                       EmailAddress = offer.EmailAddress,
                                   };

            return View(model);
        }

        [HttpPost]
        public ActionResult Details(int id, string accept)
        {
            var proxy = new OfferService.ServiceClient();

            try
            {
                var result = new SellerAcceptanceResult
                                     {
                                         OfferId = id,
                                         Accept = (accept == "Yes"),
                                     };

                proxy.SellerAcceptanceCompleted(result);

                proxy.Close();
            }
            catch (Exception)
            {
                proxy.Abort();
                throw;
            }

            //TODO: Build this property from resources
            ViewData["ResponseText"] = "Thank you for your submission";

            return View("Thanks");
        }

    }
}
