using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using ProductsAPI.Data;

namespace ProductsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        //Get all products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int pageNum = 1, int pageSize = 12)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }

            var products = await _context.Products
            .OrderBy(p => p.ProductId)
            .Skip((pageNum - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();
            return Ok(products);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetProductsCount()
        {
            int count = await _context.Products.CountAsync(p => p.InStock == true);
            return Ok(count);
        }



        //Get product by id
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return product;
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct(int id, Product product)
        {
            if (id != product.ProductId)
            {
                return BadRequest();
            }

            _context.Entry(product).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProductExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            if (_context.Products == null)
            {
                return Problem("Entity set 'ProductContext.Products'  is null.");
            }


            _context.Products.Add(product);



            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProduct", new { id = product.ProductId }, product);
        }


        [HttpPatch("{id}/InStock")]
        public async Task<IActionResult> UpdateProductStock(int id, [FromBody] bool inStock)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)

            {
                return NotFound();
            }

            product.InStock = inStock;
            await _context.SaveChangesAsync();

            return Ok();

        }

        [HttpPatch("{id}/Title")]
        public async Task<IActionResult> UpdateProductTitle(int id, [FromBody] string title)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)

            {
                return NotFound();
            }

            product.Title = title;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}/Price")]
        public async Task<IActionResult> UpdateProductPrice(int id, [FromBody] decimal price)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)

            {
                return NotFound();
            }
            product.Price = price;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}/Description")]
        public async Task<IActionResult> UpdateProductDescription(int id, [FromBody] string description)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)

            {
                return NotFound();
            }
            product.Description = description;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}/Category")]
        public async Task<IActionResult> UpdateProductCategory(int id, [FromBody] string category)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)

            {
                return NotFound();
            }
            product.Category = category;
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPatch("{id}/ImgUrl")]
        public async Task<IActionResult> UpdateProductImgUrl(int id, [FromBody] string imgUrl)
        {
            var product = await _context.Products.FindAsync(id);
            if (product == null)

            {
                return NotFound();
            }
            product.ImgUrl = imgUrl;
            await _context.SaveChangesAsync();

            return Ok();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
