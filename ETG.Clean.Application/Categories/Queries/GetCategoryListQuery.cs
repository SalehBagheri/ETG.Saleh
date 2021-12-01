using ETG.Clean.Infrastructure;
using ETG.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETG.Clean.Application.Categories
{
    public class GetCategoryListQuery : IRequest<IList<Category>>
    {
    }

    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IList<Category>>
    {
        private readonly CleanDbContext _context;

        public GetCategoryListQueryHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Category>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Categories.Include(x => x.Posts).ToListAsync(cancellationToken);
            return entities;
        }
    }
}
