using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Models;

public class ProductModel
{
    public string Name { get; set; }
    public double Price { get; set; }
    public ProductType ProductType { get; set; } = new();
    public Discount Discount { get; set; } = new();
    public string Description { get; set; }
    public string Languages { get; set; }
    public string ImageLink { get; set; }
    public string PcRequirements { get; set; }
    public DateTime ReleaseDate { get; set; }
    public virtual ICollection<Developer> Developers { get; set; } = new List<Developer>();
    public ICollection<Publisher> Publishers { get; set; } = new List<Publisher>();
    public ICollection<Screenshot> Screenshots { get; set; } = new List<Screenshot>();
    public ICollection<Tag> Tags { get; set; } = new List<Tag>();
    public ICollection<Review> Reviews { get; set; } = new List<Review>();

    public int AgeRating { get; set; }
}