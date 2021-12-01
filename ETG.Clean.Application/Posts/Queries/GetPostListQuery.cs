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

namespace ETG.Clean.Application.Posts
{
    public class GetPostListQuery : IRequest<IList<Post>>
    {
        public Guid CategoryId { get; set; }
        public string SearchQuery { get; set; }
    }

    public class GetPostListQueryHandler : IRequestHandler<GetPostListQuery, IList<Post>>
    {
        private readonly CleanDbContext _context;

        public GetPostListQueryHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Post>> Handle(GetPostListQuery request, CancellationToken cancellationToken)
        {
            var query = _context.Posts.Include(x => x.Comments).Include(x => x.Categories).ThenInclude(x => x.Category).AsQueryable();

            if (request.CategoryId != Guid.Empty)
                query = query.Where(x => x.Categories.Any(y => y.CategoryId == request.CategoryId));
            if (!string.IsNullOrEmpty(request.SearchQuery))
                query = query.Where(x => x.Description.Contains(request.SearchQuery) || x.Title.Contains(request.SearchQuery));

            return await query.ToListAsync(cancellationToken);
        }
    }
}
