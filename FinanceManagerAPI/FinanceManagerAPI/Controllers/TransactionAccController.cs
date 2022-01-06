#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FinanceManagerAPI.Database;
using System.Drawing;
using FinanceManagerAPI.Models;

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

        // GET: api/TransactionAcc/GetTransactionForAnAccount
        [HttpGet("GetTransactionForAnAccount/{id_account}")]
        public async Task<ActionResult<IEnumerable<TransactionInfoExt>>> GetTransactionForAnAccount(int id_account)
        {
            return await _context.TransactionInfoExts.FromSqlRaw($"exec GetTransactionForAnAccount {id_account}").ToListAsync();
        }

        // GET: api/TransactionAcc/GetTransactionForAnAccount
        [HttpGet("GroupTransactionsByCategorys")]
        public async Task<ActionResult<List<GroupDateTransactionCategoryModel>>> GroupTransactionsByCategorys(int? id_account = 1, char? statType = 'M')
        {
            var list_of_categoris = await _context.Categories.ToListAsync();

            List<GroupDateTransactionCategoryModel> list_of_dates = new();

            DateTime dateT = DateTime.Now;

            List<DateTime> dates = new();
            for (int i = 0; i < 6; i++)
            {
                dates.Add(dateT);
                dateT = dateT.AddMonths(-1);
            }

            foreach (var date in dates)
            {
                GroupDateTransactionCategoryModel current_date_transactions = new GroupDateTransactionCategoryModel { DateGoup = new DateTime(date.Year, date.Month, 1), CategoryTransaction = new() };

                foreach (var c in list_of_categoris)
                {

                   var output =  await _context.TransactionInfoExts.FromSqlRaw($"exec GroupByCategorys '{c.CategoryName}', '{date.ToString("yyyy-MM-dd")}', '{statType}', {id_account}").ToListAsync();
                    if (output.Count == 0)
                        continue;

                    current_date_transactions.CategoryTransaction.Add(new GroupByCategotyModel
                    {
                        CategotyName = c.CategoryName,
                        TransactionsList = output

                    });
                }

                list_of_dates.Add(current_date_transactions);
            }

            return list_of_dates;
        }



        // GET: api/TransactionAcc
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TransactionAcc>>> GetTransactionAccs()
        {
            //var outval = await _context.TransactionAccs.FromSqlRaw($"exec Generate_Product {"'2022-01-09'"}, {1}, {1}").ToListAsync();
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
