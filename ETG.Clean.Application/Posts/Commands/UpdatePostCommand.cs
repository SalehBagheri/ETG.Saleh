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
    public class UpdatePostCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }

    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, Unit>
    {
        private readonly CleanDbContext _context;
        public UpdatePostCommandHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            if (request.Id != Guid.Empty)
            {
                var entity = await _context.Posts.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

                if (entity != null)
                {
                    if (!string.IsNullOrEmpty(request.Title))
                        entity.Title = request.Title;
                    if (!string.IsNullOrEmpty(request.Description))
                        entity.Description = request.Description;
                    if (!string.IsNullOrEmpty(request.ImageUrl))
                        entity.ImageUrl = request.ImageUrl;

                    _context.Posts.Update(entity);
                    await _context.SaveChangesAsync(cancellationToken);
                }         
            }
            return Unit.Value;
        }
    }
}
