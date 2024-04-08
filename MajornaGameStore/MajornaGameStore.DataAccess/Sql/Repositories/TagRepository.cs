using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class TagRepository(MajornaDbContext context) : RepositoryBase<Tag, int>(context), ITagRepository
{
    public override async Task UpdateAsync(Tag entity)
    {
        var tag = await _context.Tags.FindAsync(entity.Id);

        if (tag is null)
            return;

        tag.Name = entity.Name;
        tag.Products = entity.Products;

        await _context.SaveChangesAsync();
    }

    public async Task<Tag?> GetByNameAsync(string name)
    {
        var tag = await _context.Tags.FirstOrDefaultAsync(t => t.Name == name);
        if (tag is null)
            return null;

        return tag;
    }
}
