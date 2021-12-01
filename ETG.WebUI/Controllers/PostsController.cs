using ETG.Clean.Application.Categories;
using ETG.Clean.Application.Comments;
using ETG.Clean.Application.PostCategories;
using ETG.Clean.Application.Posts;
using ETG.Domain;
using ETG.WebBase.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETG.WebUI.Controllers
{
    [Authorize]
    public class PostsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnv;
        private readonly IMediator _mediator;
        private readonly IdentityUser _currentUser;
        private readonly UserManager<IdentityUser> _userManager;
        public PostsController(IWebHostEnvironment webHostEnv,
            IHttpContextAccessor httpContext,
            IMediator mediator,
            UserManager<IdentityUser> userManager)
        {
            _webHostEnv = webHostEnv;
            _mediator = mediator;
            _userManager = userManager;
            _currentUser = userManager.GetUserAsync(httpContext.HttpContext.User).Result;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Create()
        {
            var model = new PostModel();
            model.CategoriesList = new SelectList(await GetCat(), "Id", "Title");
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(PostModel model)
        {
            if (ModelState.IsValid)
            {
                var imageUrl = string.Empty;
                if (model.FileUpload?.Length > 0)
                {
                    imageUrl = await SaveFileAsync(model.FileUpload);
                }
                var pId = await _mediator.Send(new CreatePostCommand() { Title = model.Title ?? "Untitled", Description = model.Description ?? "No Description", ImageUrl = imageUrl, UserId = _currentUser?.Id });

                return RedirectToAction("Update", new { postId = pId.ToString() });
            }
            return View(model);
        }

        [Route("{controller}/{action}/{postId}")]
        public async Task<IActionResult> Update(Guid postId)
        {
            var model = new PostModel();
            if (postId != Guid.Empty)
            {
                var post = await _mediator.Send(new GetPostQuery() { Id = postId });
                if (post != null)
                {
                    model.Id = post.Id;
                    model.Title = post.Title;
                    model.Description = post.Description;
                    model.ImageUrl = post.ImageUrl;
                    model.UserId = post.UserId;
                    model.CategoriesList = new SelectList(await GetCat(), "Id", "Title");
                    if (post.Categories != null)
                    {
                        var catList = new List<CategoryModel>();
                        foreach (var c in post.Categories)
                        {
                            catList.Add(new CategoryModel() { Id = c.Id, Title = c.Category.Title, Description = c.Category.Description });
                        }
                        model.Categories = catList;
                    }
                    return View(model);
                }
            }
            model.CategoriesList = new SelectList(await GetCat(), "Id", "Title");
            return View(model);
        }

        [HttpPost]
        [Route("{controller}/{action}/{postId}")]
        public async Task<IActionResult> Update(PostModel model, Guid postId)
        {
            if (ModelState.IsValid)
            {
                var upd = new UpdatePostCommand();
                upd.Id = model.Id;
                upd.Title = model.Title;
                upd.Description = model.Description;
                if (model.FileUpload?.Length > 0)
                {
                    upd.ImageUrl = await SaveFileAsync(model.FileUpload);
                }
                await _mediator.Send(upd);
            }
            return RedirectToAction("Show", new { postId = model.Id });
        }


        private async Task<string> SaveFileAsync(IFormFile upload)
        {
            var path = Path.Combine(_webHostEnv.WebRootPath, "Images", DateTime.Now.ToString("yyyyMMdd"));

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileName = Path.GetRandomFileName() + Path.GetExtension(upload.FileName);
            using (var stream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
            {
                await upload.CopyToAsync(stream);
            }
            return string.Format("{0}/{1}/{2}", "Images", DateTime.Now.ToString("yyyyMMdd"), fileName);
        }
        [AllowAnonymous]
        [Route("{controller}/{action}/{postId}")]
        public async Task<IActionResult> Show(Guid postId)
        {
            if (postId == Guid.Empty)
                return new NotFoundResult();

            var post = await _mediator.Send(new GetPostQuery() { Id = postId });

            if (post == null)
                return new NotFoundResult();

            var model = new PostModel();
            model.Id = post.Id;
            model.Title = post.Title;
            model.Description = post.Description;
            model.ImageUrl = post.ImageUrl;
            model.UserId = post.UserId;
            model.User = _currentUser;
            if (post.Categories != null)
            {
                var catList = new List<CategoryModel>();
                foreach (var c in post.Categories)
                {
                    catList.Add(new CategoryModel() { Id = c.CategoryId, Title = c.Category.Title, Description = c.Category.Description });
                }
                model.Categories = catList;
            }
            if (post.Comments != null)
            {
                var comList = new List<CommentModel>();
                foreach (var c in post.Comments.OrderBy(x => x.CreateOn))
                {
                    var cmt = new CommentModel() { CreateOn = c.CreateOn, Id = c.Id, Text = c.Text, PostId = c.PostId, UserId = c.UserId };
                    cmt.User = await _userManager.FindByIdAsync(c.UserId);
                    comList.Add(cmt);
                }
                model.Comments = comList;
            }
            model.CategoriesList = new SelectList(await GetCat(), "Id", "Title");
            return View(model);
        }

        [AllowAnonymous]
        [Route("{controller}/{action}/{categoryId}")]
        public async Task<IActionResult> Category(Guid categoryId)
        {
            if (categoryId != Guid.Empty)
            {
                var posts = await _mediator.Send(new GetPostListQuery() { CategoryId = categoryId });

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
                return View(pModel);
            }
            return View(Enumerable.Empty<PostModel>());
        }

        [AllowAnonymous]
        public async Task<IActionResult> Search(string query)
        {
            if (!string.IsNullOrEmpty(query))
            {
                var posts = await _mediator.Send(new GetPostListQuery() { SearchQuery = query });

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
                return View(pModel);
            }
            return View(Enumerable.Empty<PostModel>());
        }

        [HttpPost]
        public async Task<string> AddComment(string comment, Guid postId)
        {
            if (ModelState.IsValid)
            {
                var cmt = await _mediator.Send(new CreateCommentCommand() { Text = comment, PostId = postId, UserId = _currentUser.Id });

                if (cmt != null)
                {
                    var template = "<p class=\"mb-0\">{0} " +
                        "<small class=\"text-muted\">commented on {1}</small></p>" +
                        "<p class=\"mb-3\">{2}</p>";
                    var result = string.Format(template, _currentUser.UserName, cmt.CreateOn.ToString("G"), cmt.Text);
                    return result;
                }
                else
                    return null;
            }
            else
                return null;
        }

        [Route("{controller}/{action}/{postId}")]
        public async Task<IActionResult> Remove(Guid postId)
        {
            if (postId == Guid.Empty)
                return RedirectToPage("/Index");

            await _mediator.Send(new RemovePostCommand() { Id = postId });

            return RedirectToPage("/Index");
        }

        private async Task<IEnumerable<CategoryModel>> GetCat()
        {
            var categories = await _mediator.Send(new GetCategoryListQuery());
            return categories.Select(x => new CategoryModel() { Id = x.Id, Title = x.Title });
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<string> GetCategories()
        {
            var categories = await _mediator.Send(new GetCategoryListQuery());
            if (categories.Any())
            {
                var template = "<a href=\"{0}\" class=\"list-group-item\">{1} ({2})</a>";
                var result = new StringBuilder();
                foreach(var cat in categories)
                {
                    result.AppendFormat(template, Url.Action("Category", "Posts", new { categoryId = cat.Id.ToString() }), cat.Title, cat.Posts.Count);
                }
                return result.ToString();
            }
            return string.Empty;
        }

        [HttpPost]
        public async Task<string> AssignCategory(Guid postId, Guid categoryId)
        {
            if (ModelState.IsValid)
            {
                await _mediator.Send(new CreatePostCategoryCommand() { PostId = postId, CategoryId = categoryId });
                var post = await _mediator.Send(new GetPostQuery() { Id = postId });

                var template = "<div class=\"card cat-item my-1\" id=\"{0}\"><div class=\"card-body p-2\"><span>{1}</span><a href=\"#\" data-pcid=\"{2}\" class=\"removeCat btn btn-sm btn-outline-danger float-right\">Remove</a></div></div>";

                var result = new StringBuilder();
                foreach (var c in post.Categories)
                {
                    result.AppendFormat(template, c.Id, c.Category.Title, c.Id);                    
                }
                return result.ToString();
            }
            return string.Empty;
        }

        [HttpPost]
        public async Task<bool> RemoveCategory(Guid postCatId)
        {
            if (ModelState.IsValid)
            {
                return await _mediator.Send(new RemovePostCategoryCommand() { Id = postCatId });
            }
            return false;
        }


    }
}