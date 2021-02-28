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
    public class ImageControllerTests : DBContextController<ImageController>
    {
        private User user;
        private Profile profile;
        private Image image;

        public override ImageController CreateControllerSUT()
        {
            return new ImageController(_context);
        }

        public override void SeedDatabase()
        {
            _context.AddRange(
                user = CreateUser(333, "testUser", "email@email.com", true, "Password1!", "name", "Female", "5195551234", DateTime.Now),
                profile = CreateProfile(313, user.Id, "profile"),
                image = CreateImage(331, profile.ProfileId, "https://i.picsum.photos/id/1003/1181/1772.jpg?hmac=oN9fHMXiqe9Zq2RM6XT-RVZkojgPnECWwyEF1RvvTZk")

            ) ;
        }

        [Fact]
        public async Task Index_ReturnsViewResult()
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Index(333);

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
            var result = await ControllerSUT.Details(331);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<Image>(viewResult.ViewData.Model);
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
        public async Task Edit_ReturnsViewResult_WhenIdIsFound()
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Edit(331);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<Image>(viewResult.ViewData.Model);

        }

        [Theory]
        [InlineData(null)]
        [InlineData(666)]
        public async Task Edit_ReturnsNotFound_WhenImageIdIsNotFound(int? id)
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Edit(id);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(666)]
        public async Task Edit_ReturnsNotFound_WhenImageIdDoesNotMatchPostBody(int id)
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Edit(331, new Image { ImageId = 55, ImageURL = "https://cdn.steamgriddb.com/thumb/df3cdfd672004f1a0058d81c56e7270a.png" });

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public async Task Delete_ReturnsViewResult_WhenImageIdIsFound()
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Delete(331);

            // Assert
            var viewResult = Assert.IsAssignableFrom<ViewResult>(result);
            Assert.IsAssignableFrom<Image>(viewResult.ViewData.Model);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(666)]
        public async Task Delete_ReturnsNotFound_WhenImageIdIsNotFound(int? id)
        {
            // Arrange

            // Act
            var result = await ControllerSUT.Delete(id);

            // Assert
            Assert.IsAssignableFrom<NotFoundResult>(result);
        }

        [Fact]
        public async Task DeleteConfirmed_ReturnsRedirectToActionResult_WhenImageIsDeleted()
        {
            // Arrange

            // Act
            var result = await ControllerSUT.DeleteConfirmed(331);

            // Assert
            var redirectResult = Assert.IsAssignableFrom<RedirectToActionResult>(result);
            Assert.Equal(nameof(ImageController.Index), redirectResult.ActionName);
        }


    }
}
