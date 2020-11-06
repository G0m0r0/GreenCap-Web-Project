namespace GreenCap.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common;

    using GreenCap.Data.Common.Models;

    public class Address : BaseDeletableModel<int>
    {
        [MaxLength(DataValidation.Address.CountryName)]
        public string CountryName { get; set; }

        [Required]
        [MaxLength(DataValidation.Address.TownName)]
        public string TownName { get; set; }

        [Required]
        [MaxLength(DataValidation.Address.StreetName)]
        public string StreetName { get; set; }

        public Event Event { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

        // public ApplicationUser User { get; set; }
        // [ForeignKey(nameof(User))]
        // public string UserId { get; set; }
    }
}
