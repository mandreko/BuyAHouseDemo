using System;
using System.Activities;
using System.Net.Mail;
using System.Web.Configuration;
using BuyAHouse.Contracts;

namespace BuyAHouse.Activities
{
    public class NotifyBuyer : CodeActivity
    {
        public InArgument<OfferResponse> Response { get; set; }
        public InArgument<Offer> Offer { get; set; }

        protected override void Execute(CodeActivityContext context)
        {
            OfferResponse approve = Response.Get(context);
            Offer offer = Offer.Get(context);
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

            string htmlMailText;

            switch(approve)
            {
                case OfferResponse.Accept:
                    htmlMailText = string.Format(ServiceResources.GenericMailTemplate,
                                             ServiceResources.OfferAcceptedHeading,
                                             string.Format(ServiceResources.OfferAcceptedText, offer.BuyerName),
                                             baseUri);
                    break;
                case OfferResponse.Deny:
                    htmlMailText = string.Format(ServiceResources.GenericMailTemplate,
                                             ServiceResources.OfferDeniedHeading,
                                             string.Format(ServiceResources.OfferDeniedText, offer.BuyerName),
                                             baseUri);
                    break;
                default:
                    htmlMailText = string.Format(ServiceResources.GenericMailTemplate,
                                             ServiceResources.OfferCounteredHeading,
                                             string.Format(ServiceResources.OfferCounteredText, offer.BuyerName),
                                             
                                             baseUri);
                    break;

            }
            
            SmtpClient smtpClient = new SmtpClient();

            MailMessage message = new MailMessage(
               serverEmail,
               offer.EmailAddress,
               string.Format(ServiceResources.OfferProcessingSubject, offer.BuyerName),
               htmlMailText) { IsBodyHtml = true };

            smtpClient.Send(message);
        }
    }
}
