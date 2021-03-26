using App.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Identity.Identity
{
    public class BuildingIdentityDbContext : IdentityDbContext<IdentityUser>
    {
        public BuildingIdentityDbContext(DbContextOptions<BuildingIdentityDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
        }
    }
}


