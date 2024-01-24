using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace Covid19Management.Models.Context
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Citizen> Citizens { get; set; }
        public virtual DbSet<Vaccination> Vaccinations { get; set; }
        public virtual DbSet<Vacxin> Vacxins { get; set; }
        public virtual DbSet<VacxinType> VacxinTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=DESKTOP-DKTP37G\\CSDL;Database=Covid19ManagementDB;User Id=sa;Password=123456;TrustServerCertificate=True;");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Vaccination>()
                        .HasOne(v => v.Citizen)
                        .WithMany(c => c.Vaccinations)
                        .HasForeignKey(v => v.CitizenCode);
            modelBuilder.Entity<Vaccination>()
                        .HasOne(v => v.Vacxin)
                        .WithMany(vx => vx.Vaccinations)
                        .HasForeignKey(v => v.VacxinCode);

            modelBuilder.Entity<Vacxin>()
                        .HasOne(v => v.VacxinType)
                        .WithMany(vt => vt.Vacxins)
                        .HasForeignKey(v => v.VacxinTypeCode).OnDelete(DeleteBehavior.Cascade);          
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder builder)
        {
            builder.Properties<DateOnly>()
                    .HaveConversion<DateOnlyConverter>()
                       .HaveColumnType("date");
        }
    }
}
