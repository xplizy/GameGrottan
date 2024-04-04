using MajornaGameStore.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class TypeRepository(MajornaDbContext context) : RepositoryBase<ProductType, int>(context)
{
    public override async Task UpdateAsync(ProductType entity)
    {
        var type = await _context.ProductTypes.FindAsync(entity.Id);

        if (type is null)
            return;

        type.Name = entity.Name;
        type.Products = entity.Products;

        await _context.SaveChangesAsync();
    }

    public async Task<ProductType?> GetByNameAsync(string name)
    {
        var type = await _context.ProductTypes.FirstOrDefaultAsync(t => t.Name == name);
        if (type is null) 
            return null;

        return type;
    }
}