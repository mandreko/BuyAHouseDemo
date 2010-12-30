using System;
using System.Runtime.Serialization;

namespace BuyAHouse.Contracts
{
    [DataContract(Namespace="http://buyahouse.com/contracts")]
    public class SubmitOfferRequest
    {
        [DataMember(IsRequired = true)]
        public Guid RequestId { get; set; }

        [DataMember(IsRequired = true)]
        public int PropertyId { get; set; }

        [DataMember(IsRequired = true)]
        public Offer Offer { get; set; }
        
        [DataMember(IsRequired = true)]
        public OfferAcceptanceResult Result { get; set; }
    }
}
