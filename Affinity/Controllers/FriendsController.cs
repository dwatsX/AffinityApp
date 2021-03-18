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

            var test = await _context.UserRelationships
                .ToListAsync();

            var friends = await _context.UserRelationships
                .Include(r => r.RelatedUser)
                .Where(r => r.RelatingUserId == user.Id && r.Type == Relationship.Friend)
                .ToListAsync();

            
            var pendings = await _context.UserRelationships
                .Include(r => r.RelatedUser)
                .Where(r => r.RelatingUserId == user.Id && r.Type == Relationship.Pending)
                .ToListAsync();

            return View(new FriendsViewModel
            {
                FriendRelationships = friends,
                PendingRelationships = pendings,
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
                }) ;
            }

        }

        // POST: Friends/Add
        [HttpPost, ActionName("Add")]
        [Authorize]
        public async Task AddUser(int userProfileId)
        {
            if (userProfileId == 0)
            {
                ModelState.AddModelError("username", $"Username is required");
                //return View();
            }

            User userInviting = await _userManager.GetUserAsync(User);
            if (userInviting == null)
            {
                //return Problem();
            }

            var profileInviting =  _context.Profile
                .Include(u => u.User)
                .FirstOrDefault(u => u.UserId == userInviting.Id);

            var profileInvited =  _context.Profile
                 .Include(u => u.User)
                .FirstOrDefault(u => u.ProfileId == userProfileId);

            if (profileInvited == null)
            {
                ModelState.AddModelError("user", $"No results found matching \"{profileInvited.ProfileName}\"");
                //return View();
            }
            else if (profileInvited.ProfileId == userProfileId)
            {
                ModelState.AddModelError("user", "Cannot invite yourself");
                //return View();
            }

            //TempData["FriendInvite"] = $"A friend invite was sent to {userInviting.Profile.ProfileName}.";

            //// friend relationship (or invite) already exists
            //if (await _context.UserRelationships.AnyAsync(r => r.RelatingUserId == user.Id && r.RelatedUserId == userInviting.Id))
            //{
            //    return RedirectToAction(nameof(Index));
            //}

            var relationship = new UserRelationship
            {
                RelatingUserId = profileInviting.UserId,
                RelatedUserId = profileInvited.UserId,
                RelatedUser = profileInviting,
                RelatingUser = profileInvited,
                Type = Relationship.Pending
            };

            // friend has already sent relationship invite - add them as a friend without invite
            //var existingRelationship = await _context.UserRelationships.FirstOrDefaultAsync(r => r.RelatingUserId == profileInvited.ProfileId && r.RelatedUserId == profileInviting.ProfileId);
            //if (existingRelationship != null)
            //{
            //    existingRelationship.Type = Relationship.Friend;
            //    _context.UserRelationships.Update(existingRelationship);

            //    relationship.Type = Relationship.Friend;
            //    TempData["FriendInvite"] = $"{profileInvited.ProfileName} has been added to your friends.";
            //}
            //profileInviting.RelatingRelationships.Add(relationship);

            _context.UserRelationships.Add(relationship);
            //_context.Profile.Update(profileInviting);
            await _context.SaveChangesAsync();

           // return RedirectToAction(nameof(Index));
        }

        // GET: Friends/Remove/username
        [HttpGet, Route("Friends/Remove/{username}")]
        [Authorize]
        public async Task<IActionResult> Remove(string username)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            User userRemoving = await _userManager.FindByNameAsync(username);
            if (userRemoving.Id == user.Id)
            {
                return BadRequest();
            }

            var relationship = await _context.UserRelationships
                .Include(r => r.RelatedUser)
                .FirstOrDefaultAsync(r => r.RelatingUserId == user.Id && r.RelatedUserId == userRemoving.Id);
            if (relationship == null)
            {
                return NotFound();
            }

            return View(relationship);
        }

        // POST: Friends/Remove/username
        [HttpPost, ActionName("Remove")]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RemoveConfirmed(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                return NotFound();
            }

            User user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Problem();
            }

            User userRemoving = await _userManager.FindByNameAsync(userId);
            if (user.Id == userRemoving.Id)
            {
                return BadRequest();
            }

            // get relationships
            var relationships = await _context.UserRelationships
                .Where(r => (r.RelatingUserId == user.Id && r.RelatedUserId == userRemoving.Id) ||
                    (r.RelatingUserId == userRemoving.Id && r.RelatedUserId == user.Id))
                .ToArrayAsync();
            _context.RemoveRange(relationships);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
