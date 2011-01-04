using System.Runtime.Serialization;

namespace BuyAHouse.Contracts
{
    [DataContract(Namespace = "http://buyahouse.com/contracts")]
    public class Offer
    {
        [DataMember(IsRequired = true)]
        public int? OfferId { get; set; }

        [DataMember(IsRequired = true)]
        public int PropertyId { get; set; }

        [DataMember(IsRequired = true)]
        public decimal Amount { get; set; }

        [DataMember(IsRequired = true)]
        public string BuyerName { get; set; }

        [DataMember(IsRequired = true)]
        public string EmailAddress { get; set; }

        [DataMember(IsRequired = true)]
        public OfferResponse Response { get; set; }
    }
}
