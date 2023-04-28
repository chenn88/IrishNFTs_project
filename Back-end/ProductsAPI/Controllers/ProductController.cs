using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProductsAPI.Models;
using ProductsAPI.Data;

namespace ProductsAPI.Controllers
{
    //declaring the controller and DB Context
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductDbContext _context;

        public ProductController(ProductDbContext context)
        {
            _context = context;
        }

        //Get method to get all products (optional boolean included for inStockcheck)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetProducts(int pageNum = 1, int pageSize = 12, bool? inStockOnly = null)
        {
            if (_context.Products == null)
            {
                return NotFound();
            }

            var products = _context.Products.AsQueryable();

            //checking for product being in stock

            if (inStockOnly.HasValue && inStockOnly.Value)
            {
                products = products.Where(p => p.InStock);
            }

            // creating pagination
            var paginatedProducts = await products
                .OrderBy(p => p.ProductId)
                .Skip((pageNum - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return Ok(paginatedProducts);
        }

        //Getting product count to apply pagination
        [HttpGet("count")]
        public async Task<ActionResult<int>> GetProductsCount()
        {
            int count = await _context.Products.CountAsync(p => p.InStock == true);
            return Ok(count);
        }
        //Getting count of in stock products only to apply pagination
        [HttpGet("in-stock-count")]
        public async Task<ActionResult<int>> GetInStockProductsCount()
        {
            int count = await _context.Products.CountAsync(p => p.InStock);
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

        // Put product (this is not implemented at the front end I opted for individual patch methods so I could edit different fields individual - this was great for typos etc..)

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

        //Post method for adding a product

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

        //Patch method to update the product inStock value
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
        //Patch method to edit product title
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

        //Patch method to edit product price
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
        //Patch method to edit product description

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

        //Patch method to update product category

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

        //Patch method to update product image url
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

        // Method to delete product
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

        //Boolean method to check if a product exists
        private bool ProductExists(int id)
        {
            return (_context.Products?.Any(e => e.ProductId == id)).GetValueOrDefault();
        }
    }
}
