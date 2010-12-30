using System.Runtime.Serialization;

namespace BuyAHouse.Contracts
{
    [DataContract(Namespace = "http://buyahouse.com/contracts")]
    public class SubmitOfferResponse
    {
        [DataMember(IsRequired = true)]
        public int PropertyId { get; set; }

        [DataMember(IsRequired = true)]
        public int OfferId { get; set; }

        [DataMember(IsRequired = true)]
        public string BuyerName { get; set; }

        [DataMember(IsRequired = true)]
        public string ResponseText { get; set; }
    }
}
