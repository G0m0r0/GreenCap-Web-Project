namespace GreenCap.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    public class GreenCapUser
    {
        public GreenCapUser()
            : base()
        {
            this.Posts = new HashSet<Post>();
            this.UserComments = new HashSet<UserComment>();
            this.Ideas = new HashSet<Proposal>();
            this.UserLikes = new HashSet<UserLike>();
            this.UserEvents = new HashSet<UserEvent>();
        }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<UserComment> UserComments { get; set; }

        public virtual ICollection<Proposal> Ideas { get; set; }

        public virtual ICollection<UserLike> UserLikes { get; set; }

        public virtual ICollection<UserEvent> UserEvents { get; set; }

        public Address Address { get; set; }

        [ForeignKey(nameof(Address))]
        public int AddressId { get; set; }
    }
}
