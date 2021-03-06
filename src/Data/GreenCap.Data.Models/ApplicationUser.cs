﻿// ReSharper disable VirtualMemberCallInConstructor
namespace GreenCap.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    using GreenCap.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.Posts = new HashSet<Post>();
            this.Comments = new HashSet<Comment>();
            this.Ideas = new HashSet<Proposal>();
            this.UserLikes = new HashSet<UserLike>();
            this.UserEventsHosts = new HashSet<UserEventHosts>();
            this.UserEventSignedIns = new HashSet<UserEventSignedIn>();
            this.Votes = new HashSet<Vote>();
        }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Proposal> Ideas { get; set; }

        public virtual ICollection<UserLike> UserLikes { get; set; }

        public virtual ICollection<UserEventHosts> UserEventsHosts { get; set; }

        public virtual ICollection<UserEventSignedIn> UserEventSignedIns { get; set; }

        public virtual ICollection<Vote> Votes { get; set; }
    }
}
