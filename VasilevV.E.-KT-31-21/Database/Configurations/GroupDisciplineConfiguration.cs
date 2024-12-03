using VasilevV.E._KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace VasilevV.E._KT_31_21.Database.Configurations;
    public class GroupDisciplineConfiguration : IEntityTypeConfiguration<GroupDiscipline>
{
    private const string TableName = "cd_group_discipline";
    public void Configure(EntityTypeBuilder<GroupDiscipline> builder)
    {
        builder.ToTable(TableName);
        builder.HasKey(gd => new { gd.GroupId, gd.DisciplineId })
                  .HasName($"pk_{TableName}_group_discipline_id");

        builder.Property(gd => gd.GroupId)
                  .HasColumnName("group_id");

        builder.Property(gd => gd.DisciplineId)
               .HasColumnName("discipline_id");

        builder.HasOne(gd => gd.Group)
                  .WithMany()
                  .HasForeignKey(gd => gd.GroupId);

        builder.HasOne(gd => gd.Discipline)
                  .WithMany() 
                  .HasForeignKey(gd => gd.DisciplineId);
    }
}   
