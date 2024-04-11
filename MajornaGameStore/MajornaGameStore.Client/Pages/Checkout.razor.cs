using System.Net.Http.Json;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Mongo;
using MajornaGameStore.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace MajornaGameStore.Client.Pages
{
    public partial class Checkout
    {
        [Inject]
        public HttpClient HttpClient { get; set; } = default!;

        [Inject]
        public IJSRuntime JsRuntime { get; set; } = default!;

        private List<Product>? _products;
        private IEnumerable<Product[]>? _productChunksOf4;

        //private readonly IMongoDatabase _database;

        //TODO: ändra till sin egna
        private const string DevApiBaseAddress = "https://localhost:7190";

        //public Checkout(IMongoDatabase database)
        //{
        //    _database = database;
        //}

        //protected override async Task OnInitializedAsync()
        //{
        //    _products = await HttpClient.GetFromJsonAsync<List<Product>>($"{DevApiBaseAddress}/products");

        //    if (_products is not null)
        //    {
        //        _productChunksOf4 = _products.Chunk(4);
        //    }
        //}

        private async Task OnClickBtnBuyNowAsync(Product product)
        {

            var response = await HttpClient.PostAsJsonAsync($"{DevApiBaseAddress}/checkout", product);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();

            var checkoutOrderResponse = JsonConvert.DeserializeObject<CheckoutOrderResponse>(responseBody);

            // Opens up Stripe.
            await JsRuntime.InvokeVoidAsync("checkout", checkoutOrderResponse.PubKey, checkoutOrderResponse.SessionId);

            /*try
               {
                   // Retrieve product information from SQL database
                   Product product;
                   using (var dbContext = new YourSqlDbContext())
                   {
                       product = await dbContext.Products.FirstOrDefaultAsync(p => p.Id == productId);
                   }

                   if (product == null)
                   {
                       Console.WriteLine("Product not found in SQL database.");
                       return;
                   }

                   // Retrieve order information from MongoDB
                   var collection = _mongoDatabase.GetCollection<Order>("orders");
                   var filter = Builders<Order>.Filter.Eq("ProductId", productId);
                   var order = await collection.Find(filter).FirstOrDefaultAsync();

                   if (order == null)
                   {
                       Console.WriteLine("No orders found in MongoDB for the product.");
                       return;
                   }

                   // Now you have both product and order information
                   // Perform further actions as needed
               }
               catch (Exception ex)
               {
                   Console.WriteLine($"An error occurred: {ex.Message}");
               }*/

        }
    }
}
