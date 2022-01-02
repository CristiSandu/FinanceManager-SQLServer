#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceManagerAPI.Database;

namespace FinanceManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionAccController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public TransactionAccController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/TransactionAcc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionAcc>>> GetTransactionAccs()
        {
            return await _context.TransactionAccs.ToListAsync();
        }

        // GET: api/TransactionAcc/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TransactionAcc>> GetTransactionAcc(int id)
        {
            var transactionAcc = await _context.TransactionAccs.FindAsync(id);

            if (transactionAcc == null)
            {
                return NotFound();
            }

            return transactionAcc;
        }

        // PUT: api/TransactionAcc/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTransactionAcc(int id, TransactionAcc transactionAcc)
        {
            if (id != transactionAcc.TransactionId)
            {
                return BadRequest();
            }

            _context.Entry(transactionAcc).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TransactionAccExists(id))
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

        // POST: api/TransactionAcc
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TransactionAcc>> PostTransactionAcc(TransactionAcc transactionAcc)
        {
            _context.TransactionAccs.Add(transactionAcc);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (TransactionAccExists(transactionAcc.TransactionId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetTransactionAcc", new { id = transactionAcc.TransactionId }, transactionAcc);
        }

        // DELETE: api/TransactionAcc/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTransactionAcc(int id)
        {
            var transactionAcc = await _context.TransactionAccs.FindAsync(id);
            if (transactionAcc == null)
            {
                return NotFound();
            }

            _context.TransactionAccs.Remove(transactionAcc);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TransactionAccExists(int id)
        {
            return _context.TransactionAccs.Any(e => e.TransactionId == id);
        }
    }
}
