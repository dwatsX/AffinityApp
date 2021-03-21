using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Affinity.Data;
using Affinity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace Affinity.Controllers
{
    public class ImageController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ImageController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: Image
        [HttpGet("[controller]/{profileId}")]
        [Authorize]
        public async Task<IActionResult> Index(int? profileId)
        {
            if (profileId == null)
            {
                return NotFound();
            }

            var applicationDbContext = _context.Images.Include(p => p.Profile)
                .Where(p => p.ProfileId == profileId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Image/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                .Include(i => i.Profile)
                .FirstOrDefaultAsync(m => m.ImageId == id);

            if (image == null)
            {
                return NotFound();
            }

            return View(image);
        }

        // GET: Image/Create
        public IActionResult Create()
        {
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileId");
            return View();
        }

        // POST: Image/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ImageId,ProfileId,ImageURL")] Image image)
        {
            User user = await _userManager.GetUserAsync(User);

            var profile = _context.Profile.FirstOrDefault(p => p.UserId == user.Id);

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(image);
                    profile.Images.Add(image);
                    _context.Profile.Update(profile);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index), new { profileId = image.ProfileId });
                }
                ViewData["ProfileID"] = new SelectList(_context.Profile, "ProfileId", "ProfileId", image.ProfileId);
                return View(image);
            }
            catch (Exception e)
            {

                throw;
            }

        }

        // GET: Image/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images.FindAsync(id);
            if (image == null)
            {
                return NotFound();
            }
            ViewData["ProfileID"] = new SelectList(_context.Profile, "ProfileId", "Description", image.ProfileId);
            return View(image);
        }

        // POST: Image/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ImageId,ProfileId,ImageURL")] Image image)
        {
            if (id != image.ImageId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(image);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImageExists(image.ImageId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index), new { profileId = image.ProfileId });
            }
            ViewData["ProfileID"] = new SelectList(_context.Profile, "ProfileId", "Description", image.ProfileId);
            return View(image);
        }

        // GET: Image/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var image = await _context.Images
                     .Include(i => i.Profile)
                     .FirstOrDefaultAsync(m => m.ImageId == id);
            if (image == null)
            {
                return NotFound();
            }

            return View(image);

        }

        // POST: Image/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            User user = await _userManager.GetUserAsync(User);

            var profile = _context.Profile.FirstOrDefault(p => p.UserId == user.Id);

            var image = await _context.Images.FindAsync(id);
            _context.Images.Remove(image);
            profile.Images.Remove(image);
            _context.Profile.Update(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), new { profileId = image.ProfileId });
        }

        private bool ImageExists(int id)
        {
            return _context.Images.Any(e => e.ImageId == id);
        }
    }
}
