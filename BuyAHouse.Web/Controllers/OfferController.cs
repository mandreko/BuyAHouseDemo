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
        public ActionResult Index(int id)
        {
            var property = (from p in _db.Properties
                            where p.PropertyId == id
                            select new PropertyModel
                                       {
                                           PropertyId = p.PropertyId,
                                           Address = p.Address,
                                       }).Single();

            var model = new OfferModel
                            {
                                Address = property.Address,
                                Amount = 0,
                                BuyerName = string.Empty,
                                EmailAddress = string.Empty,
                                PropertyId = property.PropertyId,
                            };


            return View(model);
        }

        [HttpPost]
        public ActionResult Index(OfferModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Error");
            }

            var proxy = new OfferService.ServiceClient();
            var response = proxy.BuyerOffer(new SubmitOfferRequest
                                                 {
                                                     RequestId = Guid.NewGuid(),
                                                     Offer = new Offer
                                                                 {
                                                                     PropertyId = model.PropertyId,
                                                                     Amount = model.Amount,
                                                                     BuyerName = model.BuyerName,
                                                                     EmailAddress = model.EmailAddress,
                                                                     Response = OfferResponse.Counter,
                                                                 },
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
                                       PropertyId = offer.PropertyId,
                                       Amount = offer.Amount,
                                       BuyerName = offer.BuyerName,
                                       EmailAddress = offer.EmailAddress,
                                   };

            return View(model);
        }

        [HttpPost]
        public ActionResult Details(int id, string accept, string amount)
        {
            if (string.IsNullOrEmpty(accept))
                throw new ArgumentNullException("accept", @"accept can not be null");

            decimal amountDecimal;
            if (!decimal.TryParse(amount, out amountDecimal))
                throw new ArgumentOutOfRangeException("amount");

            Data.Offer offer = _db.Offers.Single(o => o.OfferId == id);

            var proxy = new OfferService.ServiceClient();

            try
            {
                var result = new SubmitOfferRequest
                                 {
                                     Offer = new Offer
                                                 {
                                                     Amount = amountDecimal,
                                                     BuyerName = offer.BuyerName,
                                                     EmailAddress = offer.EmailAddress,
                                                     PropertyId = offer.PropertyId,
                                                     Response = (OfferResponse) Enum.Parse(typeof (OfferResponse), accept),
                                                 }
                                 };

                proxy.SellerOffer(result);

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
