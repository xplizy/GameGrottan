using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql.Repositories;

namespace MajornaGameStore.DataAccess.Services;

public class ScreenshotService(IScreenshotRepository repository) : ServiceBase<Screenshot, int>(repository)
{
    
}