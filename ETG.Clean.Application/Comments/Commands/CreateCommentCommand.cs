using ETG.Clean.Infrastructure;
using ETG.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ETG.Clean.Application.Comments
{
    public class CreateCommentCommand : IRequest<Comment>
    {
        public string Text { get; set; }
        public Guid PostId { get; set; }
        public string UserId { get; set; }
    }

    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommand, Comment>
    {
        private readonly CleanDbContext _context;
        public CreateCommentCommandHandler(CleanDbContext context)
        {
            _context = context;
        }
        public async Task<Comment> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            var entity = new Comment()
            {
                Text = request.Text,
                PostId = request.PostId,
                UserId = request.UserId
            };

            await _context.Comments.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return entity;
        }
    }
}
