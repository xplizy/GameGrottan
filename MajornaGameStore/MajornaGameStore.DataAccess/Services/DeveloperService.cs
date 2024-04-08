using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql.Repositories;

namespace MajornaGameStore.DataAccess.Services;

public class DeveloperService(DeveloperRepository repository) : ServiceBase<Developer, int>(repository)
{
    
}