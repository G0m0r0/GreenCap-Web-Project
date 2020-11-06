namespace GreenCap.Data.Models
{
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common.Models;

    public class UserComment : BaseDeletableModel<int>
    {
        public Comment Comment { get; set; }

        [ForeignKey(nameof(Comment))]
        public int CommentId { get; set; }

        public ApplicationUser User { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
    }
}
