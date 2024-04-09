using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class ScreenshotRepository(MajornaDbContext context) : RepositoryBase<Screenshot, int>(context)
{
    public override async Task<bool> UpdateAsync(Screenshot entity)
    {
        var screenshot = await _context.Screenshots.FindAsync(entity.Id);

        if (screenshot is null)
            return false;

        screenshot.Path = entity.Path;

        await _context.SaveChangesAsync();
        return true;
    }
}