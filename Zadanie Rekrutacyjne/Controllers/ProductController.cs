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
            if (_context.Products.Count() == 0)
            {
                return BadRequest("Database is empty.");
            }

            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            if (product == null)
            {
                return BadRequest("Product with this ID does not exist.");
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCreateInputModel model)
        {
            try
            {
                if (model == null)
                {
                    throw new Exception("Name and price is required.");
                }
                else
                {
                    if (!ModelState.IsValid)
                    {
                        throw new Exception("Name is required and has to be between 1 and 100 characters.");
                    }
                    else if (model.Price <= 0)
                    {
                        throw new Exception("Price value needs to be positive.");
                    }
                    else
                    {
                        _context._Products.Add(model);
                        await _context.SaveChangesAsync();
                        return Ok(model.Id);
                    }
                }
            }
            catch (Exception exception)
            {
                return StatusCode(500, "Error: " + exception.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] ProductUpdateInputModel model)
        {
            try
            {
                var data = await _context.Products.FindAsync(model.Id);
                if (data == null)
                {
                    throw new Exception("Product with this ID does not exist.");
                }
                else if (!ModelState.IsValid)
                {
                    throw new Exception("Name is required and has to be between 1 and 100 characters. Price is required and needs to be positive.");
                }
                else if (model.Price <= 0)
                {
                    throw new Exception("Price value needs to be positive.");
                }

                else
                {
                    data.Name = model.Name;
                    data.Price = model.Price;
                    _context.Products.Update(data);
                    await _context.SaveChangesAsync();
                    return Ok(data);
                }
            }
            catch (Exception exception)
            {

                return StatusCode(500, "Error: " + exception.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var data = await _context.Products.FindAsync(id);
            if (data == null)
            {
                return BadRequest("Product with this ID does not exist.");
            }
            _context.Products.Remove(data);
            await _context.SaveChangesAsync();
            return Ok(id);
        }
    }
}