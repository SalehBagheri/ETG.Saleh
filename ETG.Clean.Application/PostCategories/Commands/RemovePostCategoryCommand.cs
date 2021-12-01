using ETG.Clean.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETG.Clean.Application.PostCategories
{
    public class RemovePostCategoryCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
    }

    public class RemovePostCategoryCommandHandler : IRequestHandler<RemovePostCategoryCommand, bool>
    {
        private readonly CleanDbContext _context;
        public RemovePostCategoryCommandHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<bool> Handle(RemovePostCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.PostCategories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
            if (entity != null)
            {
                _context.PostCategories.Remove(entity);
                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            return false;
        }
    }
}
