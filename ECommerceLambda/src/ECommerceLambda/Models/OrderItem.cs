namespace ECommerceLambda.Models
{
    public class OrderItem
    {
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public int ProductId { get; set; }
    }
}