using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BS.Data.EFContext;
using BS.Data.Models;
using Microsoft.AspNetCore.Authorization;
using BS.Services.BlogPostService.Abstract;
using Microsoft.Extensions.Logging;
using BS.Services.ServiceValidator.Exceptions;
using BS.WEB.ModelFactory.Abstract;
using BS.WEB.ViewModels.BlogPost;
using BS.Services.BlogPostService.ModelDTO;
using BS.Identity.Manager.UserManager.Wrapper.Abstract;
using BS.Identity.Models;
using BS.Web.Utilities.LocalRedirector.Abstract;

namespace BS.Web.Controllers
{
    [Authorize]
    public class BlogPostController : Controller
    {
        private readonly IBlogPostService blogPostService;
        private readonly IModelFactory<BlogPostDetailsViewModel, BlogPostDTO> blogPostModelFactory;
        private readonly IModelFactory<BlogPostEditViewModel, BlogPostDTO> editBlogPostModelFactory;
        private readonly IUserManagerWrapper<BaseIdentityUser> userManager;
        private readonly IModelFactory<BlogPostDeleteViewModel, BlogPostDTO> deleteBlogPosetModelFactory;
        private readonly ILocalRedirector localRedirector;
        private readonly ILogger<BlogPostController> logger;

        public BlogPostController(IBlogPostService blogPostService,
            IModelFactory<BlogPostDetailsViewModel, BlogPostDTO> blogPostModelFactory,
            IModelFactory<BlogPostEditViewModel, BlogPostDTO> editBlogPostModelFactory,
            IUserManagerWrapper<BaseIdentityUser> userManager,
            IModelFactory<BlogPostDeleteViewModel, BlogPostDTO> deleteBlogPosetModelFactory,
            ILocalRedirector localRedirector,
            ILogger<BlogPostController> logger)
        {
            this.blogPostService = blogPostService;
            this.blogPostModelFactory = blogPostModelFactory;
            this.editBlogPostModelFactory = editBlogPostModelFactory;
            this.userManager = userManager;
            this.deleteBlogPosetModelFactory = deleteBlogPosetModelFactory;
            this.localRedirector = localRedirector;
            this.logger = logger;
        }

       

        // GET: BlogPost/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var serviceCall = await this.blogPostService.Get(id);

                var blogPost = this.blogPostModelFactory.Create(serviceCall);

                blogPost.BackgroundImage = "";
                blogPost.HeaderTitle = "Post Details";
                blogPost.PageTitle = "Post Details";

                return View(blogPost);
            }
            catch (IdIsNullException ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }
            catch(EntityIsNullException ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }
            catch(Exception ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }

            
        }

       // GET: BlogPost/Create
        public IActionResult Create()
        {
            var model = new BlogPostCreateViewModel();

            model.BackgroundImage = "";
            model.HeaderTitle = "Create Post";
            model.PageTitle = "Create Post";

            return View(model);
        }

        // POST: BlogPost/Create
      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Title,Content")] BlogPostCreateViewModel blogPost)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //TODO : SET THIS TO SERVICE
                    var user = await this.userManager.GetUserAsync(HttpContext.User);

                    await this.blogPostService.Create( blogPost.Title, blogPost.Content, user.UserName, user.Id);

                    return RedirectToLocal("Index", "Home");
                }
                catch (EntityIsNullException ex)
                {
                    this.logger.LogError(ex.Message);

                    return NotFound();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    this.logger.LogError(ex.Message);

                    return NotFound();
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex.Message);

                    return NotFound();
                }
            }

            return View(blogPost);
           
        }

        // GET: BlogPost/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var serviceCall = await this.blogPostService.Get(id);

                var blogPost = this.editBlogPostModelFactory.Create(serviceCall);

                blogPost.BackgroundImage = "";
                blogPost.HeaderTitle = "Edit Post";
                blogPost.PageTitle = "Edit Post";

                return View(blogPost);
            }
            catch (IdIsNullException ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }
            catch (EntityIsNullException ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }                             
          
        }

        // POST: BlogPost/Edit/5      
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content")] BlogPostEditViewModel blogPost)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await this.userManager.GetUserAsync(HttpContext.User);

                    await this.blogPostService.Edit(id, blogPost.Id, blogPost.Title, blogPost.Content, user.UserName);

                    return RedirectToLocal("Index", "Home");
                }
                catch(EntityIsNullException ex)
                {
                    this.logger.LogError(ex.Message);

                    return NotFound();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    this.logger.LogError(ex.Message);

                    return NotFound();
                }
                catch (Exception ex)
                {
                    this.logger.LogError(ex.Message);

                    return NotFound();
                }
            }

            return View(blogPost);
          
        }

        // GET: BlogPost/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var serviceCall = await this.blogPostService.Get(id);

                var blogPost = this.deleteBlogPosetModelFactory.Create(serviceCall);

                blogPost.BackgroundImage = "";
                blogPost.HeaderTitle = "Delete Post";
                blogPost.PageTitle = "Delete Post";

                return View(blogPost);
            }
            catch (IdIsNullException ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }
            catch (EntityIsNullException ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }

        }

        // POST: BlogPost/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await this.blogPostService.Remove(id);

                return RedirectToLocal("Index", "Home");
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }
        }

        private IActionResult RedirectToLocal(string returnUrl, string controller = "Home", string action = "Index", string area = "")
        {
            return this.localRedirector.RedirectToLocal(this, Url, returnUrl, controller, action, area);
        }
    }
}
