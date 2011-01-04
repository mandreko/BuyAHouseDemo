using System.Runtime.Serialization;

namespace BuyAHouse.Contracts
{
    [DataContract(Namespace = "http://buyahouse.com/contracts")]
    public class SubmitOfferResponse
    {
        [DataMember(IsRequired = true)]
        public Offer Offer { get; set; }

        [DataMember(IsRequired = true)]
        public string ResponseText { get; set; }
    }
}
