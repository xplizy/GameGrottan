using MajornaGameStore.DataAccess.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MajornaGameStore.DataAccess.Sql;

public class MajornaDbContext(DbContextOptions<MajornaDbContext> options) : IdentityDbContext<User>(options)
{
    public DbSet<Discount> Discounts { get; set; } = null!;
    public DbSet<Event> Events { get; set; } = null!;
    public DbSet<EventType> EventTypes { get; set; } = null!;
    public DbSet<Product> Products { get; set; } = null!;
    public DbSet<ProductType> ProductTypes { get; set; } = null!;
    public DbSet<Tag> Tags { get; set; } = null!;
}