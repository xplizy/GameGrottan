namespace MajornaGameStore.Shared.Dtos;

public class ProductWithInfoDto
{
    
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int ProductTypeId { get; set; }
        public int DiscountId { get; set; } = 1;
        public string Description { get; set; }
        public string Languages { get; set; }
        public string ImageLink { get; set; }
        public string PcRequirements { get; set; }
        public DateTime ReleaseDate { get; set; }
        public ICollection<string> DeveloperNames { get; set; }
        public ICollection<string> PublisherNames { get; set; }
        public ICollection<string> ScreenshotLinks { get; set; }
        public ICollection<string> TagNames { get; set; }
        public ICollection<int> ReviewIds { get; set; }

        public int AgeRating { get; set; }
    
}