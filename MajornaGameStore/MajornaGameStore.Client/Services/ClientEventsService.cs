using System.Net.Http.Json;
using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientEventsService(HttpClient httpClient) : IClientEventsService
{
    private readonly HttpClient _httpClient = httpClient;

    public async Task<ICollection<EventDto>> GetAllAsync()
    {
        var response = await _httpClient.GetAsync($"/events");

        if (response.IsSuccessStatusCode == false)
        {
            return new List<EventDto>();
        }

        var result = await response.Content.ReadFromJsonAsync<List<EventDto>>();

        return result.ToList();
    }

    public Task<EventDto?> GetByIdAsync(int id)
    {
        throw new NotImplementedException();

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