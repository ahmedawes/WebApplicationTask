using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGeneration.EntityFrameworkCore;
using WebApplicationTask.Models;

namespace WebApplicationTask.Data
{
	public class AppDbContext: IdentityDbContext<IdentityUser>
	{
		public AppDbContext (DbContextOptions<AppDbContext> options) : base(options) 
		{
		}
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
		public DbSet<Product> Products { get; set; }
	}
}
