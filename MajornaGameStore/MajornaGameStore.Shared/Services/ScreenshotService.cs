using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Services;

public class ScreenshotService(IScreenshotRepository repository) : ServiceBase<Screenshot, int>(repository)
{
    
}