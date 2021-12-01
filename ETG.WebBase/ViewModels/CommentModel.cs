using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETG.WebBase.ViewModels
{
    public class CommentModel : BaseModel
    {
        public string Text { get; set; }

        public Guid PostId { get; set; }
        public virtual PostModel Post { get; set; }

        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }
    }
}
