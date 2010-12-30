using System;
using System.Activities;
using System.Net.Mail;
using System.Web.Configuration;
using BuyAHouse.Contracts;

namespace BuyAHouse.Activities
{
    public class NotifySeller : CodeActivity
    {
        public InArgument<int> OfferId { get; set; }
        public InArgument<SubmitOfferRequest> OfferRequest { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            string baseUri = WebConfigurationManager.AppSettings["BaseURI"];
            string serverEmail = WebConfigurationManager.AppSettings["ServerEmail"];
            string sellerEmail = WebConfigurationManager.AppSettings["SellerEmail"];

            #region Validation

            if (string.IsNullOrEmpty(baseUri))
            {
                throw new InvalidOperationException("No BaseURI appSetting found in web.config");
            }
            if (string.IsNullOrEmpty(serverEmail))
            {
                throw new InvalidOperationException("No ServerEmail appSetting found in web.config");
            }
            if (string.IsNullOrEmpty(sellerEmail))
            {
                throw new InvalidOperationException("No SellerEmail appSetting found in web.config");
            }

            #endregion

            SmtpClient smtpClient = new SmtpClient();

            string buyer = OfferRequest.Get(context).Offer.BuyerName;

            string htmlMailText = string.Format(ServiceResources.OfferMadeToSeller, buyer, OfferId.Get(context), baseUri);

            MailMessage message = new MailMessage(
                serverEmail, 
                sellerEmail, 
                string.Format(ServiceResources.OfferProcessingSubject, buyer), 
                htmlMailText) { IsBodyHtml = true };

            smtpClient.Send(message);
        }
    }
}
