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
    public class GroupsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;


        public GroupsController(ApplicationDbContext context, UserManager<User> user)
        {
            _context = context;
            _userManager = user;
        }

        // GET: Groups
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Groups.Include(p => p.Profile).Include(p => p.MemberProfiles);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Groups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);

            var profile = await _context.Profile
                .FirstOrDefaultAsync(m => m.UserId == user.Id);

            var group = await _context.Groups
                .Include(p => p.Profile)
                .Include(p => p.MemberProfiles)
                .Include(p => p.GroupEvents)
                .FirstOrDefaultAsync(m => m.GroupId == id);

            if (group == null)
            {
                return NotFound();
            }

            if (group.ProfileId == profile.ProfileId) 
            {
                ViewData["groupCreator"] = "true";
            }
            ViewData["groupCreatorName"] = group.Profile.ProfileName;
            ViewData["groupCreatorID"] = group.ProfileId;

            return View(new GroupViewModel
            {
                GroupId = group.GroupId,
                Profile = group.Profile,
                ProfileId = group.ProfileId,
                ImageUrl = group.ImageUrl,
                GroupName = group.GroupName,
                GroupDescription = group.GroupDescription,
                Members = group.MemberProfiles.ToList(),
                Events = group.GroupEvents.ToList()

            });
        }

        // GET: Groups/Create
        public async Task<IActionResult> Create()
        {
            User user = await _userManager.GetUserAsync(User);

            var profile = _context.Profile.FirstOrDefault(p => p.UserId == user.Id);
            var group = new Group { ProfileId = profile.ProfileId };

            ViewData["ProfileID"] = profile.ProfileId;

            return View(group);
        }

        // POST: Groups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupId,GroupName,GroupDescription,ProfileId,ImageUrl")] Group group)
        {
            if (ModelState.IsValid)
            {
                var profile = _context.Profile.Where(g => g.ProfileId == group.ProfileId).FirstOrDefault();
                group.MemberProfiles.Add(profile);
                _context.Add(group);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", group.ProfileId);
            return View(group);
        }

        // GET: Groups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.Groups.FindAsync(id);
            if (group == null)
            {
                return NotFound();
            }
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", group.ProfileId);
            ViewData["GroupId"] = id;

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var loggedIn = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);

            if (loggedIn.ProfileId == group.ProfileId)
            {
                return View(group);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Groups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GroupId,GroupName,GroupDescription,ProfileId,ImageUrl")] Group group)
        {
            if (id != group.GroupId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(group);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GroupExists(group.GroupId))
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
            ViewData["ProfileId"] = new SelectList(_context.Profile, "ProfileId", "ProfileName", group.ProfileId);
            return View(group);
        }

        // POST: JoinGroup/Add/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Group group = await _context.Groups.FirstOrDefaultAsync(g => g.GroupId == id);
            if (group == null)
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var profile = _context.Profile.Where(p => p.UserId == user.Id).FirstOrDefault();
            if (profile == null)
            {
                TempData["NoProfile"] = $"Go to Profile Page First Please!";
                return RedirectToAction("Index", "Groups");
            }

            bool alreadyJoined = group.MemberProfiles.Any(g => g.ProfileId == profile.ProfileId);
            if (!alreadyJoined)
            {
                group.MemberProfiles.Add(profile);
                _context.Groups.Update(group);
                await _context.SaveChangesAsync();
                TempData["Joined"] = $"Joined {group.GroupName}";

            }
            else
            {
                TempData["Joined"] = $"You've already joined {group.GroupName}!";
            }

            return RedirectToAction("Index", "Groups");
        }

        // GET: Groups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var group = await _context.Groups
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.GroupId == id);
            if (group == null)
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var loggedIn = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);

            if (loggedIn.ProfileId == group.ProfileId)
            {
                return View(group);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Groups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var group = await _context.Groups.FindAsync(id);
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GroupExists(int id)
        {
            return _context.Groups.Any(e => e.GroupId == id);
        }
    }
}
