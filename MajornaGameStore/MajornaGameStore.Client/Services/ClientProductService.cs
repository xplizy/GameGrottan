using System.Net.Http.Json;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces;

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

    public Task<ProductDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> AddAsync(ProductDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(ProductDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}