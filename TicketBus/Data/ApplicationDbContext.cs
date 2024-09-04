using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System.Reflection.Metadata;
using TicketBus.Models;

namespace TicketBus.Data
{
	public class ApplicationDbContext : IdentityDbContext<AppUser>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{
		}
		
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Buses>()
				.HasMany(e => e.BusRoutes)
				.WithOne(e => e.Buses)
				.HasForeignKey(e => e.bus_id);

			modelBuilder.Entity<Routes>()
				.HasMany(e => e.BusRoute)
				.WithOne(e => e.Routes)
				.HasForeignKey(e => e.route_id);

			/*modelBuilder.Entity<Routes>()
				  .HasOne(e => e.Price)
				  .WithOne(e => e.Routes)
				  .HasForeignKey<Price>(e => e.route_id);*/

		/*	modelBuilder.Entity<AppUser>()
				.HasMany(u => u.ticketInfos) // Một người dùng có nhiều TicketInfo
				.WithOne(ti => ti.appUser)    // Mỗi TicketInfo thuộc về một người dùng
				.HasForeignKey(ti => ti.customerID); // Khóa ngoại trong TicketInfo tham chiếu đến khóa chính trong AppUser*/

			/*modelBuilder.Entity<TicketInfo>()
				.HasOne(ti => ti.appUser)     // Mỗi TicketInfo thuộc về một người dùng
				.WithMany(u => u.ticketInfos) // Một người dùng có nhiều TicketInfo
				.HasForeignKey(ti => ti.customerID); // Khóa ngoại trong TicketInfo tham chiếu đến khóa chính trong AppUser*/
			modelBuilder.Entity<BusRoute>()
				  .HasOne(e => e.Buses)
				  .WithMany(e => e.BusRoutes)
				  .HasForeignKey(e => e.bus_id);

			modelBuilder.Entity<BusRoute>()
				  .HasOne(e => e.Routes)
				  .WithMany(e => e.BusRoute)
				  .HasForeignKey(e => e.route_id);

			/*modelBuilder.Entity<Price>()
					*//*.HasOne(e => e.Routes)
				  .WithOne(e => e.Price)
				  .HasForeignKey<Price>(e => e.route_id)*//*
				  ;
*/
		}

		public DbSet<AppUser> AppUsers { get; set; }
		public DbSet<Buses> Buses { get; set; }
		public DbSet<BusRoute> BusRoutes { get; set; }
		public DbSet<Routes> Routes { get; set; }
		public DbSet<TicketInfo> TicketInfo { get; set; }

    }
}
