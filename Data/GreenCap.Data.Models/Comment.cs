namespace GreenCap.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common;

    using GreenCap.Data.Common.Models;

    public class Comment : BaseDeletableModel<int>
    {
        [Required]
        [MaxLength(DataValidation.Comment.ContentLength)]
        public string Content { get; set; }

        public virtual Post Post { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostId { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(User))]
        public string UserId { get; set; }
    }
}
