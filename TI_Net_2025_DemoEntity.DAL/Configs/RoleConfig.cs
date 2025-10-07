using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Configs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable("Role_").HasKey(r => r.Id);

            builder.Property(r => r.Id).ValueGeneratedOnAdd();

            builder.HasIndex(r => r.Name).IsUnique();
            builder.Property(r => r.Name).IsRequired().HasMaxLength(50);

            builder.HasMany(r => r.Users)
                .WithMany(u => u.Roles);
        }
    }
}
