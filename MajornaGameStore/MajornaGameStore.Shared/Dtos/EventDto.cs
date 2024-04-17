using MajornaGameStore.DataAccess.Entities;

namespace MajornaGameStore.Shared.Dtos;

public class EventDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public int EventTypeId { get; set; }
    public DateTime EventStart { get; set; }
    public DateTime EventEnd { get; set; }
    public ICollection<string> UserIds { get; set; }
}