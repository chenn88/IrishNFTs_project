using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrdersAPI.Models;

namespace OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly OrderDbContext _context;

        public PaymentsController(OrderDbContext context)
        {
            _context = context;
        }

        // GET: api/Payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPayments()
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            return await _context.Payments.ToListAsync();
        }

        // GET: api/Payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPayment(int id)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            var payment = await _context.Payments.FindAsync(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        [HttpGet("order/{orderId}")]
        public async Task<ActionResult<Payment>> GetPaymentByOrderId(int orderId)
        {
            var payment = await _context.Payments.FirstOrDefaultAsync(p => p.OrderId == orderId);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        // PUT: api/Payments/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPayment(int id, Payment payment)
        {
            if (id != payment.PaymentId)
            {
                return BadRequest();
            }

            _context.Entry(payment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentExists(id))
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

        // DELETE: api/Payments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePayment(int id)
        {
            if (_context.Payments == null)
            {
                return NotFound();
            }
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(payment);
            await _context.SaveChangesAsync();

            return NoContent();
        }


        // POST: api/Payments

        [HttpPost]
        public async Task<ActionResult<Payment>> PostPayment(Payment payment)
        {
            if (_context.Payments == null)
            {
                return Problem("Entity set 'OrderContext.Payments'  is null.");
            }
            _context.Payments.Add(payment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPayment", new { id = payment.PaymentId }, payment);
        }

        [HttpPatch("{id}/PaymentVoid")]
        public async Task<IActionResult> UpdatePaymentVoid(int id, [FromBody] bool paymentVoid)
        {
            var payment = await _context.Payments.FindAsync(id);
            if (payment == null)

            {
                return NotFound();
            }

            payment.PaymentVoid = paymentVoid;
            await _context.SaveChangesAsync();

            return Ok();

        }

        private bool PaymentExists(int id)
        {
            return (_context.Payments?.Any(e => e.PaymentId == id)).GetValueOrDefault();
        }

    }
}
