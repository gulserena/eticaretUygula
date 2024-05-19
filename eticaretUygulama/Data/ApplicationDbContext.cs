using eticaretUygulama.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eticaretUygulama.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser,AppRole,int>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
       public DbSet<Category>? Categories { get; set; }
       public DbSet<Products>? Products { get; set; }
       public DbSet<slider>? Slider { get; set; }
    }
}
