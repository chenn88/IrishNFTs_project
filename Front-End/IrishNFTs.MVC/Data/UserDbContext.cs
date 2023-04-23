using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace IrishNFTs.MVC.Data
{
    public class UserDbContext : IdentityDbContext<IdentityUser>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}