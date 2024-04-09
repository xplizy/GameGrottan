namespace MajornaGameStore.Shared;

public class CheckoutOrderResponse
{
    //each payment process in STRIPE called Session and has ID + annan info -> får gratis
    public string? SessionId { get; set; }

    public string? PubKey { get; set; }
}