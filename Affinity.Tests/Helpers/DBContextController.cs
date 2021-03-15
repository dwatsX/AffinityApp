using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Affinity.Data;
using Affinity.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading;
using System.Threading.Tasks;
using Moq;

namespace Affinity.Tests.Helpers
{
    public abstract class DBContextController<TController> : IDisposable where TController : Controller
    {
        protected readonly SeedableDBContext _context;
        protected readonly Mock<ILogger<TController>> _mockLogger;
        protected readonly Mock<UserManager<User>> _mockUserManager;

        public TestableHttpContext TestableHttpContext { get; } = new TestableHttpContext();
        public User GetUserAsyncReturns { get; set; }
        public User FindByNameAsyncReturns { get; set; }

        public TController ControllerSUT { get; }

        /// <summary>
        /// When DBContextController is initalized and ApplicationDBContext is built should Seed be called. Default value is true.
        /// </summary>
        protected virtual bool SeedWithApplicationData { get; set; } = true;
        /// <summary>
        /// IdentityPrincipalUserName is used when DBContextController is intialized.
        /// </summary>
        protected virtual string IdentityPrincipalUserName { get; set; } = "TestUserName";

        public DBContextController()
        {
            _mockLogger = new Mock<ILogger<TController>>();
            _mockUserManager = new Mock<UserManager<User>>(Mock.Of<IUserStore<User>>(), null, null, null, null, null, null, null, null);

            // GetUserAsync
            _mockUserManager.Setup(s => s.GetUserAsync(It.IsAny<ClaimsPrincipal>()))
                .Returns(() => Task.FromResult(GetUserAsyncReturns));

            // FindByNameAsync
            _mockUserManager.Setup(s => s.FindByNameAsync(It.IsAny<string>()))
                .Returns(() => Task.FromResult(FindByNameAsyncReturns));

            var serviceProvider = new ServiceCollection()                
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();

            var contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            _context = new SeedableDBContext(contextOptions, SeedWithApplicationData);
            _context.Database.EnsureCreated();

            SetIdentityPrincipalGeneric(IdentityPrincipalUserName);

            // controller
            ControllerSUT = CreateControllerSUT();
            ControllerSUT.TempData = new TempDataDictionary(new DefaultHttpContext(), Mock.Of<ITempDataProvider>());
            ControllerSUT.ControllerContext = new ControllerContext
            {
                HttpContext = TestableHttpContext,
            };

            // seed
            SeedDatabase();
        }

        public abstract TController CreateControllerSUT();

        /// <summary>
        /// This is called after DBContext is created.
        /// </summary>
        public virtual void SeedDatabase()
        {

        }

        protected void SetIdentityPrincipalGeneric(string userName)
        {
            var identity = new GenericIdentity(userName);
            var principal = new GenericPrincipal(identity, null);

            TestableHttpContext.User = principal;
        }

        /// <summary>
        /// ModelState.IsValid will always result in true with Unit Tests.
        /// This method simulates the model validation just as ASP would do on request.
        /// </summary>
        /// <param name="model"></param>
        protected void SimulateModelStateValidation(object model)
        {
            // mimic the behaviour of the model binder which is responsible for Validating the Model
            var validationContext = new ValidationContext(model, null, null);
            var validationResults = new List<ValidationResult>();
            Validator.TryValidateObject(model, validationContext, validationResults, true);
            foreach (var validationResult in validationResults)
            {
                ControllerSUT.ModelState.AddModelError(validationResult.MemberNames.First(), validationResult.ErrorMessage);
            }
        }

        protected User CreateUser(int? id, string userName, string email, bool emailConfirmed, string password, string name, string gender, string phone, DateTime dob)
        {
            var hasher = new PasswordHasher<User>();
            return new User
            {
                Id = id ?? default,
                UserName = userName,
                NormalizedUserName = userName?.ToUpper(),
                Email = email,
                NormalizedEmail = email?.ToUpper(),
                EmailConfirmed = emailConfirmed,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                AccountNum = Guid.NewGuid().ToString(),
                Name = name,
                Gender = gender,
                PhoneNumber = phone,
                BirthDate = dob,
            };
        }

        protected Profile CreateProfile(int? id, int userId, string name)
        {
            return new Profile
            {
                ProfileId = id ?? default,
                UserId = userId,
                ProfileName = name
            };
        }

        protected Image CreateImage(int? id, int profileId, string url)
        {
            return new Image
            {
                ImageId = id ?? default,
                ProfileId = profileId,
                ImageURL = url
            };
        }

        protected Interests CreateInterest(int? id, int interestCategoryId, int InterestSubCategoryId, int profileId)
        {
            return new Interests
            {
                InterestId = id ?? default,
                InterestCategoryId = interestCategoryId,
                InterestSubCategoryId = InterestSubCategoryId,
                ProfileId = profileId
            };
        }

        public virtual void Dispose()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }
    }

    public class TestableHttpContext : HttpContext
    {
        public override ConnectionInfo Connection { get; }

        public override IFeatureCollection Features { get; }

        public override IDictionary<object, object> Items { get; set; }

        public override HttpRequest Request { get; }

        public override CancellationToken RequestAborted { get; set; }
        public override IServiceProvider RequestServices { get; set; }

        public override HttpResponse Response { get; }

        public override ISession Session { get; set; }
        public override string TraceIdentifier { get; set; }
        public override ClaimsPrincipal User { get; set; }

        public override WebSocketManager WebSockets { get; }

        public override void Abort()
        {
            throw new NotImplementedException();
        }
    }
}
