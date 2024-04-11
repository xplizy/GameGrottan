using MajornaGameStore.Shared.CreatePayments;
using Microsoft.AspNetCore.Routing;
using Stripe;
using Stripe.Checkout;
using Product = Stripe.Product;

namespace MajornaGameStore.Api.Stripe;

public static class StripeExtension
{
    public static void AddPaymentsApi(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddOptions<StripeConfig>().BindConfiguration(nameof(StripeConfig));

        services.AddScoped<StripeClient>();
    }

    public static IEndpointRouteBuilder MapPaymentsEndPoints(this IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/payments");

        group.MapPost("/", CreateOnePayment);

        return app;
    }

    private static async Task<IResult> CreateOnePayment(CreateRequest.CreatePaymentRequest request, StripeClient client)
    {
        var checkoutUrl = await client.Checkout(request);
        //var checkoutUrl = await client.Checkout(request);

        var ok = new CreateRequest.CreatePaymentRequest()
        {
            CheckoutUrl = checkoutUrl
        };

        return Results.Ok(ok);


    }
}