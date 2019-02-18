using Microsoft.AspNet.Identity.EntityFramework;
using RiccoTest2.Models;
using System.Data.Entity;

namespace RiccoTest2.Context
{
    public class ApplicationDataContext : IdentityDbContext<AppUser>
    {
        public ApplicationDataContext()
            : base("DefaultConnection")
        { }

        public System.Data.Entity.DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<MailModel> EmailModels { get; set; }
    }
}