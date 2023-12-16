using EFCoreTutorial.Data.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreTutorialData.Context
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions options) : base(options)
		{
		}

		protected ApplicationDbContext()
		{
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
            if (!optionsBuilder.IsConfigured)
            {
				// Configs ...
				optionsBuilder.UseSqlServer(@"Server=(localdb)\\CoreDemo;Database=EFCoreTutorial;Trusted_Connection=true\");
            }

            base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder model)
		{
			model.HasDefaultSchema("dbo");

			model.Entity<Student>(entity =>
			{
				entity.ToTable("students");

				entity.Property(i => i.Id)
				.HasColumnName("id")
				.HasColumnType("int")
				.UseIdentityColumn()
				.IsRequired();


				entity.Property(i => i.FirstName).HasColumnName("first_name").HasColumnType("nvarchar").HasMaxLength(100);


			});

			base.OnModelCreating(model);
		}
	}
}
