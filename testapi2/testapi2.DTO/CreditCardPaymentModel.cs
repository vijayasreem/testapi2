namespace testapi2
{
    public class CreditCardPaymentModel
    {
        public int Id { get; set; }
        
        public string CreditCardNumber { get; set; }
        
        public string ExpiryDate { get; set; }
        
        public string Cvv { get; set; }
        
        public decimal Amount { get; set; }
        
        public string PurchaseNotification { get; set; }
    }
}