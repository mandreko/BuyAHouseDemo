using System.Runtime.Serialization;

namespace BuyAHouse.Contracts
{
    [DataContract(Namespace = "http://buyahouse.com/contracts")]
    public class SellerAcceptanceResult
    {
        [DataMember(IsRequired = true)]
        public int OfferId { get; set; }

        [DataMember(IsRequired = true)]
        public bool Accept { get; set; }
    }
}
