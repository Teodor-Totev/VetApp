namespace VetApp.Data;

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using VetApp.Data.Models;

public class VetAppDbContext : IdentityDbContext<VetUser>
{
    public VetAppDbContext(DbContextOptions<VetAppDbContext> options)
        : base(options)
    {
        
    }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		builder.ApplyConfigurationsFromAssembly(Assembly.GetAssembly(typeof(VetAppDbContext)) ?? Assembly.GetExecutingAssembly());

		base.OnModelCreating(builder);
	}
}
