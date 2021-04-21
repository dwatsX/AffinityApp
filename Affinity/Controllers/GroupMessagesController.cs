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
    public class GroupMessagesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public GroupMessagesController(ApplicationDbContext context, UserManager<User> user)
        {
            _context = context;
            _userManager = user;
        }

        // GET: GroupMessages
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            //var applicationDbContext = _context.GroupMessage.Include(g => g.Group);
            //return View(await applicationDbContext.ToListAsync());

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var profile = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);
            var thisGroup = _context.Groups
                .Where(u => u.GroupId == id)
                .FirstOrDefault();

            if (thisGroup == null)
            {
                return NotFound();
            }
            else
            {

                ViewData["groupId"] = id;
                ViewData["profileId"] = profile.ProfileId;
                ViewData["SendingUserProfileName"] = profile.ProfileName;
                ViewData["groupName"] = thisGroup.GroupName;

                var applicationDbContext = _context.GroupMessages.Where(f => f.GroupId == id);

                return View(await applicationDbContext.ToListAsync());

            }
        }

        // GET: GroupMessages/Create
        public async Task<IActionResult> Create(int id)
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var profile = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);
            var sendingUser = _context.Profile.FirstOrDefault(r => r.ProfileId == profile.ProfileId);

            ViewData["GroupId"] = id;
            ViewData["SendingUserProfileId"] = sendingUser.ProfileId;
            return View();

            //ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId");
            //return View();
        }

        // POST: GroupMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("GroupMessageId,SendingUserProfileId,SendingUserProfileName,MessageContent,MessageDateTime,GroupId")] GroupMessage groupMessage)
        {
            groupMessage.MessageDateTime = DateTime.Now.ToString();
            if (ModelState.IsValid)
            {
                _context.Add(groupMessage);
                await _context.SaveChangesAsync();

                User user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Problem();
                }

                var thisGroup = _context.Groups
                    .Where(u => u.GroupId == groupMessage.GroupId)
                    .FirstOrDefault();

                return RedirectToAction("Index", new { id = thisGroup.GroupId });
            }
            ViewData["GroupId"] = new SelectList(_context.Groups, "GroupId", "GroupId", groupMessage.GroupId);
            return View(groupMessage);
        }

        private bool GroupMessageExists(int id)
        {
            return _context.GroupMessages.Any(e => e.GroupMessageId == id);
        }
    }
}
