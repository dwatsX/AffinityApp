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
    public class FriendMessagesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public FriendMessagesController(ApplicationDbContext context, UserManager<User> user)
        {
            _context = context;
            _userManager = user;
        }

        // GET: FriendMessages
        public async Task<IActionResult> Index([FromRoute] int id)
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var profile = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);
            var thisRelationship = _context.UserRelationships
                .Where(u => u.UserRelationshipId == id)
                .FirstOrDefault();

            if (thisRelationship.RelatingProfileId == profile.ProfileId)
            {
                var otherUser = _context.Profile.FirstOrDefault(r => r.ProfileId == thisRelationship.RelatedProfileId);
                ViewData["profileName"] = otherUser.ProfileName;
            }
            else
            {
                var otherUser = _context.Profile.FirstOrDefault(r => r.ProfileId == thisRelationship.RelatingProfileId);
                ViewData["profileName"] = otherUser.ProfileName;
            }

            ViewData["userRelationshipId"] = id;
            ViewData["profileId"] = profile.ProfileId;

            var applicationDbContext = _context.FriendMessages.Include(f => f.UserRelationship)
                .Where(f => f.UserRelationshipId == id);

            return View(await applicationDbContext.ToListAsync());
        }

        // GET: FriendMessages/Create
        public async Task<IActionResult> Create([FromRoute] int id)
        {
            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var profile = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);
            var sendingUser = _context.Profile.FirstOrDefault(r => r.ProfileId == profile.ProfileId);
            var receivingUser = _context.UserRelationships
                .Where(u => u.UserRelationshipId == id)
                .Where(u => u.RelatingProfileId != profile.ProfileId)
                .FirstOrDefault();

            ViewData["UserRelationshipId"] = id;
            ViewData["SendingProfileId"] = sendingUser.ProfileId;
            return View();
        }

        // POST: FriendMessages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FriendMessageId,SendingUserId,ReceivingUserId,MessageContent,UserRelationshipId,MessageDateTime")] FriendMessage friendMessage)
        {
            friendMessage.MessageDateTime = DateTime.Now.ToString();
            if (ModelState.IsValid)
            {
                _context.Add(friendMessage);
                await _context.SaveChangesAsync();

                User user = await _userManager.GetUserAsync(User);
                if (user == null)
                {
                    return Problem();
                }

                var thisRelationship = _context.UserRelationships
                    .Where(u => u.UserRelationshipId == friendMessage.UserRelationshipId)
                    .FirstOrDefault();

                return RedirectToAction("Index", new { id = thisRelationship.UserRelationshipId });
            }
            ViewData["UserRelationshipId"] = new SelectList(_context.UserRelationships, "UserRelationshipId", "UserRelationshipId", friendMessage.UserRelationshipId);
            return View(friendMessage);
        }

    }
}
