namespace MajornaGameStore.DataAccess.Entities;

public class Developer : EntityBase<int>
{
    public string Name { get; set; }
    public virtual ICollection<Product> Products { get; set; }

}