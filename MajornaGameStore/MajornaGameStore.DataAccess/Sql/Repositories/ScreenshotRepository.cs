using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class ScreenshotRepository(MajornaDbContext context) : RepositoryBase<Screenshot, int>(context)
{
    public override async Task UpdateAsync(Screenshot entity)
    {
        var screenshot = await _context.Screenshots.FindAsync(entity.Id);

        if (screenshot is null)
            return;

        screenshot.Path = entity.Path;

        await _context.SaveChangesAsync();
    }
}