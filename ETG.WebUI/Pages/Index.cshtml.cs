using ETG.Clean.Application.Categories;
using ETG.Clean.Application.Posts;
using ETG.WebBase.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ETG.WebUI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IMediator _mediator;
        public IList<PostModel> Posts { get; set; }
        public IList<CategoryModel> Categories { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task OnGetAsync()
        {
            var posts = await _mediator.Send(new GetPostListQuery());
            var pModel = new List<PostModel>();
            foreach (var p in posts.OrderByDescending(x => x.CreateOn))
            {
                var model = new PostModel() { CreateOn = p.CreateOn, Id = p.Id, Title = p.Title, Description = p.Description, ImageUrl = p.ImageUrl };
                if (p.Categories != null)
                {
                    var catList = new List<CategoryModel>();
                    foreach (var c in p.Categories)
                    {
                        catList.Add(new CategoryModel() { Id = c.Id, Title = c.Category.Title, Description = c.Category.Description });
                    }
                    model.Categories = catList;
                }
                if (p.Comments != null)
                {
                    var comList = new List<CommentModel>();
                    foreach (var c in p.Comments)
                    {
                        comList.Add(new CommentModel() { CreateOn = c.CreateOn, Id = c.Id, Text = c.Text, PostId = c.PostId, UserId = c.UserId });
                    }
                    model.Comments = comList;
                }
                pModel.Add(model);
            }
            Posts = pModel;

            var categories = await _mediator.Send(new GetCategoryListQuery());
            var pCategories = new List<CategoryModel>();

            foreach (var c in categories)
            {
                pCategories.Add(new CategoryModel()
                {
                    Title = c.Title,
                    Id = c.Id,
                    Description = c.Description
                });
            }
            Categories = pCategories;
        }
    }
}
