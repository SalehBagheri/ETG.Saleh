using ETG.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETG.Data
{
    public class RepositoryDbContext : IdentityDbContext, IUnitOfWork
    {
        public RepositoryDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<PostCategory> PostCategories { get; set; }
    }
}
