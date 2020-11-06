namespace GreenCap.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common;

    using GreenCap.Data.Common.Models;
    using GreenCap.Data.Models.Enums;

    public class Post : BaseDeletableModel<int>
    {
        public Post()
        {
            this.Comments = new HashSet<Comment>();
            this.UsersLikes = new HashSet<UserLike>();
        }

        [Required]
        [MaxLength(DataValidation.NameTitleMaxLength)]
        public string ProblemTitle { get; set; }

        [Required]
        [MaxLength(DataValidation.Post.Description)]
        public string Description { get; set; }

        public virtual ApplicationUser User { get; set; }

        [ForeignKey(nameof(User))]
        public string CreatedById { get; set; }

        public Category Category { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<UserLike> UsersLikes { get; set; }
    }
}
