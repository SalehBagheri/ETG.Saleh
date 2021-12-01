using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETG.WebBase.ViewModels
{
    public class CategoryModel : BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual IList<PostModel> Posts { get; set; }
    }
}
