namespace MajornaGameStore.DataAccess.Entities;

public class ProductType : EntityBase<int>
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }
}