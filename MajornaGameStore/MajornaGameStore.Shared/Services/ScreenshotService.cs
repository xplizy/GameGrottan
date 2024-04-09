using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Services;

public class ScreenshotService(ScreenshotRepository repository) : ServiceBase<Screenshot, int>(repository)
{
    
}