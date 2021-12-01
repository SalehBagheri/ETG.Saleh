using ETG.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ETG.Clean.Infrastructure
{
    public class CleanDbContext : IdentityDbContext
    {
        public CleanDbContext(DbContextOptions options) : base(options) { }
        
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }    
        public DbSet<PostCategory> PostCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            var User1Id = "448bee34-7aaf-4f9a-bb7f-1da82fdad254";
            var User2Id = "d2d92f37-7fb8-494e-bc06-79bf1207cf0a";
            var pwdHasher = new PasswordHasher<IdentityUser>();

            var users = new List<IdentityUser>()
            {
                new IdentityUser()
                {
                    Id = User1Id,
                    Email = "andi.toci@etg.al",
                    UserName = "andi.toci@etg.al",
                    NormalizedEmail = "ANDI.TOCI@ETG.AL",
                    NormalizedUserName = "ANDI.TOCI@ETG.AL",
                    EmailConfirmed = true,
                    LockoutEnabled = true
                },
                new IdentityUser()
                {
                    Id = User2Id,
                    Email = "bagheri.saleh@gmail.com",
                    UserName = "bagheri.saleh@gmail.com",
                    NormalizedEmail = "BAGHERI.SALEH@GMAIL.COM",
                    NormalizedUserName = "BAGHERI.SALEH@GMAIL.COM",
                    EmailConfirmed = true,
                    LockoutEnabled = true,
                }
            };

            users[0].PasswordHash = pwdHasher.HashPassword(users[0], "Andi@123");
            users[1].PasswordHash = pwdHasher.HashPassword(users[1], "Saleh@123");

            builder.Entity<IdentityUser>().HasData(users);


            var Cat1Id = new Guid("682b45de-3aaf-3f9a-237f-1da825dad254");
            var Cat2Id = new Guid("45d92f47-6fb8-222e-abb6-79bf1207cf0a");

            builder.Entity<Category>().HasData(
                new Category() { Id = Cat1Id, Title = "Books", Description = "Books Desc" },
                new Category() { Id = Cat2Id, Title = "Computers", Description = "Computers Desc" },
                new Category() { Title = "Cameras", Description = "Cameras Desc" },
                new Category() { Title = "Mobiles", Description = "Mobiles Desc" },
                new Category() { Title = "Stationary", Description = "Stationary Desc" },
                new Category() { Title = "Apparel", Description = "Apparel Desc" },
                new Category() { Title = "Shoes", Description = "Shoes Desc" },
                new Category() { Title = "Furnitures", Description = "Furnitures Desc" }
                );

            var Post1Id = new Guid("d32bee34-3aaf-3f9a-cb7f-1da82fdad254");
            var Post2Id = new Guid("32d92f47-6fb8-494e-aa06-79bf1207cf0a");
            var sampleText = "<p> Interdum himenaeos sagittis feugiat egestas justo varius. Volutpat himenaeos turpis quis aliquet class nostra. Cum amet aenean, quis nullam. Mus justo facilisi tellus mauris tempus sed! Pretium quam cras at in platea nascetur cursus primis tincidunt nibh sollicitudin. Facilisi orci cum aliquam porta. Ridiculus curabitur, nisl faucibus pellentesque massa aliquam. Elementum donec viverra urna iaculis quam dignissim libero taciti neque. Quis lacinia suscipit non congue et dui gravida donec. Rutrum varius sociis proin integer venenatis taciti semper penatibus iaculis tortor sed. Rutrum malesuada habitant dictum, semper ornare purus. Magna tortor elementum lectus aptent volutpat faucibus interdum eget nisi. </p> <p> Erat, facilisi per pellentesque. Tristique imperdiet taciti mauris ac egestas imperdiet nullam taciti! Rutrum tortor elementum vitae molestie lobortis. Proin sit curae; scelerisque nam porta odio imperdiet nascetur malesuada risus. Eu euismod vestibulum viverra. Hac fusce quis nascetur. Cum scelerisque malesuada hac varius morbi conubia quis taciti leo integer. Lobortis. </p> <p> Imperdiet senectus commodo ante velit turpis leo. Diam ac netus sagittis eget. Nostra pharetra per cursus mus vulputate fusce ornare platea sollicitudin suscipit bibendum potenti. Pretium augue odio nunc in. Purus amet eu, tortor per varius congue. Blandit lobortis parturient ac class cum. Vestibulum pulvinar metus praesent feugiat ut ridiculus semper dapibus suspendisse ut lectus. Cras velit libero augue morbi quisque feugiat convallis ac? Justo tortor purus ridiculus duis mollis auctor dictum sociosqu non lobortis ut. Vel curabitur praesent libero? Id arcu senectus ullamcorper elementum felis rhoncus integer curae; quis. Torquent iaculis accumsan habitasse posuere ligula sit ullamcorper sed auctor inceptos posuere. Auctor hac pulvinar nibh. Egestas vivamus taciti, id posuere feugiat porta laoreet sed hendrerit taciti lacinia. Nunc vitae condimentum. </p> <p> Ipsum feugiat ligula fusce. Nam mi et tellus molestie justo lacus dictum varius phasellus conubia pretium cubilia. Maecenas magnis consequat varius aenean aptent. Varius sociis ac dis facilisis scelerisque ante turpis. Consectetur ac non tempus pulvinar semper felis hac senectus. Cum aenean lacus porta libero scelerisque rhoncus penatibus mi sit vitae rhoncus dis. Nam leo tempus velit, habitasse porttitor eu ultrices orci? Porttitor eu placerat nostra risus! </p> <p> Nulla elementum nunc adipiscing nulla turpis duis quam? Curae; venenatis magnis imperdiet nisi laoreet vel dictumst. Blandit sodales iaculis rutrum class inceptos aptent ipsum tempus conubia id. Justo ac inceptos habitant. Cubilia, ac elementum vivamus velit amet egestas venenatis litora fames maecenas aptent. Posuere facilisis platea bibendum eleifend. Praesent mollis purus purus. Quam aliquet a conubia. Lorem magna curabitur purus tincidunt nisi. Libero ornare. </p>";

            builder.Entity<Post>().HasData(
                new Post()
                {
                    Id = Post1Id,
                    Title = "Interdum himenaeos sagittis feugiat egestas",
                    Description = sampleText,
                    ImageUrl = "Images/Sample/1.jpg",
                    UserId = User1Id,
                    CreateOn = DateTimeOffset.UtcNow.AddDays(-1),
                },
                new Post()
                {
                    Id = Post2Id,
                    Title = "Volutpat himenaeos turpis quis",
                    Description = sampleText,
                    ImageUrl = "Images/Sample/2.jpg",
                    UserId = User2Id,
                    CreateOn = DateTimeOffset.UtcNow.AddDays(-2),
                },
                new Post()
                {
                    Title = "Velit magnis nullam consectetur",
                    Description = sampleText,
                    ImageUrl = "Images/Sample/3.jpg",
                    UserId = User1Id,
                    CreateOn = DateTimeOffset.UtcNow.AddDays(-3),
                },
                new Post()
                {
                    Title = "Ad iaculis dictumst consequat",
                    Description = sampleText,
                    ImageUrl = "Images/Sample/4.jpg",
                    UserId = User2Id,
                    CreateOn = DateTimeOffset.UtcNow.AddDays(-4),
                },
                new Post()
                {
                    Title = "Habitant volutpat sociis donec fames",
                    Description = sampleText,
                    ImageUrl = "Images/Sample/5.jpg",
                    UserId = User1Id,
                    CreateOn = DateTimeOffset.UtcNow.AddDays(-5),
                }
                );

            builder.Entity<PostCategory>().HasData(
                new PostCategory() { PostId = Post1Id, CategoryId = Cat1Id },
                new PostCategory() { PostId = Post1Id, CategoryId = Cat2Id },
                new PostCategory() { PostId = Post2Id, CategoryId = Cat2Id }
                );

            builder.Entity<Comment>().HasData(
                new Comment() { PostId = Post1Id, UserId = User1Id, CreateOn = DateTimeOffset.Now.AddHours(-1), Text = "<p> Habitant volutpat sociis donec fames. Erat tellus neque vel consequat tincidunt lectus sociosqu justo parturient dictumst porta sagittis. Leo augue, fames neque odio quis orci tempus maecenas aliquet diam. Imperdiet sagittis aliquet nullam turpis velit eros tortor suspendisse aenean nam. Arcu massa blandit mus enim proin. Tincidunt proin habitasse pellentesque erat torquent porttitor mus donec. </p> <p> Ad iaculis dictumst consequat lobortis etiam auctor ipsum dui. Ridiculus netus nostra fermentum? Elementum vulputate in augue, scelerisque eget. Class mi tortor phasellus ridiculus ullamcorper sociosqu. Pellentesque nullam, nisl tempus suspendisse aenean cursus nascetur imperdiet! Ultricies elementum mollis rutrum nisi vehicula facilisi et molestie pretium, sociis ut. Felis erat ullamcorper quisque nulla libero, purus rhoncus. Habitant felis, rhoncus enim elementum potenti facilisi imperdiet sed enim magnis. Etiam morbi ultricies sodales? </p>" },
                new Comment() { PostId = Post2Id, UserId = User1Id, CreateOn = DateTimeOffset.Now.AddHours(-1), Text = "<p> Habitant volutpat sociis donec fames. Erat tellus neque vel consequat tincidunt lectus sociosqu justo parturient dictumst porta sagittis. Leo augue, fames neque odio quis orci tempus maecenas aliquet diam. Imperdiet sagittis aliquet nullam turpis velit eros tortor suspendisse aenean nam. Arcu massa blandit mus enim proin. Tincidunt proin habitasse pellentesque erat torquent porttitor mus donec. </p>" },
                new Comment() { PostId = Post1Id, UserId = User2Id, CreateOn = DateTimeOffset.Now.AddHours(-2), Text = "<p> Habitant volutpat sociis donec fames. Erat tellus neque vel consequat tincidunt lectus sociosqu justo parturient dictumst porta sagittis. Leo augue, fames neque odio quis orci tempus maecenas aliquet diam. Imperdiet sagittis aliquet nullam turpis velit eros tortor suspendisse aenean nam. Arcu massa blandit mus enim proin. Tincidunt proin habitasse pellentesque erat torquent porttitor mus donec. </p> <p> Ad iaculis dictumst consequat lobortis etiam auctor ipsum dui. Ridiculus netus nostra fermentum? Elementum vulputate in augue, scelerisque eget. </p>" },
                new Comment() { PostId = Post2Id, UserId = User2Id, CreateOn = DateTimeOffset.Now.AddHours(-2), Text = "<p> Habitant volutpat sociis donec fames. Erat tellus neque vel consequat tincidunt lectus sociosqu justo parturient dictumst porta sagittis. Leo augue, fames neque odio quis orci tempus maecenas aliquet diam. Imperdiet sagittis aliquet nullam turpis velit eros tortor suspendisse aenean nam. Arcu massa blandit mus enim proin. Tincidunt proin habitasse pellentesque erat torquent porttitor mus donec. </p> <p> Ad iaculis dictumst consequat lobortis etiam auctor ipsum dui. Ridiculus netus nostra fermentum? Elementum vulputate in augue, scelerisque eget. Class mi tortor phasellus ridiculus ullamcorper sociosqu. </p>" }
                );

            base.OnModelCreating(builder);
        }
    }
}
