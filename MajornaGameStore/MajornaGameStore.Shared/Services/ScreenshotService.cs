using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces;

namespace MajornaGameStore.DataAccess.Services;

public class ScreenshotService(IScreenshotRepository repository) : ServiceBase<Screenshot, int>(repository)
{
    
}