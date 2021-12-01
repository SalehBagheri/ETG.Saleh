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
    public class GetPostQuery : IRequest<Post>
    {
        public Guid Id { get; set; }
    }

    public class GetPostQueryHandler : IRequestHandler<GetPostQuery, Post>
    {
        private readonly CleanDbContext _context;

        public GetPostQueryHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<Post> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            if (request.Id == Guid.Empty)
            {
                throw new ArgumentNullException(nameof(request.Id));
            }

            var entity = await _context.Posts.Include(x => x.Comments).Include(x => x.Categories).ThenInclude(x => x.Category).FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            return entity;
        }
    }
}
