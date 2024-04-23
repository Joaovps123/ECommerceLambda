namespace ECommerceLambda.Domain.Models
{
    public class Customer
    {
        public string? Document { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public Address? Address { get; set; }
    }
}