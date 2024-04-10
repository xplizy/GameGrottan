using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using MajornaGameStore.DataAccess.Entities;
using MajornaGameStore.DataAccess.Sql;

namespace Server.Controllers;
[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly MajornaDbContext _context;

    public ProductsController(MajornaDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> Create(Product productToCreate)
    {
        productToCreate.Id = Convert.ToInt32(Guid.NewGuid().ToString());

        await _context.AddAsync(productToCreate);

        await _context.SaveChangesAsync();

        return Ok(productToCreate);
    }

    [HttpGet]
    public async Task<IEnumerable<Product>> Get()
    {
        return await _context.Products.ToListAsync();
    }

    [HttpPut]
    public async Task<IActionResult> Update(Product updatedProduct)
    {
        _context.Update(updatedProduct);

        await _context.SaveChangesAsync();

        return Ok(updatedProduct);
    }

    [HttpDelete]
    [Route("{productToDeleteId}")]
    public async Task<IActionResult> Update(string productToDeleteId)
    {
        var productToDelete = await _context.Products.FindAsync(productToDeleteId);

        _context.Remove(productToDelete);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}