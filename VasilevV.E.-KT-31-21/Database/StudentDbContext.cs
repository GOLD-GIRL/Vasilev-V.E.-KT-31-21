using VasilevV.E._KT_31_21.Database.Configurations;
using VasilevV.E._KT_31_21.Models;
using Microsoft.EntityFrameworkCore;

namespace VasilevV.E._KT_31_21.Database
{
    public class StudentDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        DbSet<Group> Groups { get; set; }
        DbSet<Discipline> Disciplines { get; set; }
        DbSet<GroupDiscipline> GroupDisciplines { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new StudentConfiguration());
            modelBuilder.ApplyConfiguration(new GroupConfiguration());
            modelBuilder.ApplyConfiguration(new DisciplineConfiguration());
            modelBuilder.ApplyConfiguration(new GroupDisciplineConfiguration());
        }
        public StudentDbContext(DbContextOptions<StudentDbContext> options) : base(options) {
            

        }

    }
}
