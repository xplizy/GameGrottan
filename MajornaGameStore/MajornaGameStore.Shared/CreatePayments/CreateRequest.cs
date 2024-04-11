using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Shared.CreatePayments;


public record CheckoutProductRequest
{
    public double Price { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }
}

//SKAPA EN betalningssession med produkter i varukorgen
public class CreatePaymentRequest
{
    public List<ICartItem> Products { get; set; } = new();

    public int Quantity { get; set; }

    public string SuccessRedirectUrl { get; set; }

    public string CancelRedirectUrl { get; set; }
}
