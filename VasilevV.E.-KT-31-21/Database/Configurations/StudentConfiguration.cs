using VasilevV.E._KT_31_21.Database.Helpers;
using VasilevV.E._KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VasilevV.E._KT_31_21.Database.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        private const string TableName = "cd_student";

        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.ToTable(TableName);

            builder
               .HasKey(p => p.StudentId)
               .HasName($"pk_{TableName}_student_id");

            builder.Property(p => p.StudentId).ValueGeneratedOnAdd();
            builder.Property(p => p.StudentId)
                .HasColumnName("student_id");

            builder.Property(p => p.FirstName).IsRequired()
                .HasColumnName("c_student_firstname")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.Property(p => p.LastName).IsRequired()
                .HasColumnName("c_student_lastname")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.Property(p => p.MiddleName).IsRequired()
                .HasColumnName("c_student_middlename")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(100);

            builder.Property(p => p.GroupId).IsRequired()
                .HasColumnName("c_student_group_id");

            builder.HasOne(p=>p.Group)
                .WithMany()
                .HasForeignKey(p=>p.GroupId)
                .HasConstraintName("fk_f_group_id")
                .OnDelete(DeleteBehavior.Cascade);

            builder.Navigation(p => p.Group)
                .AutoInclude();
        }
    }
}
