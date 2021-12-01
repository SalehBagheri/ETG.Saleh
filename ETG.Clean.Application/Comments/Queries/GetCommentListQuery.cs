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

namespace ETG.Clean.Application.Comments
{
    public class GetCommentListQuery : IRequest<IList<Comment>>
    {
    }

    public class GetCommentListQueryHandler : IRequestHandler<GetCommentListQuery, IList<Comment>>
    {
        private readonly CleanDbContext _context;

        public GetCommentListQueryHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<IList<Comment>> Handle(GetCommentListQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Comments.ToListAsync(cancellationToken);
            return entities;
        }
    }
}
