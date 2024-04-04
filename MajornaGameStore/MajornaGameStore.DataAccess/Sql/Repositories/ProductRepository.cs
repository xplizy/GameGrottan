using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.DataAccess.Sql.Repositories;

public class ProductRepository(MajornaDbContext context) : RepositoryBase<Product, int>(context)
{
    public override async Task UpdateAsync(Product entity)
    {
        var product = await _context.Products.FindAsync(entity.Id);

        if (product is null)
            return;

        product.Name = entity.Name;
        product.Price = entity.Price;
        product.ProductTypeID = entity.ProductTypeID;
        product.DiscountID = entity.DiscountID;
        product.Description = entity.Description;
        product.Languages = entity.Languages;
        product.ImageLink = entity.ImageLink;
        product.PcRequirements = entity.PcRequirements;
        product.ReleaseDate = entity.ReleaseDate;
        product.Developers = entity.Developers;
        product.Publishers = entity.Publishers;
        product.Screenshots = entity.Screenshots;
        product.Tags = entity.Tags;
        product.Reviews = entity.Reviews;
        product.AgeRating = entity.AgeRating;

        await _context.SaveChangesAsync();
    }
}