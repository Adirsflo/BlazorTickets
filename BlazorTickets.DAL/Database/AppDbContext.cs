using Microsoft.EntityFrameworkCore;
using Shared.ViewModels;

namespace BlazorTickets.DAL.Database
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{

		}



		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<TicketTag>()
			.HasKey(tt => new { tt.TicketId, tt.TagId });

			modelBuilder.Entity<TicketTag>()
			.HasOne(tt => tt.Ticket)
			.WithMany(t => t.TicketTags)
			.HasForeignKey(tt => tt.TicketId);

			modelBuilder.Entity<TicketTag>()
			.HasOne(tt => tt.Tag)
			.WithMany(t => t.TicketTags)
			.HasForeignKey(tt => tt.TagId);

			modelBuilder.Entity<ResponseModel>()
			.HasOne(r => r.Ticket)
			.WithMany(t => t.Responses)
			.HasForeignKey(r => r.TicketId);
		}
		public DbSet<TicketModel> Tickets { get; set; }
		public DbSet<ResponseModel> Responses { get; set; }
		public DbSet<TagModel> Tags { get; set; }
		public DbSet<TicketTag> TicketTags { get; set; }
	}
}
