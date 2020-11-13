namespace GreenCap.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common.Models;

    public class UserLike
    {
        public virtual Post Post { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }

        public bool IsPositive { get; set; }
    }
}
