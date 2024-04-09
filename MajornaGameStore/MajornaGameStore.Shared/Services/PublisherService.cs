using MajornaGameStore.DataAccess.Entities;


namespace MajornaGameStore.DataAccess.Services;

public class PublisherService(PublisherRepository repository) : ServiceBase<Publisher, int>(repository)
{
    
}