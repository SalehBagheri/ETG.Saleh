using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETG.Domain
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }

        public Guid PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual IdentityUser User { get; set; }
    }
}