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
using Affinity.ViewModels;

namespace Affinity.Controllers
{
    public class FriendsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public FriendsController(ApplicationDbContext context, UserManager<User> user)
        {
            _context = context;
            _userManager = user;
        }

        // GET: Friends
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

            var test = await _context.UserRelationships
                .ToListAsync();

            var friends = await _context.UserRelationships
                .Include(r => r.RelatedUser)
                .Include(r => r.RelatedProfile)
                .Include(r => r.RelatingProfile)
                .Include(r => r.RelatingUser)
                .Where(r => r.RelatingProfileId == profile.ProfileId && r.Type == Relationship.Friend || r.RelatedProfileId == profile.ProfileId && r.Type == Relationship.Friend)
                .ToListAsync();

            var pendings = await _context.UserRelationships
                .Include(r => r.RelatedUser)
                .Include(r => r.RelatedProfile)
                .Include(r => r.RelatingProfile)
                .Include(r => r.RelatingUser)
                .Where(r => r.RelatingProfileId == profile.ProfileId && r.Type == Relationship.Pending ||  r.RelatedProfileId == profile.ProfileId && r.Type == Relationship.Pending)
                .ToListAsync(); 

            return View(new FriendsViewModel
            {
                FriendRelationships = friends,
                PendingRelationships = pendings,
                Id = profile.ProfileId.ToString()
            });
        }

        // GET: Friends/Add
        [Authorize]
        public IActionResult Add(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }
            else
            {
                var person = _context.Profile
                     .FirstOrDefault(m => m.ProfileId.ToString() == id);

                return View(new FriendsViewModel
                {
                    Id = id,
                    Name = person.ProfileName
                });
            }

        }

        // POST: Friends/Add
        [HttpPost, ActionName("Add")]
        [Authorize]
        public async Task<IActionResult> AddUser(int id)
        {

            User userInviting = await _userManager.GetUserAsync(User);
            if (userInviting == null)
            {
                return Problem();
            }

            var profileInviting = _context.Profile
                .Include(u => u.User)
                .FirstOrDefault(u => u.UserId == userInviting.Id);

            var profileInvited = _context.Profile
                 .Include(u => u.User)
                .FirstOrDefault(u => u.ProfileId == id);

            User userInvited = await _userManager.FindByIdAsync(profileInvited.UserId.ToString());

            if (profileInvited == null)
            {
                ModelState.AddModelError("user", $"No results found matching \"{profileInvited.ProfileName}\"");
                return View();
            }


            // friend relationship (or invite) already exists
            if (await _context.UserRelationships.AnyAsync(r => r.RelatedUser.Id == userInvited.Id && r.RelatingUser.Id == userInviting.Id))
            {
                return RedirectToAction(nameof(Index));
            }

            var relationship = new UserRelationship
            {
                RelatingProfileId = profileInviting.ProfileId,
                RelatedProfileId = profileInvited.ProfileId,
                RelatedUser = userInvited,
                RelatingUser = userInviting,
                Type = Relationship.Pending
            };

            //friend has already sent relationship invite -add them as a friend without invite
            var existingRelationship = await _context.UserRelationships.FirstOrDefaultAsync(r => r.RelatedProfileId == profileInviting.ProfileId && r.RelatingProfileId == profileInvited.ProfileId);
            if (existingRelationship != null)
            {
                existingRelationship.Type = Relationship.Friend;
                _context.UserRelationships.Update(existingRelationship);        
                relationship.Type = Relationship.Friend;
                TempData["FriendInvite"] = $"{profileInvited.ProfileName} has been added to your friends.";
            }
            else
            {
                TempData["FriendInvite"] = $"A friend invite was sent to {userInviting.Profile.ProfileName}.";
                _context.UserRelationships.Add(relationship);
            }

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: Friends/Remove/id
        [HttpGet, Route("Friends/Remove/{id}")]
        [Authorize]
        public async Task<IActionResult> Remove(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var userRemoving = _userManager.FindByIdAsync(id);
            if (userRemoving.Id == user.Id)
            {
                return BadRequest();
            }

            var relationship = await _context.UserRelationships 
                .Include(r => r.RelatingUser)
                .FirstOrDefaultAsync(r => r.RelatingUser.Id == user.Id && r.RelatedUser.Id.ToString() == id || r.RelatedUser.Id == user.Id && r.RelatingUser.Id.ToString() == id);

            if (relationship == null)
            {
                return NotFound();
            }

            return View(relationship);
        }

        // POST: Friends/Remove/username
        [HttpPost, ActionName("Delete")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            var userRemoving = _context.Profile.FirstOrDefault(r => r.ProfileId.ToString() == id);
            if (user.Id == userRemoving.ProfileId)
            {
                return BadRequest();
            }

            // get relationships

            var relationship = await _context.UserRelationships
                .Include(r => r.RelatingUser)
                .FirstOrDefaultAsync(r => r.RelatingUser.Id == user.Id && r.RelatedProfileId.ToString() == id);
                
            _context.RemoveRange(relationship);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
