using Amazon.DynamoDBv2.DataModel;
using ECommerceLambda.Domain.Converters;

namespace ECommerceLambda.Domain.Models
{
    public class Order
    {
        [DynamoDBHashKey(typeof(DynamoDBEnumStringConverter<StatusOrderEnum>))]
        public StatusOrderEnum Status { get; set; }
        public string CustomerDocument 
        { 
            get 
            {
                return Customer.Document;
            }
            private set
            {
                CustomerDocument = value;
            } 
        }
        public Guid OrderId { get; set; }
        public Customer Customer { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice
        {
            get
            {
                return OrderItems.Sum(x => x.UnitPrice * x.Quantity);
            }
            private set
            {
                TotalPrice = value;
            }
        }
    }
}