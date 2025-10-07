using TI_Net_2025_DemoEntity.DL.Enums;

namespace TI_Net_2025_DemoEntity.DL.Entities
{
    public class StockMovement
    {
        public int Id { get; set; }
        public MovementType MovementType { get; set; }
        public int Quantity { get; set; }
        public int? ProductId { get; set; }

        public Product? Product { get; set; }
    }
}
