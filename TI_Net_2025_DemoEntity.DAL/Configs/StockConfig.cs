using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Configs
{
    public class StockConfig : IEntityTypeConfiguration<Stock>
    {
        public void Configure(EntityTypeBuilder<Stock> builder)
        {
            builder.ToTable(s => s.HasCheckConstraint("CK_Stock__Limit", "LimitQuantity >= 0"));

            builder.HasKey(s => s.Id);
            builder.Property(s => s.Id).ValueGeneratedOnAdd();

            builder.Property(s => s.CurrentQuantity).IsRequired().HasDefaultValue(0);

            builder.Property(s => s.LimitQuantity).HasDefaultValue(0);

            builder.HasOne(s => s.Product)
                .WithOne(p => p.Stock)
                .HasForeignKey<Stock>(s => s.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
