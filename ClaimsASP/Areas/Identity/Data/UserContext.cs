using ClaimsASP.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClaimsASP.Data;

public class UserContext : IdentityDbContext<User>
{
    public DbSet<User> Users { get; set; }
    
    public UserContext(DbContextOptions<UserContext> options)
        : base(options)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }
}
