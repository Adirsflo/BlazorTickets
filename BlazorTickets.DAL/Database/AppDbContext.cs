using Microsoft.EntityFrameworkCore;
using Shared.ViewModels;

namespace BlazorTickets.DAL.Database
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<DbContext> options) : base(options)
		{

		}

		public DbSet<TicketModel> Tickets { get; set; }
		public DbSet<ResponseModel> Responses { get; set; }
		public DbSet<TagModel> Tags { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<TicketTagModel>()
			.HasKey(tt => new { tt.TicketId, tt.TagId });

			modelBuilder.Entity<TicketTagModel>()
			.HasOne(tt => tt.Ticket)
			.WithMany(t => t.TicketTags)
			.HasForeignKey(tt => tt.TicketId);

			modelBuilder.Entity<TicketTagModel>()
			.HasOne(tt => tt.Tag)
			.WithMany(t => t.TicketTags)
			.HasForeignKey(tt => tt.TagId);

			modelBuilder.Entity<ResponseModel>()
			.HasOne(r => r.Ticket)
			.WithMany(t => t.Responses)
			.HasForeignKey(r => r.TicketId);
		}
	}
}
