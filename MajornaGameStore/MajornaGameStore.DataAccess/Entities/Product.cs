using System.Formats.Asn1;

namespace MajornaGameStore.DataAccess.Entities;

public class Product : EntityBase<int>
{
    public string Name { get; set; }
    public double  Price { get; set; }
    public int ProductTypeID { get; set; }
    public int DiscountID { get; set; }
    public ICollection<Tag> Tags { get; set; }
    public ICollection<Review> Reviews { get; set; }
}