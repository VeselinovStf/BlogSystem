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

namespace BS.Web.Controllers
{
    [Authorize]
    public class TagsController : Controller
    {
        private readonly BlogSystemEFDbContext _context;
        private readonly ITagService tagService;
        private readonly IModelFactory<TagSetViewModel, IEnumerable<TagDetailsDTO>> tagSetModelFactory;
        private readonly ILogger<TagsController> logger;

        public TagsController(
            BlogSystemEFDbContext context, 
            ITagService tagService,
            IModelFactory<TagSetViewModel, IEnumerable<TagDetailsDTO>> tagSetModelFactory,
            ILogger<TagsController> logger)
        {
            _context = context;
            this.tagService = tagService;
            this.tagSetModelFactory = tagSetModelFactory;
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

        // GET: Tags/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tags/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Tag tag)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tag);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tag);
        }

        // GET: Tags/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tag = await _context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound();
            }
            return View(tag);
        }

        // POST: Tags/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,IsDeleted,DeletedOn,CreatedOn,ModifiedOn")] Tag tag)
        {
            if (id != tag.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tag);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TagExists(tag.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
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

        private bool TagExists(int id)
        {
            return _context.Tags.Any(e => e.Id == id);
        }
    }
}
