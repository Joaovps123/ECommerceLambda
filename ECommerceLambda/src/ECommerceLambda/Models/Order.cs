namespace ECommerceLambda.Models
{
    public class Order
    {
        public StatusOrderEnum Status { get; set; }
        public string CustomerDocument => Customer.Document;
        public Guid OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice => OrderItems.Sum(x => x.UnitPrice * x.Quantity);
    }
}