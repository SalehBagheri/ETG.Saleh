using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ETG.Domain
{
    /// <summary>
    /// Mapper Class
    /// </summary>
    public class PostCategory : BaseEntity
    {
        public Guid CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public Guid PostId { get; set; }
        [ForeignKey("PostId")]
        public virtual Post Post { get; set; }
    }
}
