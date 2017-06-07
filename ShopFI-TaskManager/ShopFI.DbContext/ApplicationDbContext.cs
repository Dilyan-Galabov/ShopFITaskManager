using Microsoft.AspNet.Identity.EntityFramework;
using ShopFI.DbContext.Migrations;
using ShopFI.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopFI.DbContext
{
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
           // : base("ShopFILocalConnection", throwIfV1Schema: false)
            : base("ShopFIConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
