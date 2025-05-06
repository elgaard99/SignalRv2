using Microsoft.EntityFrameworkCore;
using ChatModels;
using Microsoft.Extensions.Options;

namespace SignalRv2.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
		{ 
		}
		public DbSet<Chat> Chats { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{

		}
	}
}
