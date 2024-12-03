using VasilevV.E._KT_31_21.Database.Helpers;
using VasilevV.E._KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VasilevV.E._KT_31_21.Database.Configurations
{
    public class DisciplineConfiguration : IEntityTypeConfiguration<Discipline>
    {
        private const string TableName = "cd_discipline";

        public void Configure(EntityTypeBuilder<Discipline> builder)
        {
            builder.ToTable(TableName);
            builder
               .HasKey(d => d.DisciplineId)
               .HasName($"pk_{TableName}_discipline_id");

            builder.Property(d => d.DisciplineId).ValueGeneratedOnAdd();
            builder.Property(d => d.DisciplineId)
                .HasColumnName("discipline_id");

            builder.Property(d => d.DisciplineName).IsRequired()
                .HasColumnName("c_discipline_name")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(30);

            builder.Property(d => d.IsDeleted).IsRequired()
                .HasColumnName("с_discipline_isdeleted")
                .HasColumnType(ColumnType.Bool);

            builder.Property(d => d.Direction).IsRequired()
                .HasColumnName("c_discipline_direction")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(30);

            builder.HasIndex(d => d.Direction)
                .HasDatabaseName($"idx_{TableName}_direction");

            builder.HasIndex(d => d.IsDeleted)
                .HasDatabaseName($"idx_{TableName}_isdeleted");

        }
    }
}
