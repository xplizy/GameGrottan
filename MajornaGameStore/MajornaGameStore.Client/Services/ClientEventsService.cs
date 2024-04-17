using MajornaGameStore.Shared.Dtos;
using MajornaGameStore.Shared.Interfaces.ServiceInterfaces.ClientSide;

namespace MajornaGameStore.Client.Services;

public class ClientEventsService(HttpClient httpClient) : IClientEventsService
{
    private readonly HttpClient _httpClient;

    public Task<ICollection<EventDto>> GetAllAsync()
    {
        throw new NotImplementedException();
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