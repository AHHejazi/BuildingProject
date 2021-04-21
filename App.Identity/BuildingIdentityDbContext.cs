using App.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace App.Identity.Identity
{
    public class BuildingIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public BuildingIdentityDbContext(DbContextOptions<BuildingIdentityDbContext> options) : base(options)
        {
        }

    }
}


