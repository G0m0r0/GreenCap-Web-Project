namespace GreenCap.Data.Models
{
    using GreenCap.Data.Common.Models;
    using System.ComponentModel.DataAnnotations.Schema;

    public class UserEventHosts : BaseDeletableModel<int>
    {
        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public Event Event { get; set; }

        [ForeignKey(nameof(Event))]
        public int EventId { get; set; }

    }
}
