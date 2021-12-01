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
    public class GetCommentQuery : IRequest<Comment>
    {
        public Guid Id { get; set; }
    }

    public class GetCommentQueryHandler : IRequestHandler<GetCommentQuery, Comment>
    {
        private readonly CleanDbContext _context;

        public GetCommentQueryHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> Handle(GetCommentQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != Guid.Empty)
            {
                var entity = await _context.Comments.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                return entity;
            }   
            else
            {
                return null;
            }
        }
    }
}
