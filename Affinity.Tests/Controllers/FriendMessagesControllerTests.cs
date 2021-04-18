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
   
    public class FriendMessagesControllerTests : DBContextController<FriendMessagesController>
    {
        private User identityUser;
        private User user1;
        private User user2;
        private Profile profile1;
        private Profile profile2;

        public override void SeedDatabase()
        {
            _context.AddRange(
                identityUser = CreateUser(66, IdentityPrincipalUserName, "email@email.com", true, "Password0!", "Name1", "human", "555-555-5555", new DateTime(1970, 01, 01)),
                user1 = CreateUser(299, "testUser", "email@email.com", true, "Password1!", "name", "Female", "5195551234", DateTime.Now),
                user2 = CreateUser(300, "testUser", "email@email.com", true, "Password1!", "name", "Female", "5195551234", DateTime.Now),
                profile1 = CreateProfile(166, user1.Id, "profile1"),
                profile2 = CreateProfile(167, user2.Id, "profile2")
            );
        }

        public override FriendMessagesController CreateControllerSUT()
        {
            return new FriendMessagesController(_context, _mockUserManager.Object);
        }

        [Fact]
        public async Task Index_ReturnsViewResult()
        {
            // Arrange
            GetUserAsyncReturns = user1;

            Profile testProfile = new Profile
            {
                ProfileId = 1,
                UserId = user1.Id
            };
            _context.Add(testProfile);

            UserRelationship testRelationship = new UserRelationship
            {
                UserRelationshipId = 1,
                RelatingUser = user1,
                RelatedUser = user2,
                RelatingProfile = user1.Profile,
                RelatedProfile = user2.Profile,
                Type = Relationship.Friend,
            };
            _context.Add(testRelationship);

            _context.FriendMessages.Add(new FriendMessage
            {
                FriendMessageId = 1,
                SendingUserId = user1.Id,
                ReceivingUserId = 99,
                MessageContent = "hey",
                MessageDateTime = DateTime.Now.ToString(),
                UserRelationship = testRelationship,
                UserRelationshipId = testRelationship.UserRelationshipId
            });

            await _context.SaveChangesAsync();

            // Act
            var result = await ControllerSUT.Index(testRelationship.UserRelationshipId);

            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public async Task Index_ReturnsNotFound_WhenUserRelationshipIsNotFound()
        {
            // Arrange
            User user = _context.Users.FirstOrDefault();
            GetUserAsyncReturns = user;

            UserRelationship testRelationship = new UserRelationship
            {
                UserRelationshipId = 1,
                RelatingUser = profile1.User,
                RelatedUser = profile2.User,
                RelatingProfile = user1.Profile,
                RelatedProfile = user2.Profile,
                Type = Relationship.Friend
            };

            // Act
            var result = await ControllerSUT.Index(testRelationship.UserRelationshipId);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public async Task Create_ReturnsViewResult()
        {
            // Arrange
            GetUserAsyncReturns = user1;

            Profile testProfile = new Profile
            {
                ProfileId = 1,
                UserId = user1.Id
            };
            _context.Add(testProfile);

            UserRelationship testRelationship = new UserRelationship
            {
                UserRelationshipId = 1,
                RelatingUser = user1,
                RelatedUser = user2,
                RelatingProfile = testProfile,
                RelatedProfile = testProfile,
                Type = Relationship.Friend
            };
            _context.Add(testRelationship);
            await _context.SaveChangesAsync();

            // Act
            var result = await ControllerSUT.Create(testRelationship.UserRelationshipId);

            // Assert
            Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Fact]
        public async Task Add_ReturnsRedirectResult_WhenFriendMessageIsAdded() 
        {
            // Arrange
            GetUserAsyncReturns = user1;

            Profile testProfile = new Profile
            {
                ProfileId = 1,
                UserId = user1.Id
            };
            _context.Add(testProfile);

            UserRelationship testRelationship = new UserRelationship
            {
                UserRelationshipId = 1,
                RelatingUser = user1,
                RelatedUser = user2,
                RelatingProfile = testProfile,
                RelatedProfile = testProfile,
                Type = Relationship.Friend
            };
            _context.Add(testRelationship);

            FriendMessage testMessage = new FriendMessage
            {
                FriendMessageId = 1,
                SendingUserId = testProfile.ProfileId,
                ReceivingUserId = 99,
                MessageContent = "hey",
                MessageDateTime = DateTime.Now.ToString(),
                UserRelationshipId = testRelationship.UserRelationshipId
            };

            SimulateModelStateValidation(testMessage);

            await _context.SaveChangesAsync();

            var result = await ControllerSUT.Create(testMessage);
            var redirectResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);

            Assert.Equal(nameof(FriendMessagesController.Index), redirectResult.ActionName);
        }

    }
}
