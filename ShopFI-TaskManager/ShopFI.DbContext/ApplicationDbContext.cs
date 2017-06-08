using Microsoft.AspNet.Identity.EntityFramework;
using ShopFI.DbContext.Migrations;
using ShopFI.Entities.Common;
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
        public virtual IDbSet<Item> Items { get; set; }
        public virtual IDbSet<Category> Categories { get; set; }
        public virtual IDbSet<Comments> Comments { get; set; }

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
