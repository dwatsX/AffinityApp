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
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Interests.Include(i => i.InterestCategory).Include(i => i.InterestSubCategory).Include(i =>i.Profile);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Interests/Details/5
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
        public IActionResult Create()
        {
            ViewData["InterestCategoryId"] = new SelectList(_context.InterestCategory, "InterestCategoryId", "InterestCategoryName");
            ViewData["InterestSubCategoryId"] = new SelectList(_context.InterestSubCategory, "InterestSubCategoryId", "InterestSubCategoryName");
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName");
            return View();
        }

        // POST: Interests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InterestId,InterestCategoryId,InterestSubCategoryId,ProfileId")] Interests interests)
        {
            if (ModelState.IsValid)
            {
                _context.Add(interests);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["InterestCategoryId"] = new SelectList(_context.InterestCategory, "InterestCategoryId", "InterestCategoryName", interests.InterestCategoryId);
            ViewData["InterestSubCategoryId"] = new SelectList(_context.InterestSubCategory, "InterestSubCategoryId", "InterestSubCategoryName", interests.InterestSubCategoryId);
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", interests.ProfileId);
            return View(interests);
        }

        // GET: Interests/Edit/5
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
            ViewData["InterestCategoryId"] = new SelectList(_context.InterestCategory, "InterestCategoryId", "InterestCategoryName", interests.InterestCategoryId);
            ViewData["InterestSubCategoryId"] = new SelectList(_context.InterestSubCategory, "InterestSubCategoryId", "InterestSubCategoryName", interests.InterestSubCategoryId);
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", interests.ProfileId);
            return View(interests);
        }

        // POST: Interests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InterestId,InterestCategoryId,InterestSubCategoryId,ProfileId")] Interests interests)
        {
            if (id != interests.InterestId)
            {
                return NotFound();
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
