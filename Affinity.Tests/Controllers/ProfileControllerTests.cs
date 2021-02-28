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

namespace Affinity.Tests.Controllers
{
    class ProfileControllerTests : DBContextController<ProfileController>
    {
        public override ProfileController CreateControllerSUT()
        {
            return new ProfileController(_context, _mockUserManager.Object);
        }


    }
}
