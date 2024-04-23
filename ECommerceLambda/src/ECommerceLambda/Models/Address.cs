using Amazon.DynamoDBv2.DataModel;

namespace ECommerceLambda.Models
{
    public class Address
    {
        [DynamoDBProperty]
        public string Street { get; set; }

        [DynamoDBProperty]
        public int Number { get; set; }

        [DynamoDBProperty]
        public string Complement { get; set; }

        [DynamoDBProperty]
        public string City { get; set; }

        [DynamoDBProperty]
        public string State { get; set; }
    }
}