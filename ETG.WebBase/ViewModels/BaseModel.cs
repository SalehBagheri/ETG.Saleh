using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETG.WebBase.ViewModels
{
    public abstract class BaseModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset CreateOn { get; set; } = DateTimeOffset.Now;
    }
}
