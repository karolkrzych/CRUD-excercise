using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Zadanie_Rekrutacyjne.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Zadanie_Rekrutacyjne.Models;
using Microsoft.EntityFrameworkCore;

namespace Zadanie_Rekrutacyjne.Controllers
{
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        public ProductController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await _context.Products.ToListAsync();  
            return Ok(products);         
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product product)
        {           
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(Guid id, [FromBody] Product product)
        {
            var data = await _context.Products.FindAsync(id);
            data.Name = product.Name;
            _context.Products.Update(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await _context.Products.FindAsync(id);
            _context.Products.Remove(data);
            await _context.SaveChangesAsync();
            return Ok(data);
        }
    }
}

