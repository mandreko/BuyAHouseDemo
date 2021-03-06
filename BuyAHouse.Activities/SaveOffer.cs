﻿using System.Activities;
using BuyAHouse.Contracts;


namespace BuyAHouse.Activities
{
    public class SaveOffer : CodeActivity<SubmitOfferResponse>
    {
        // This InArgument allows another property to be shown when right-clicking on an activity item and clicking "Properties"
        public InArgument<SubmitOfferRequest> OfferRequest { get; set; }

        protected override SubmitOfferResponse Execute(CodeActivityContext context)
        {
            using (var ctx = new Data.BuyAHouseDataEntitiesContainer())
            {
                var request = OfferRequest.Get(context);
                var offer = new Data.Offer
                                {
                                    Amount = request.Offer.Amount,
                                    BuyerName = request.Offer.BuyerName,
                                    EmailAddress = request.Offer.EmailAddress,
                                    RequestId = request.RequestId,

                                };

                ctx.Offers.AddObject(offer);

                ctx.SaveChanges();

                return new SubmitOfferResponse
                           {
                               BuyerName = request.Offer.BuyerName,
                               OfferId = offer.OfferId,
                               ResponseText = string.Format(ServiceResources.OfferProcessing, request.Offer.BuyerName, offer.OfferId),
                           };
            }
        }
    }
}
