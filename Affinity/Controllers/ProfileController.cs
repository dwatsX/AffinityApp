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
using Microsoft.AspNetCore.Authorization;

namespace Affinity.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;


        public ProfileController(ApplicationDbContext context, UserManager<User> user)
        {
            _context = context;
            _userManager = user;
        }

        // GET: Profile
        [Authorize]
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);

            var profile = await _context.Profile
                .Include(p => p.Interests)
                .ThenInclude(i => i.InterestSubCategory)
                .ThenInclude(i => i.InterestCategory)
                .FirstOrDefaultAsync(m => m.UserId == user.Id);

            return RedirectToAction("Details", new { id = profile.ProfileId });
        }

        // GET: Profile/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var loggedIn = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);
            var loggedInProfile = loggedIn.ProfileId;

            var profileViewed = await _context.Profile
                   .Include(p => p.Interests)
                    .ThenInclude(i => i.InterestSubCategory)
                    .ThenInclude(i => i.InterestCategory)
                .FirstOrDefaultAsync(m => m.ProfileId == id);

            if (profileViewed == null)
            {
                return NotFound();
            }

            ViewData["loggedInProfile"] = loggedInProfile;
            if (profileViewed.ProfileId != null)
            {
                ViewData["profileBeingViewed"] = profileViewed.ProfileId;
            }

            return View(new ProfileViewModel
            {
                Profile = profileViewed,
                ProfileId = profileViewed.ProfileId,
                User = profileViewed.User,
                UserId = profileViewed.UserId,
                Images = await _context.Images
                    .Where(i => i.ProfileId == profileViewed.ProfileId)
                    .ToListAsync(),
                Interests = await _context.Interests
                    .Where(i => i.ProfileId == profileViewed.ProfileId)
                    .ToListAsync(),
                ProfileName = profileViewed.ProfileName,
                Description = profileViewed.Description,
                Discord = profileViewed.Discord,
                Instagram = profileViewed.Instagram,
                Location = profileViewed.Location,
                Occupation = profileViewed.Occupation,
                Education = profileViewed.Education,
                Cigarettes = profileViewed.Cigarettes,
                Marijuana = profileViewed.Marijuana,
                Age = Math.Round((((DateTime.Today) - profileViewed.Birthday).TotalDays / 365)).ToString(),
                Alcohol = profileViewed.Alcohol

            }) ;
        }

        // GET: Profile/Create
        [Authorize]
        public IActionResult Create()
        {         
            return View();
        }

        // POST: Profile/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int? id, [Bind("ProfileId,UserId,ProfileName,Description,Location,Occupation,Instagram,Discord,Cigarettes,Alcohol,Marijuana")] Profile profile)
        {
            User user = await _userManager.GetUserAsync(User);

            if (id == null && user == null)
            {
                return NotFound();
            }

            var profileExists = _context.Profile
             .FirstOrDefault(p => p.UserId == user.Id);

            if (profileExists == null && profile.UserId == 0)
            {
                profile.UserId = user.Id;
            }
            else
            {

                if (profileExists != null)
                {
                    TempData["AlreadyExists"] = $"You've already created a profile. Click edit to change your profile";
                    return RedirectToAction("Index");
                }
            }


            _context.Add(profile);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }

        // GET: Profile/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var profile = await _context.Profile.FindAsync(id);
            if (profile == null)
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var loggedIn = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);

            if (loggedIn.ProfileId == profile.ProfileId) {
                return View(profile);
            }
            else
            {
                return NotFound();
            }

        }

        // POST: Profile/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ProfileId,UserId,ProfileName,Description,Education,Birthday,Location,Occupation,Instagram,Discord,Cigarettes,Alcohol,Marijuana")] Profile profile)
        {
            if (id != profile.ProfileId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(profile);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfileExists(profile.ProfileId))
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
            return View(profile);
        }

        private bool ProfileExists(int id)
        {
            return _context.Profile.Any(e => e.ProfileId == id);
        }
    }
}
