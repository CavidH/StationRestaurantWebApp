using Core.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Data.DAL
{
    public class AppDbContext:IdentityDbContext<ApplicationUser>
    {
        //add-migration AppUser -o DAL/Migrations
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options)
        {
            
        }
        
    }
}