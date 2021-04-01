using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Affinity.Data;
using Affinity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;

namespace Affinity.Controllers
{
    public class InterestsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public InterestsController(ApplicationDbContext context, UserManager<User> user)
        {
            _context = context;
            _userManager = user;
        }

        // GET: Interests
        [Authorize]
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var profile = _context.Profile
                .FirstOrDefault(r => r.UserId == user.Id);

            var applicationDbContext = _context.Interests.Include(i => i.InterestCategory).Include(i => i.InterestSubCategory).Include(i => i.Profile)
                .Where(i => i.ProfileId == profile.ProfileId);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Interests/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interests = await _context.Interests
                .Include(i => i.InterestCategory)
                .Include(i => i.InterestSubCategory)
                .Include(i => i.Profile)
                .FirstOrDefaultAsync(m => m.InterestId == id);
            if (interests == null)
            {
                return NotFound();
            }

            return View(interests);
        }

        // GET: Interests/Create
        [Authorize]
        public async Task<IActionResult> Create()
        {
            List<InterestCategory> categories = _context.InterestCategory.ToList();
            categories.Add(new InterestCategory { InterestCategoryId = 0, InterestCategoryName = null });
            ViewData["InterestCategoryId"] = new SelectList(categories, "InterestCategoryId", "InterestCategoryName", null);
            User user = await _userManager.GetUserAsync(User);

            var profile = _context.Profile.FirstOrDefault(p => p.UserId == user.Id);
            var interest = new Interests { ProfileId = profile.ProfileId };

            ViewData["ProfileID"] = profile.ProfileId;
            return View(interest);
        }

        // POST: Interests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestId,InterestCategoryId,InterestSubCategoryId,ProfileId")] Interests interests)
        {
            interests.InterestCategory = _context.InterestCategory.Where(i => i.InterestCategoryId == interests.InterestCategoryId).FirstOrDefault();
            List<InterestSubCategory> subList = _context.InterestSubCategory.Where(i => i.InterestCategoryId == interests.InterestCategoryId).ToList();
            interests.InterestSubCategory = _context.InterestSubCategory.Where(i => i.InterestSubCategoryId == interests.InterestSubCategoryId).FirstOrDefault();
            if (interests.InterestSubCategory == null || interests.InterestCategory.InterestCategoryId != interests.InterestSubCategory.InterestCategoryId)
            {
                ViewData["InterestCategoryId"] = new SelectList(_context.InterestCategory, "InterestCategoryId", "InterestCategoryName", interests.InterestCategoryId);
                ViewData["InterestSubCategoryId"] = new SelectList(subList, "InterestSubCategoryId", "InterestSubCategoryName", interests.InterestSubCategoryId);
                return View(interests);
            }

            if (ModelState.IsValid)
            {
                _context.Add(interests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(interests);
        }

        // GET: Interests/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interests = await _context.Interests.FindAsync(id);
            if (interests == null)
            {
                return NotFound();
            }
            List<InterestCategory> categories = _context.InterestCategory.ToList();
            categories.Add(new InterestCategory { InterestCategoryId = 0, InterestCategoryName = null });
            ViewData["InterestCategoryId"] = new SelectList(categories, "InterestCategoryId", "InterestCategoryName", null);
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", interests.ProfileId);
            return View(interests);
        }

        // POST: Interests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestId,InterestCategoryId,InterestSubCategoryId,ProfileId")] Interests interests)
        {
            if (id != interests.InterestId)
            {
                return NotFound();
            }

            interests.InterestCategory = _context.InterestCategory.Where(i => i.InterestCategoryId == interests.InterestCategoryId).FirstOrDefault();
            List<InterestSubCategory> subList = _context.InterestSubCategory.Where(i => i.InterestCategoryId == interests.InterestCategoryId).ToList();
            interests.InterestSubCategory = _context.InterestSubCategory.Where(i => i.InterestSubCategoryId == interests.InterestSubCategoryId).FirstOrDefault();
            if (interests.InterestSubCategory == null || interests.InterestCategory.InterestCategoryId != interests.InterestSubCategory.InterestCategoryId)
            {
                ViewData["InterestCategoryId"] = new SelectList(_context.InterestCategory, "InterestCategoryId", "InterestCategoryName", interests.InterestCategoryId);
                ViewData["InterestSubCategoryId"] = new SelectList(subList, "InterestSubCategoryId", "InterestSubCategoryName", interests.InterestSubCategoryId);
                return View(interests);
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(interests);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InterestsExists(interests.InterestId))
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
            ViewData["InterestCategoryId"] = new SelectList(_context.InterestCategory, "InterestCategoryId", "InterestCategoryName", interests.InterestCategoryId);
            ViewData["InterestSubCategoryId"] = new SelectList(_context.InterestSubCategory, "InterestSubCategoryId", "InterestSubCategoryName", interests.InterestSubCategoryId);
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "Description", interests.ProfileId);
            return View(interests);
        }

        // GET: Interests/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var interests = await _context.Interests
                .Include(i => i.InterestCategory)
                .Include(i => i.InterestSubCategory)
                .Include(i => i.Profile)
                .FirstOrDefaultAsync(m => m.InterestId == id);
            if (interests == null)
            {
                return NotFound();
            }

            return View(interests);
        }

        // POST: Interests/Delete/5
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var interests = await _context.Interests.FindAsync(id);
            _context.Interests.Remove(interests);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InterestsExists(int id)
        {
            return _context.Interests.Any(e => e.InterestId == id);
        }
    }
}
