using MajornaGameStore.DataAccess.Entities;


namespace MajornaGameStore.DataAccess.Services;

public class DeveloperService(DeveloperRepository repository) : ServiceBase<Developer, int>(repository)
{
    
}