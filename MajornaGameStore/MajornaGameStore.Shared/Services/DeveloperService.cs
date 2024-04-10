using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces;


namespace MajornaGameStore.DataAccess.Services;

public class DeveloperService(IDeveloperRepository repository) : ServiceBase<Developer, int>(repository)
{
    
}