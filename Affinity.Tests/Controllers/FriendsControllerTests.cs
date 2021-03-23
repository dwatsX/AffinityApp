using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Affinity.Tests.Controllers;
using Affinity.Controllers;
using Affinity.Models;
using Affinity.Tests.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;
using System;
using Affinity.ViewModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace Affinity.Tests.Controllers
{
    public class FriendsControllerTests : DBContextController<FriendsController>
    {
        private User identityUser;
        private User user;
        private Profile profile;


        public override void SeedDatabase()
        {
            _context.AddRange(
                identityUser = CreateUser(66, IdentityPrincipalUserName, "email@email.com", true, "Password0!", "Name1", "human", "555-555-5555", new DateTime(1970, 01, 01)),
                user = CreateUser(616, "testUser", "email@email.com", true, "Password1!", "name", "Female", "5195551234", DateTime.Now),
                profile = CreateProfile(166, user.Id, "profile")
            );
        }


        public override FriendsController CreateControllerSUT()
        {
            return new FriendsController(_context, _mockUserManager.Object);
        }

        [Fact]
        public async Task Index_ReturnsViewResult()
        {
            // Arrange
            GetUserAsyncReturns = new User { Id = 166};

            // Act
            var result = await ControllerSUT.Index();

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            var friends = Assert.IsAssignableFrom<FriendsViewModel>(viewResult.ViewData.Model);
            Assert.IsAssignableFrom<IEnumerable<UserRelationship>>(friends.FriendRelationships);
            Assert.IsAssignableFrom<IEnumerable<UserRelationship>>(friends.PendingRelationships);
        }

        [Fact]
        public void Add_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = ControllerSUT.Add(profile.ProfileId.ToString());

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Theory]   
        [InlineData(null)]
        public async Task AddUser_ReturnsViewResult_WithModelError_WhenUsernamIsNullOrEmpty(int id)
        {
            // Arrange
            FindByNameAsyncReturns = new User { Id = 1, UserName = "admin" };

            // Act
            var result = await ControllerSUT.AddUser(id);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<ModelStateEntry>(ControllerSUT.ModelState["username"]);
        }

        [Fact]
        public async Task AddUser_ReturnsViewResult_WithModelError_WhenUserIsNotFound()
        {
            // Arrange
            GetUserAsyncReturns = new User { Id = 2, UserName = null };
            FindByNameAsyncReturns = null;

            // Act
            var result = await ControllerSUT.AddUser(0);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<ModelStateEntry>(ControllerSUT.ModelState["username"]);
        }

 
        [Fact]
        public async Task AddUser_ReturnsRedirectToActionResult_WhenRelatingIsAdded()
        {
            // Arrange
            FindByNameAsyncReturns = new User { Id = 1, UserName = "admin" };
            GetUserAsyncReturns = new User { Id = 2, UserName = "user" };

            // Act
            var result = await ControllerSUT.AddUser(0);

            // Assert
            var redirectToActionResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            Assert.Equal("Index", redirectToActionResult.ActionName);
            Assert.IsAssignableFrom<string>(ControllerSUT.TempData["FriendInvite"]);
        }

        [Fact]
        public async Task Remove_ReturnsNotFound_WhenRelatedDoesNotExist()
        {
            // Arrange
            GetUserAsyncReturns = new User { Id = 2, UserName = "user2" };
            FindByNameAsyncReturns = new User { Id = 1, UserName = "user1" };

            // add relationship in opposite order
            _context.UserRelationships.Add(new UserRelationship { RelatingProfileId = 1, RelatedProfileId = 2 });

            // Act
            await _context.SaveChangesAsync();

            var result = await ControllerSUT.Remove("user1");

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Theory]
        [InlineData("     ")]
        [InlineData("")]
        [InlineData(null)]
        public async Task RemoveConfirmed_ReturnsNotFound_WhenUsernameIsNullOrEmpty(string username)
        {
            // Arrange

            // Act
            var result = await ControllerSUT.RemoveConfirmed(username);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }
    }
}
