using ETG.Clean.Infrastructure;
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
    public class RemovePostCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }

    public class RemovePostCommandHanlder : IRequestHandler<RemovePostCommand, Unit>
    {
        private readonly CleanDbContext _context;

        public RemovePostCommandHanlder(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(RemovePostCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != Guid.Empty)
            {
                var entity = await _context.Posts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                if (entity != null)
                {
                    _context.Posts.Remove(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                }
            }
            return Unit.Value;
        }
    }
}
