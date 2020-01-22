using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using fitnessTracker.Data;
using fitnessTracker.core;

namespace fitnessTracker.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class FitnessPlansController : ControllerBase
    {
        private readonly FitnessTrackerDbContext _context;

        public FitnessPlansController(FitnessTrackerDbContext context)
        {
            _context = context;
        }

        // GET: api/FitnessPlans
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FitnessPlan>>> GetFitnessPlans()
        {
            return await _context.FitnessPlans.ToListAsync();
        }

        // GET: api/FitnessPlans/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FitnessPlan>> GetFitnessPlan(int id)
        {
            var fitnessPlan = await _context.FitnessPlans.FindAsync(id);

            if (fitnessPlan == null)
            {
                return NotFound();
            }

            return fitnessPlan;
        }

        // PUT: api/FitnessPlans/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFitnessPlan(int id, FitnessPlan fitnessPlan)
        {
            if (id != fitnessPlan.Id)
            {
                return BadRequest();
            }

            _context.Entry(fitnessPlan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FitnessPlanExists(id))
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

        // POST: api/FitnessPlans
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<FitnessPlan>> PostFitnessPlan(FitnessPlan fitnessPlan)
        {
            _context.FitnessPlans.Add(fitnessPlan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFitnessPlan", new { id = fitnessPlan.Id }, fitnessPlan);
        }

        // DELETE: api/FitnessPlans/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<FitnessPlan>> DeleteFitnessPlan(int id)
        {
            var fitnessPlan = await _context.FitnessPlans.FindAsync(id);
            if (fitnessPlan == null)
            {
                return NotFound();
            }

            _context.FitnessPlans.Remove(fitnessPlan);
            await _context.SaveChangesAsync();

            return fitnessPlan;
        }

        private bool FitnessPlanExists(int id)
        {
            return _context.FitnessPlans.Any(e => e.Id == id);
        }
    }
}
