using System;
using Affinity.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(Affinity.Areas.Identity.IdentityHostingStartup))]
namespace Affinity.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            //builder.ConfigureServices((context, services) => {
            //    services.AddDbContext<AffinityContext>(options =>
            //        options.UseSqlServer(
            //            context.Configuration.GetConnectionString("AffinityContextConnection")));

            //    services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
            //        .AddEntityFrameworkStores<AffinityContext>();
            //});
        }
    }
}