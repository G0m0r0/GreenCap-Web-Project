namespace GreenCap.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using GreenCap.Data.Common;
    using GreenCap.Data.Common.Models;

    public class Event : BaseDeletableModel<int>
    {
        public Event()
        {
            this.UserEventsHosts = new HashSet<UserEventHosts>();
            this.UserEventSignedIn = new HashSet<UserEventSignedIn>();
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

        public int NeededPeople => (this.TotalPeople - this.UserEventSignedIn.Count) > 0 ? (this.TotalPeople - this.UserEventSignedIn.Count) : 0;

        public virtual ICollection<UserEventHosts> UserEventsHosts { get; set; }

        public virtual ICollection<UserEventSignedIn> UserEventSignedIn { get; set; }
    }
}
