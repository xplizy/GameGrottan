using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Services;

public class PublisherService(IPublisherRepository repository) : ServiceBase<Publisher, int>(repository)
{
    
}