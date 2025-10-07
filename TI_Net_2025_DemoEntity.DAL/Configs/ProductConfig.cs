using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Configs
{
    public class ProductConfig : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable(p => p.HasCheckConstraint("CK_Product__Price", "Price >= 0"));
            builder.ToTable(p => p.HasCheckConstraint("CK_Product__AlcoholLevel", "AlcoholLevel >= 0"));

            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id).ValueGeneratedOnAdd();

            builder.HasIndex(p => p.Name).IsUnique();
            builder.Property(p => p.Name).IsRequired().HasMaxLength(50);

            builder.Property(p => p.Price).IsRequired().HasDefaultValue(0);
            builder.Property(p => p.AlcoholLevel).IsRequired().HasDefaultValue(0);

            builder.Property(p => p.Description).HasMaxLength(500);

            builder.HasMany(p => p.Lines)
                .WithOne(ol => ol.Product)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(p => p.Movements)
                .WithOne(m => m.Product)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasOne(p => p.Stock)
                .WithOne(s => s.Product)
                .HasForeignKey<Stock>(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
