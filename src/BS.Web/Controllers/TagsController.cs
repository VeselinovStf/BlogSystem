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
using BS.WEB.ViewModels.Tag;
using BS.Services.TagService.Abstract;
using Microsoft.Extensions.Logging;
using BS.WEB.ModelFactory.Abstract;
using BS.Services.TagService.ModelDTO;
using BS.Services.ServiceValidator.Exceptions;
using BS.Web.Utilities.LocalRedirector.Abstract;
using BS.Identity.Manager.UserManager.Wrapper.Abstract;
using BS.Identity.Models;

namespace BS.Web.Controllers
{
    [Authorize]
    public class TagsController : Controller
    {
        private readonly BlogSystemEFDbContext _context;
        private readonly ITagService tagService;
        private readonly IModelFactory<TagSetViewModel, TagSetDTO> tagSetModelFactory;
        private readonly IModelFactory<TagPageViewModel, TagDetailsDTO> tagModelFactory;
        private readonly IModelFactory<TagEditViewModel, TagDetailsDTO> tagEditModelFactory;
        private readonly IModelFactory<TagDeleteViewModel, TagDetailsDTO> tagDeleteModelFactory;
        private readonly IUserManagerWrapper<BaseIdentityUser> userManager;
        private readonly ILocalRedirector localRedirector;
        private readonly ILogger<TagsController> logger;

        public TagsController(
            BlogSystemEFDbContext context, 
            ITagService tagService,
            IModelFactory<TagSetViewModel, TagSetDTO> tagSetModelFactory,
            IModelFactory<TagPageViewModel, TagDetailsDTO> tagModelFactory,
             IModelFactory<TagEditViewModel, TagDetailsDTO> tagEditModelFactory,
             IModelFactory<TagDeleteViewModel, TagDetailsDTO> tagDeleteModelFactory,
             IUserManagerWrapper<BaseIdentityUser> userManager,
             ILocalRedirector localRedirector,
            ILogger<TagsController> logger)
        {
            _context = context;
            this.tagService = tagService;
            this.tagSetModelFactory = tagSetModelFactory;
            this.tagModelFactory = tagModelFactory;
            this.tagEditModelFactory = tagEditModelFactory;
            this.tagDeleteModelFactory = tagDeleteModelFactory;
            this.userManager = userManager;
            this.localRedirector = localRedirector;
            this.logger = logger;
        }
            
        // GET: Tags
        public async Task<IActionResult> Index(int id)
        {
            try
            {

                var serviceCall = await this.tagService.GetAll(id);

                var model = this.tagSetModelFactory.Create(serviceCall);

                model.BackgroundImage = "";
                model.HeaderTitle = "Post Keywords";
                model.PageTitle = "Post Keywords";

                this.logger.LogInformation("Displaying all  Tags");

                return View(model);
            }
            catch (Exception ex)
            {
                this.logger.LogError(ex.Message);

                return NotFound();
            }           

        }

        // GET: Tags/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            try
            {
                var serviceCall = await this.tagService.Get(id);

                var tag = this.tagModelFactory.Create(serviceCall);

                tag.BackgroundImage = "";
                tag.HeaderTitle = "Keyword Details";
                tag.PageTitle = "Keyword Details";

                this.logger.LogInformation("Displaying tag details.");

                return View(tag);
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

        // GET: Tags/Create
        public IActionResult Create(int id)
        {
            var model = new TagCreateViewModel();

            model.BlogPostId = id;
            model.BackgroundImage = "";
            model.HeaderTitle = "Create Tag";
            model.PageTitle = "Create Tag";

            return View(model);
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,BlogPostId")] TagCreateViewModel tag)
        {
            if (ModelState.IsValid)
            {
                try
                {
                   
                    await this.tagService.Create(tag.Id, tag.Name, tag.BlogPostId);

                    this.logger.LogInformation("New Tag is created");

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

            return View(tag);
        }

        // GET: Tags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            try
            {
                var serviceCall = await this.tagService.Get(id);

                var blogPost = this.tagEditModelFactory.Create(serviceCall);

                blogPost.BackgroundImage = "";
                blogPost.HeaderTitle = "Edit Keyword";
                blogPost.PageTitle = "Edit Keyword";

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

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] TagEditViewModel tag)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var user = await this.userManager.GetUserAsync(HttpContext.User);

                    await this.tagService.Edit(id, tag.Id, tag.Name, user.UserName);

                    this.logger.LogInformation("Editing Tag.");

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

            return View(tag);
        }

        // GET: Tags/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            try
            {
                var serviceCall = await this.tagService.Get(id);

                var blogPost = this.tagDeleteModelFactory.Create(serviceCall);

                blogPost.BackgroundImage = "";
                blogPost.HeaderTitle = "Delete Keyword";
                blogPost.PageTitle = "Delete Keyword";

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

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            try
            {
                await this.tagService.Remove(id);

                this.logger.LogInformation("Post Delete Confirmed");

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
