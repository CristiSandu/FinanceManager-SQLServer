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
    public class StatsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public StatsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Stats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Stat>>> GetStats()
        {
            return await _context.Stats.ToListAsync();
        }

        // GET: api/Stats/GetSmallStats
        [HttpGet("GetSmallStats")]
        public async Task<ActionResult<List<SmallStat>>> GetTransactionForAnAccount()
        {
            return await _context.SmallStats.FromSqlRaw($"exec GetSmallStats ").ToListAsync();
        }

        // GET: api/Stats/GetStatsForAPeriod
        //https://localhost:7025/api/Stats/GetStatsForAPeriod?type_id=6&account_id=2&endDate=2024-05-01&how_manny=6'
        [HttpGet("GetStatsForAPeriod")]
        public async Task<ActionResult<List<Stat>>> GetStatsForAPeriod(int type_id, int account_id, int how_manny)
        {
            List<Stat> stats = new();

            List<DateTime> dates = new List<DateTime> ();
            if (how_manny == 6)
                dates = Helper.HelperMethods.GetLastXMonths(how_manny);
            else if (how_manny == 3)
                dates = Helper.HelperMethods.GetLastXYears(how_manny);
            else
                dates = Helper.HelperMethods.GetLastXMonths(how_manny);

            foreach (var date in dates)
            {
                var output = await _context.Stats.FromSqlRaw($"exec GetStatsForASepcificDate {type_id}, {account_id}, '{date.ToString("yyyy-MM-dd")}'").ToListAsync();
                if (output.Count == 1)
                {
                    stats.AddRange(output);
                }else
                {
                    stats.Add(new Stat { StatsDate = date , Incomes= 0, Expences= 0, TypesId = type_id, AccountId = account_id, TimeStamp = date});
                }
            }

            return stats;
        }

        // GET: api/Stats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Stat>> GetStat(int id)
        {
            var stat = await _context.Stats.FindAsync(id);

            if (stat == null)
            {
                return NotFound();
            }

            return stat;
        }

        // PUT: api/Stats/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStat(int id, Stat stat)
        {
            if (id != stat.StatsId)
            {
                return BadRequest();
            }

            _context.Entry(stat).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatExists(id))
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

        // POST: api/Stats
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Stat>> PostStat(Stat stat)
        {
            _context.Stats.Add(stat);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (StatExists(stat.StatsId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStat", new { id = stat.StatsId }, stat);
        }

        // DELETE: api/Stats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStat(int id)
        {
            var stat = await _context.Stats.FindAsync(id);
            if (stat == null)
            {
                return NotFound();
            }

            _context.Stats.Remove(stat);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StatExists(int id)
        {
            return _context.Stats.Any(e => e.StatsId == id);
        }
    }
}
