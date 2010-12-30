using System.ComponentModel.DataAnnotations;

namespace BuyAHouse.Models
{
    public class OfferModel
    {
        [Required]
        public int PropertyId { get; set; }

        [Required]
        public string Address { get; set; }

        [Display(Name="Offer Amount")]
        [Required]
        public decimal Amount { get; set; }

        [Display(Name = "Buyer Name")]
        [Required]
        [StringLength(100)]
        public string BuyerName { get; set; }

        [Display(Name = "Email Address")]
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(255)]
        public string EmailAddress { get; set; }
    }
}