using Amazon.DynamoDBv2.DataModel;

namespace ECommerceLambda.Models
{
    [DynamoDBTable("Customer")] // If not informed, it will consider the name of the class and attributes themselves
    public class Customer
    {
        [DynamoDBHashKey("Document")]
        public string Document { get; set; }

        [DynamoDBProperty]
        public string Name { get; set; }

        [DynamoDBProperty]
        public string Email { get; set; }

        [DynamoDBProperty]
        public Address Address { get; set; }
    }
}