using Microsoft.EntityFrameworkCore;
using TalentQuest.Data.Entities;

namespace TalentQuest.Data
{
	public class TalentQuestDbContext : DbContext
	{
		public TalentQuestDbContext(DbContextOptions<TalentQuestDbContext> options)
			: base(options)
		{
		}

		protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
		{
			configurationBuilder.Properties<DateTime>().HaveColumnType("date");
		}

		public DbSet<Candidate> Candidates { get; set; }
		public DbSet<SelectionProcess> SelectionProcesses { get; set; }
		public DbSet<Recruiter> Recruiters { get; set; }
		public DbSet<Application> Applications { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<Role> Roles { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Candidate>()
				.Property(c => c.FirstName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Candidate>()
				.Property(c => c.LastName)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<Candidate>()
				.Property(c => c.BirthDate)
				.IsRequired();

			modelBuilder.Entity<Candidate>()
				.Property(c => c.LinkedinProfile)
				.HasMaxLength(100);

			modelBuilder.Entity<SelectionProcess>()
				.Property(sp => sp.Name)
				.IsRequired()
				.HasMaxLength(50);

			modelBuilder.Entity<SelectionProcess>()
				.Property(sp => sp.StartDate)
				.IsRequired();

			modelBuilder.Entity<SelectionProcess>()
				.Property(sp => sp.EndDate)
				.IsRequired();

			modelBuilder.Entity<SelectionProcess>()
				.Property(sp => sp.ProcessState)
				.IsRequired();

			modelBuilder.Entity<Application>()
				.Property(a => a.RegistrationDate)
				.IsRequired();

			modelBuilder.Entity<Application>()
				.Property(a => a.CandidateState)
				.IsRequired();

			base.OnModelCreating(modelBuilder);
		}
	}
}