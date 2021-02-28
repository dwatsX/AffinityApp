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

namespace Affinity.Tests.Controllers
{
    public class ProfileControllerTests : DBContextController<ProfileController>
    {
        private User identityUser;
        private User user;
        private Profile profile;

        public override ProfileController CreateControllerSUT()
        {
            return new ProfileController(_context, _mockUserManager.Object);
        }


        public override void SeedDatabase()
        {
            _context.AddRange(
                identityUser = CreateUser(66, IdentityPrincipalUserName, "email@email.com", true, "Password0!", "Name1", "human", "555-555-5555", new DateTime(1970, 01, 01)),
                user = CreateUser(616, "testUser", "email@email.com", true, "Password1!", "name", "Female", "5195551234", DateTime.Now),
                profile = CreateProfile(166, user.Id, "profile")
            );
        }

        [Fact]
        public async Task Index_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Index();

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(666)]
        public async Task Details_ReturnsNotFound_WhenIdIsNotFound(int? id)
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Details(id);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public async Task Details_ReturnsViewResult_WhenIdIsFound()
        {
            // Arrange
            // Act
            var result = await ControllerSUT.Details(166);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<Profile>(viewResult.ViewData.Model);
        }

        [Fact]
        public void Create_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = ControllerSUT.Create();

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);

            Assert.Null(viewResult.ViewData.Model);
        }

        [Fact]
        public async Task Create_ReturnsRedirectToActionResult_WhenProfileIsCreated()
        {
            // Arrange
            GetUserAsyncReturns = identityUser;

            // Act
            var result = await ControllerSUT.Create(identityUser.Id, new Profile { UserId = identityUser.Id, Description = "new" });

            // Assert
            var redirectResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            Assert.Equal(nameof(ProfileController.Index), redirectResult.ActionName);
        }

        [Fact]
        public async Task Edit_ReturnsViewResult_WhenIdIsFound()
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Edit(166);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<Profile>(viewResult.ViewData.Model);

        }

        [Theory]
        [InlineData(null)]
        [InlineData(666)]
        public async Task Edit_ReturnsNotFound_WhenProfileIdIsNotFound(int? id)
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Edit(666);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(666)]
        public async Task Edit_ReturnsNotFound_WhenProfileIdDoesNotMatchPostBody(int id)
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Edit(666);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsViewResult_WhenIdIsFound()
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Delete(166);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<Profile>(viewResult.ViewData.Model);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(666)]
        public async Task Delete_ReturnsNotFound_WhenIdIsNotFound(int? id)
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Delete(id);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteConfirmed_ReturnsRedirectToActionResult_WhenProfileIsDeleted()
        {
            // Arrange

            // Act
            var result = await ControllerSUT.DeleteConfirmed(166);

            // Assert
            var redirectResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            Assert.Equal(nameof(ProfileController.Index), redirectResult.ActionName);
        }


    }
}
