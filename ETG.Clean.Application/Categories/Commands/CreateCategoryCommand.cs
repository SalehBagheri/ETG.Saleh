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
    public class CreateCategoryCommand : IRequest<Unit>
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Unit>
    {
        private readonly CleanDbContext _context;

        public CreateCategoryCommandHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<Unit> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            if (!string.IsNullOrEmpty(request.Title))
            {
                var entity = new Category()
                {
                    Title = request.Title,
                    Description = request.Description
                };
                _context.Categories.Add(entity);
                await _context.SaveChangesAsync(cancellationToken);
            }
            return Unit.Value;
        }
    }
}
