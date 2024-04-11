using System.Net.Http.Json;
using MajornaGameStore.Shared.CreatePayments;
using Microsoft.AspNetCore.Components.Routing;

namespace MajornaGameStore.Client.Pages;

public class PaymentHttpClient
{
    private readonly HttpClient _httpClient;

    public PaymentHttpClient(HttpClient htpClient)
    {
        _httpClient = htpClient;
    }

    public async Task<string> CreatePayment(CreateRequest.CreatePaymentRequest request)
    {
        var response = await _httpClient.PostAsJsonAsync($"/payments", request);
        
        if (!response.IsSuccessStatusCode)
        {
            return null;
        }

        var checkoutResponse = await response.Content.ReadFromJsonAsync<CreateResponse>();
        return checkoutResponse?.CheckoutUrl;
    }
}