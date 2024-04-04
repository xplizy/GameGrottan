namespace MajornaGameStore.DataAccess.Entities;

public class Tag : EntityBase<int>
{
    public string Name { get; set; }
    public ICollection<Product> Products { get; set; }

}