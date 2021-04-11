using Affinity.Data;
using Affinity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Affinity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, UserManager<User> user)
        {
            _logger = logger;
            _context = context;
            _userManager = user;
        }

        public async Task<IActionResult> IndexAsync()
        {
            User user = await _userManager.GetUserAsync(User);

            if (user != null)
            {
                var profile = _context.Profile.FirstOrDefault(r => r.UserId == user.Id);

                if (profile == null)
                {
                    Profile newProfile = new Profile { ProfileName = user.Name, User = user, UserId = user.Id, Birthday = user.BirthDate };
                    _context.Add(newProfile);
                    await _context.SaveChangesAsync();
                    return View();
                }
                else
                {
                    return View();
                }
            }

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        static async Task Execute()
        {
            
        }
    }
}
