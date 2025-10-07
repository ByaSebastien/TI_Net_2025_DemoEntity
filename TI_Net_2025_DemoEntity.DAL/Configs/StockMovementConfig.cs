using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TI_Net_2025_DemoEntity.DL.Entities;

namespace TI_Net_2025_DemoEntity.DAL.Configs
{
    public class StockMovementConfig : IEntityTypeConfiguration<StockMovement>
    {
        public void Configure(EntityTypeBuilder<StockMovement> builder)
        {
            builder.ToTable(sm => sm.HasCheckConstraint("CK_StockMovement__Quantity", "Quantity >= 0"));

            builder.HasKey(sm => sm.Id);
            builder.Property(sm => sm.Id).ValueGeneratedOnAdd();

            builder.Property(sm => sm.MovementType).HasConversion<string>().IsRequired();

            builder.HasOne(sm => sm.Product)
                .WithMany(p => p.Movements)
                .HasForeignKey(sm => sm.ProductId)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}
