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
        private readonly IModelFactory<TagSetViewModel, IEnumerable<TagDetailsDTO>> tagSetModelFactory;
        private readonly IModelFactory<TagPageViewModel, TagDetailsDTO> tagModelFactory;
        private readonly IModelFactory<TagEditViewModel, TagDetailsDTO> tagEditModelFactory;
        private readonly IUserManagerWrapper<BaseIdentityUser> userManager;
        private readonly ILocalRedirector localRedirector;
        private readonly ILogger<TagsController> logger;

        public TagsController(
            BlogSystemEFDbContext context, 
            ITagService tagService,
            IModelFactory<TagSetViewModel, IEnumerable<TagDetailsDTO>> tagSetModelFactory,
            IModelFactory<TagPageViewModel, TagDetailsDTO> tagModelFactory,
             IModelFactory<TagEditViewModel, TagDetailsDTO> tagEditModelFactory,
             IUserManagerWrapper<BaseIdentityUser> userManager,
             ILocalRedirector localRedirector,
            ILogger<TagsController> logger)
        {
            _context = context;
            this.tagService = tagService;
            this.tagSetModelFactory = tagSetModelFactory;
            this.tagModelFactory = tagModelFactory;
            this.tagEditModelFactory = tagEditModelFactory;
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
        public IActionResult Create()
        {
            var model = new TagCreateViewModel();

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
        public async Task<IActionResult> Create([Bind("Id,Name")] TagCreateViewModel tag)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    //TODO : SET THIS TO SERVICE
                    var user = await this.userManager.GetUserAsync(HttpContext.User);

                    await this.tagService.Create(tag.Id, tag.Name, user.UserName, user.Id);

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
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tag == null)
            {
                return NotFound();
            }

            return View(tag);
        }

        // POST: Tags/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tag = await _context.Tags.FindAsync(id);
            _context.Tags.Remove(tag);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
  

        private IActionResult RedirectToLocal(string returnUrl, string controller = "Home", string action = "Index", string area = "")
        {
            return this.localRedirector.RedirectToLocal(this, Url, returnUrl, controller, action, area);
        }
    }
}
