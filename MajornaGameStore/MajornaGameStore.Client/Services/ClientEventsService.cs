using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;
using System.Net.Http.Json;

namespace MajornaGameStore.Client.Services;

public class ClientEventsService(HttpClient httpClient) : IClientEventsService
{
    private readonly HttpClient _httpClient = httpClient;

    public Task<ICollection<EventDto>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public async Task<EventDto?> GetByIdAsync(int id)
    {
        var response = await _httpClient.GetAsync($"/events/{id}");

        if (response.IsSuccessStatusCode == false)
            return null;

        var result = await response.Content.ReadFromJsonAsync<EventDto>();

        return result;
    }

    public Task<EventDto> AddAsync(EventDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> UpdateAsync(EventDto entity)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }
}