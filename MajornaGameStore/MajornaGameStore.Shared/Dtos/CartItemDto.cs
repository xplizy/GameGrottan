using System.ComponentModel.DataAnnotations;

namespace MajornaGameStore.Shared.Dtos;

public class CartItemDto
{
    public int Id { get; set; }
    public string Name { get; set; }

    public double Price { get; set; }

    [Required, MinLength(1)] public int Quantity { get; set; } = 1;

    public string Image { get; set; } 
}