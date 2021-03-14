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
using Affinity.ViewModels;

namespace Affinity.Controllers
{
    public class MatchesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public MatchesController(ApplicationDbContext context, UserManager<User> user)
        {
            _context = context;
            _userManager = user;
        }

        // GET: Matches
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var profile = await _context.Profile
                .Include(p => p.Interests)
                    .ThenInclude(i => i.InterestSubCategory)
                    .ThenInclude(i => i.InterestCategory)
                .FirstOrDefaultAsync(m => m.UserId == user.Id);


            var otherProfiles = await _context.Profile
                .Include(p => p.Interests)
                    .ThenInclude(i => i.InterestSubCategory)
                    .ThenInclude(i => i.InterestCategory)
                .Where(p => p.UserId != user.Id)
                .ToListAsync();

            profile.Matches.Clear();

            foreach (var o in otherProfiles)
            {
                List<Interests> interests = new List<Interests>();
                o.Matches.Clear();
                int count = 0;
                foreach (var p in profile.Interests)
                {
                    foreach (var n in o.Interests)
                    {
                        if (p.InterestSubCategoryId == n.InterestSubCategoryId)
                        {
                            count++;
                            interests.Add(n);
                        }
                    }
                }
                if (count >= 2)
                {
                    profile.Matches.Add(new Matches { ProfileId = profile.ProfileId, MatchedProfileId = o.ProfileId, Profile = profile, MatchedProfile = o, SharedInterests = interests });
                }

            }

            _context.Update(profile);
            await _context.SaveChangesAsync();

            var viewModel = new MatchesViewModel
            {

            };

            return View(profile.Matches);
            //IQueryable<Matches> matchQuery = _context.Matches.Include(g => g.MatchId).Where(p => p.ProfileId =);


            //if (user1 == null)
            //{
            //    return NotFound();
            //}

            //var applicationDbContext = _context.Matches.Include(m => m.MatchedProfile).Include(m => m.Profile);
            //return View(await applicationDbContext.ToListAsync());
        }

        // GET: Matches/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .Include(m => m.MatchedProfile)
                .Include(m => m.Profile)
                .FirstOrDefaultAsync(m => m.MatchId == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }

        // GET: Matches/Create
        public IActionResult Create()
        {
            ViewData["MatchedProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName");
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName");
            return View();
        }

        // POST: Matches/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MatchId,ProfileId,MatchedProfileId")] Matches matches)
        {
            if (ModelState.IsValid)
            {
                _context.Add(matches);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MatchedProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", matches.MatchedProfileId);
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", matches.ProfileId);
            return View(matches);
        }

        // GET: Matches/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches.FindAsync(id);
            if (matches == null)
            {
                return NotFound();
            }
            ViewData["MatchedProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", matches.MatchedProfileId);
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", matches.ProfileId);
            return View(matches);
        }

        // POST: Matches/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MatchId,ProfileId,MatchedProfileId")] Matches matches)
        {
            if (id != matches.MatchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(matches);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MatchesExists(matches.MatchId))
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
            ViewData["MatchedProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", matches.MatchedProfileId);
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", matches.ProfileId);
            return View(matches);
        }

        // GET: Matches/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var matches = await _context.Matches
                .Include(m => m.MatchedProfile)
                .Include(m => m.Profile)
                .FirstOrDefaultAsync(m => m.MatchId == id);
            if (matches == null)
            {
                return NotFound();
            }

            return View(matches);
        }

        // POST: Matches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var matches = await _context.Matches.FindAsync(id);
            _context.Matches.Remove(matches);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MatchesExists(int id)
        {
            return _context.Matches.Any(e => e.MatchId == id);
        }
    }
}
