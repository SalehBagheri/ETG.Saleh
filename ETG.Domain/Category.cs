using System.Collections.Generic;

namespace ETG.Domain
{
    public class Category : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        
        public virtual IList<PostCategory> Posts { get; set; }
    }
}
