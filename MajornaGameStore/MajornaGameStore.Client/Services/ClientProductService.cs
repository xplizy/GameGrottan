using System.Net.Http.Json;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientProductService(HttpClient httpClient) : IClientProductService
{
    private readonly HttpClient _httpClient = httpClient;
    public async Task<ICollection<ProductDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync($"/products");

        if (response.IsSuccessStatusCode == false)
            return new List<ProductDto>();

        var result = await response.Content.ReadFromJsonAsync<List<ProductDto>>();

        return result.ToList();

    }

    public async Task<ProductDto?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/products/{id}");

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<ProductDto>();

        return result;
    }

    public async Task<ProductDto> AddAsync(ProductDto entity)
    {
        var response = await _httpClient.PostAsJsonAsync($"/products", entity);

        if (response.IsSuccessStatusCode == false) 
            return null;

        var result = await response.Content.ReadFromJsonAsync<ProductDto>();
        return result;
    }

    public async Task<bool> UpdateAsync(ProductDto entity)
    {
        var response = await _httpClient.PostAsJsonAsync($"/products", entity);

        if (response.IsSuccessStatusCode == false)
            return false;

        var result = await response.Content.ReadFromJsonAsync<ProductDto>();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var response = await _httpClient.DeleteAsync($"/products/{id}");

        if ( response.IsSuccessStatusCode == false) 
            return false;

        var result = await response.Content.ReadFromJsonAsync<ProductDto>();

        return true;
    }
}