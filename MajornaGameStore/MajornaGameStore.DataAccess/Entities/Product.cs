using System.Formats.Asn1;

namespace MajornaGameStore.DataAccess.Entities;

public class Product : EntityBase<int>
{
    public string Name { get; set; }
    public double  Price { get; set; }
    public int ProductTypeID { get; set; }
    public int DiscountID { get; set; }
    public string Description { get; set; }
    public string Languages { get; set; }
    public string ImageLink { get; set; }
    public string PcRequirements { get; set; }
    public string MacRequirements { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<Developer> Developers { get; set; }
    public ICollection<Publisher> Publishers { get; set; }
    public ICollection<Screenshot> Screenshots { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Review> Reviews { get; set; }
}