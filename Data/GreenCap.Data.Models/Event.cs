namespace GreenCap.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common;

    using GreenCap.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        public Event()
        {
            this.UserEvents = new HashSet<UserEvent>();
            this.HostedBy = new HashSet<ApplicationUser>();
        }

        [Required]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        public string Name { get; set; }

        [Required]
        [MaxLength(DataValidation.Events.DescriptionMaxLength)]
        public string Description { get; set; }

        [Required]
        [MaxLength(DataValidation.UrlPathMaxLength)]
        public string ImagePath { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [Required]
        public int TotalPeople { get; set; }

        public int NeededPeople => (this.TotalPeople - this.UserEvents.Count) > 0 ? (this.TotalPeople - this.UserEvents.Count) : 0;

        // public virtual Address Address { get; set; }
        // [ForeignKey(nameof(Address))]
        // public int AddressId { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }

        public virtual ICollection<ApplicationUser> HostedBy { get; set; }
    }
}
