namespace MajornaGameStore.Shared.CreatePayments;

public record CreateRequest
{
    public record CheckoutProductRequest
    {
        public double Price { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }

    //SKAPA EN betalningssession med produkter i varukorgen
    public record CreatePaymentRequest
    {
        public List<CheckoutProductRequest> Products { get; set; } = new();

        public int Quantity { get; set; }

        public string SuccessRedirectUrl { get; set; }

        public string CancelRedirectUrl { get; set; }
    }

}