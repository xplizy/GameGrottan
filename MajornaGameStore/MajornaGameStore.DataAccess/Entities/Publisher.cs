namespace MajornaGameStore.DataAccess.Entities;

public class Publisher : EntityBase<int>
{
    public string Name { get; set; }

    public ICollection<Product> Products { get; set; }
}