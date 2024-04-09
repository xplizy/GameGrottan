using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql.Repositories;

namespace MajornaGameStore.DataAccess.Services;

public class PublisherService(PublisherRepository repository) : ServiceBase<Publisher, int>(repository)
{
    
}