using ETG.Clean.Infrastructure;
using ETG.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETG.Clean.Application.Posts
{
    public class CreatePostCommand : IRequest<Guid>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

        public string UserId { get; set; }
    }

    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, Guid>
    {
        private readonly CleanDbContext _context;
        public CreatePostCommandHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<Guid> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Title))
            {
                var entity = new Post()
                {
                    Title = request.Title,
                    Description = request.Description,
                    ImageUrl = request.ImageUrl,
                    UserId = request.UserId
                };

                await _context.Posts.AddAsync(entity, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
                return entity.Id;
            }
            return Guid.Empty;
        }
    }
}
