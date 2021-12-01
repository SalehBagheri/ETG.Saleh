using ETG.Clean.Infrastructure;
using ETG.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETG.Clean.Application.PostCategories
{
    public class CreatePostCategoryCommand : IRequest<Unit>
    {
        public Guid CategoryId { get; set; }
        public Guid PostId { get; set; }
    }

    public class CreatePostCategoryCommandHandler : IRequestHandler<CreatePostCategoryCommand, Unit>
    {
        private readonly CleanDbContext _context;
        public CreatePostCategoryCommandHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreatePostCategoryCommand request, CancellationToken cancellationToken)
        {
            if (request.CategoryId == Guid.Empty || request.PostId == Guid.Empty)
                throw new ArgumentNullException("Navigation Ids are null");

            var existing = _context.PostCategories.Any(x => x.PostId == request.PostId && x.CategoryId == request.CategoryId);

            if (existing)
                return Unit.Value;

            var entity = new PostCategory()
            {
                CategoryId = request.CategoryId,
                PostId = request.PostId
            };

            await _context.PostCategories.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return Unit.Value;
        }
    }
}
