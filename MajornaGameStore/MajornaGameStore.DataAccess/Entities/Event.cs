namespace MajornaGameStore.DataAccess.Entities;

public class Event : EntityBase<int>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int EventTypeId { get; set; }
    public DateTime EventStart { get; set; }
    public DateTime EventEnd { get; set; }

}