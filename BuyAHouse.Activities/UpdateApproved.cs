using System;
using System.Activities;
using System.Linq;

namespace BuyAHouse.Activities
{
    public class UpdateApproved : CodeActivity
    {
        public InArgument<bool> Approved { get; set; }
        public InArgument<int> OfferId { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            using (Data.BuyAHouseDataEntitiesContainer ctx = new Data.BuyAHouseDataEntitiesContainer())
            {
                bool result = Approved.Get(context);
                int offerId = OfferId.Get(context);

                var offer = ctx.Offers.Single(o => o.OfferId == offerId);
                offer.Accepted = result;

                ctx.SaveChanges();
            }
        }
    }
}
