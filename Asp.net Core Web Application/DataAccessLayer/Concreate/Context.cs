using EntityLayer.Concreate;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concreate
{
	public class Context : IdentityDbContext<AppUser, AppRole,int>
	{
		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer("server=DESKTOP-4GP61KD\\MSSQLSERVER2022;database=Asp150Lesson; integrated security=true;TrustServerCertificate=True");
		}
		// About,category gibi class ları kullanmak için EntityLayer katmanını DataAccessLayer katmanına referans gösterdik


		// Birden fazla ilişki için böyle bir yol kullanıyormusuz
		// Fluent api yöntemi diye geçiyor arat ve çalış
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Match>().HasOne(x => x.HomeTeam).WithMany(x => x.HomeMatches).HasForeignKey(x => x.HomeTeamId).OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Match>().HasOne(x => x.GuestTeam).WithMany(x => x.AwayMatches).HasForeignKey(x => x.GuestTeamId).OnDelete(DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Message2>()
				.HasOne(x => x.SenderUser)
				.WithMany(y => y.SenderMessages)
				.HasForeignKey(z => z.SenderID)
				.OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);

			modelBuilder.Entity<Message2>()
			   .HasOne(x => x.RecieverUser)
			   .WithMany(y => y.RecieverMessages)
			   .HasForeignKey(z => z.RecieverID)
			   .OnDelete(deleteBehavior: DeleteBehavior.ClientSetNull);
		
			base.OnModelCreating(modelBuilder);
		
		}


		public DbSet<About> Abouts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Writer> Writers { get; set; }
		public DbSet<Contact> Contacts { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Blog> Blogs { get; set; }
		public DbSet<NewsLetter> NewsLetters { get; set; }
		public DbSet<BlogRayting> BlogsRaytings { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<Message> Messages { get; set; }
		public DbSet<Team> Teams { get; set; }
		public DbSet<Match> Mathces { get; set; }
		public DbSet<Message2> Messages2 { get; set; }
		public DbSet<Admin> Admins { get; set; }

	}
}
