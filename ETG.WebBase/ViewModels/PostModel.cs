using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETG.WebBase.ViewModels
{
    public class PostModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public string UserId { get; set; }
        public virtual IdentityUser User { get; set; }

        public virtual IList<CategoryModel> Categories { get; set; }
        public virtual IList<CommentModel> Comments { get; set; }

        public IFormFile FileUpload { get; set; }
        public SelectList CategoriesList { get; set; }
    }
}
