namespace VetApp.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using VetApp.Data.Models;

public class VetAppDbContext : IdentityDbContext<VetUser>
{
    public VetAppDbContext(DbContextOptions<VetAppDbContext> options)
        : base(options)
    {
        
    }
}
