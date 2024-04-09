using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Services;
using MajornaGameStore.Shared.Dtos;

namespace MajornaGameStore.Shared.Mappers;

public static class ProductMapper
{
    public static async Task<Product> MapToEntityAsync(ProductDto dto, 
        DeveloperService devService, 
        PublisherService pubService,
        ScreenshotService scrshotService,
        TagService tagService,
        Review reviewService)
    {
        //Developers
        var developers = new List<Developer>();
        foreach (var devId in dto.DeveloperIds)
        {
            var developer = await devService.GetByIdAsync(devId);
            developers.Add(developer!);
        }
        //Publishers
        var publishers = new List<Publisher>();
        foreach (var pubId in dto.PublisherIds)
        {
            var publisher = await pubService.GetByIdAsync(pubId);
            publishers.Add(publisher!);
        }
        //Screenshots
        var screenshots = new List<Screenshot>();
        foreach (var scrnshotId in dto.ScreenshotIds)
        {
            var screenshot = await scrshotService.GetByIdAsync(scrnshotId);
            screenshots.Add(screenshot!);
        }
        //Tags
        var tags = new List<Tag>();
        foreach (var tagId in dto.TagIds)
        {
            var tag = await tagService.GetByIdAsync(tagId);
            tags.Add(tag!);
        }
        //Reviews
        var reviews = new List<Review>();
        foreach (var reviewIds in dto.ReviewIds)
        {
            var review = await reviewService.
        }

        var entity = new Product
        {
            Name = dto.Name,
            Price = dto.Price,
            ProductTypeId = dto.ProductTypeId,
            DiscountId = dto.DiscountId,
            Description = dto.Description,
            Languages = dto.Languages,
            ImageLink = dto.ImageLink,
            PcRequirements = dto.PcRequirements,
            ReleaseDate = dto.ReleaseDate,
            AgeRating = dto.AgeRating,

        };
    }

    public static async Task<ProductDto> MapToDtoAsync(Product entity)
    {
        //Developers
        var developerIds = new List<int>();
        foreach (var entityDeveloper in entity.Developers)
        {
            developerIds.Add(entityDeveloper.Id);
        }
        //Publishers
        var publisherIds = new List<int>();
        foreach (var entityPublisher in entity.Publishers)
        {
            publisherIds.Add(entityPublisher.Id);
        }
        //Screenshots
        var screenshotIds = new List<int>();
        foreach (var entityScreenshot in entity.Screenshots)
        {
            screenshotIds.Add(entityScreenshot.Id);
        }
        //Tags
        var tagIds = new List<int>();
        foreach (var entityTag in entity.Tags)
        {
            tagIds.Add(entityTag.Id);
        }
        //Reviews
        var reviewIds = new List<int>();
        foreach (var entityReview in entity.Reviews)
        {
            reviewIds.Add(entityReview.Id);
        }
        var dto = new ProductDto
        {
            Name = entity.Name,
            Price = entity.Price,
            ProductTypeId = entity.ProductTypeId,
            DiscountId = entity.DiscountId,
            Description = entity.Description,
            Languages = entity.Languages,
            ImageLink = entity.ImageLink,
            PcRequirements = entity.PcRequirements,
            ReleaseDate = entity.ReleaseDate,
            AgeRating = entity.AgeRating,
            DeveloperIds = developerIds,
            PublisherIds = publisherIds,
            ScreenshotIds = screenshotIds,
            TagIds = tagIds,
            ReviewIds = reviewIds
        };

        return dto;
    }
}