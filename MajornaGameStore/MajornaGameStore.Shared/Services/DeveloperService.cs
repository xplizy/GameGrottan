using MajornaGameStore.DataAccess.Entities;


namespace MajornaGameStore.DataAccess.Services;

public class DeveloperService(IDeveloperRepository repository) : ServiceBase<Developer, int>(repository)
{
    
}