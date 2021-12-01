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
    public class GetCategoryQuery : IRequest<Category>
    {
        public Guid Id { get; set; }
    }
    public class GetCategoryQueryHandler : IRequestHandler<GetCategoryQuery, Category>
    {
        private readonly CleanDbContext _context;

        public GetCategoryQueryHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<Category> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
        {
            if (request.Id != Guid.Empty)
            {
                var entity = await _context.Categories.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);
                return entity;
            }
            else
            {
                return null;
            }
        }
    }
}
