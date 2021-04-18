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
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public EventController(ApplicationDbContext context, UserManager<User> user)
        {
            _context = context;
            _userManager = user;
        }

        // GET: Event
        public async Task<IActionResult> Index()
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var profile = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);
            ViewData["ProfileID"] = profile.ProfileId;

            var applicationDbContext = _context.Event.Include(g => g.Group);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Event/Details/5
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

            var profile = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);

            var events = await _context.Event
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.EventId == id);

            var groupCreator = events.Group.ProfileId;
            if (groupCreator == profile.ProfileId)
            {
                ViewData["eventCreator"] = true;
            }
            ViewData["eventCreatorID"] = events.Group.ProfileId;

            var eventCreatorName = _context.Profile.FirstOrDefault(r => r.ProfileId == events.Group.ProfileId);

            ViewData["eventCreatorName"] = eventCreatorName.ProfileName;

            if (events == null)
            {
                var groupEvent = await _context.Event
                    .Include(g => g.Group)
                    .FirstOrDefaultAsync(m => m.GroupId == id);
                return View(groupEvent);

            }
            else
            {
                return View(events);
            }

        }

        // GET: Event/Create
        public IActionResult Create([FromRoute] int id)
        {

            ViewData["GroupID"] = id.ToString();
            //ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            return View();
        }

        // POST: Event/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventId,GroupId,EventName,EventDescription,EventDateTime")] Event events)
        {
            if (ModelState.IsValid)
            {
                _context.Add(events);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", events.GroupId);
            return View(events);
        }

        // GET: Event/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Event.FindAsync(id);
            if (events == null)
            {
                return NotFound();
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", events.GroupId);

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var group = await _context.Groups
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.GroupId == events.GroupId);
            if (group == null)
            {
                return NotFound();
            }

            var loggedIn = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);

            if (loggedIn.ProfileId == group.ProfileId)
            {
                return View(events);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Event/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EventId,GroupId,EventName,EventDescription,EventDateTime")] Event events)
        {
            if (id != events.EventId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(events);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventExists(events.EventId))
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
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", events.GroupId);
            return View(events);
        }

        // GET: Event/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var events = await _context.Event
                .Include(g => g.Group)
                .FirstOrDefaultAsync(m => m.EventId == id);

            if (events == null)
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var group = await _context.Groups
                .Include(p => p.Profile)
                .FirstOrDefaultAsync(m => m.GroupId == events.GroupId);
            if (group == null)
            {
                return NotFound();
            }

            var loggedIn = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);

            if (loggedIn.ProfileId == group.ProfileId)
            {
                return View(events);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var events = await _context.Event.FindAsync(id);
            _context.Event.Remove(events);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventExists(int id)
        {
            return _context.Event.Any(e => e.EventId == id);
        }
    }
}
