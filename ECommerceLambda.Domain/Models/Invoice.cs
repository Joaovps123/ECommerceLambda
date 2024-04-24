namespace ECommerceLambda.Domain.Models
{
    public class Invoice
    {
        public string CustomerDocument { get; set; }
        public string InvoiceId { get; set; }
        public decimal CalculationBase { get; set; }
        public decimal TaxRate { get; set; }
        public string Description { get; set; }
        public decimal TaxAmount
        {
            get
            {
                return CalculationBase * TaxRate / 100;
            }
            private set
            {
                TaxAmount = value;
            }
        }
    }
}