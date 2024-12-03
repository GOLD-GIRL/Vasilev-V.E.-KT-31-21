using VasilevV.E._KT_31_21.Database.Helpers;
using VasilevV.E._KT_31_21.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace VasilevV.E._KT_31_21.Database.Configurations
{
    public class GroupConfiguration : IEntityTypeConfiguration<Group>
    {
        private const string TableName = "cd_group";

        public void Configure(EntityTypeBuilder<Group> builder)
        {
            builder.ToTable(TableName);
            builder
               .HasKey(g => g.GroupId)
               .HasName($"pk_{TableName}_group_id");

            builder.Property(g => g.GroupId).ValueGeneratedOnAdd();
            builder.Property(g => g.GroupId)
                .HasColumnName("group_id");

            builder.Property(g => g.GroupName).IsRequired()
                .HasColumnName("c_group_groupname")
                .HasColumnType(ColumnType.String)
                .HasMaxLength(15);

            builder.Property(g => g.GroupCourse).IsRequired()
                .HasColumnName("с_group_groupcourse")
                .HasColumnType(ColumnType.Int);

        }
    }
}
