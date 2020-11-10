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
        }

        [Required]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [MaxLength(DataValidation.Events.Description)]
        public string Description { get; set; }

        public DateTime EndDate { get; set; }

        public virtual ApplicationUser HostedBy { get; set; }

        [ForeignKey(nameof(HostedBy))]
        public string HostId { get; set; }

        [Required]
        public int TotalNeededPeople { get; set; }

        public int NeededPeople => (this.TotalNeededPeople - this.UserEvents.Count) > 0 ? (this.TotalNeededPeople - this.UserEvents.Count) : 0;

        // public virtual Address Address { get; set; }
        // [ForeignKey(nameof(Address))]
        // public int AddressId { get; set; }
        public virtual ICollection<UserEvent> UserEvents { get; set; }
    }
}
