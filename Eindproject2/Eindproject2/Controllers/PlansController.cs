using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Eindproject2.Models;
using Eindproject2.Models.Data;
using AutoMapper;
using Eindproject2.Models.Repositories;
using Microsoft.AspNetCore.Authorization;

namespace Eindproject2
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlansController : ControllerBase
    {
        private readonly Eindproject2APIContext _context;
        private IPlanRepo PlanRepo;
        private IMapper Mapper;

        public PlansController(Eindproject2APIContext context, IPlanRepo planRepo, IMapper mapper)
        {
            _context = context;
            PlanRepo = planRepo;
            Mapper = mapper;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            var plans = await PlanRepo.GetAllPlans();
            return Ok(Mapper.Map<IEnumerable<PlansModel>>(plans));
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlans([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plans = await _context.Plans.FindAsync(id);

            if (plans == null)
            {
                return NotFound();
            }

            return Ok(plans);
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlans([FromRoute] int id, [FromBody] Plans plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plans.ID)
            {
                return BadRequest();
            }

            _context.Entry(plans).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlansExists(id))
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

        // POST: api/Plans
        [HttpPost]
        public async Task<IActionResult> PostPlans([FromBody] Plans plans)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Plans.Add(plans);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPlans", new { id = plans.ID }, plans);
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlans([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plans = await _context.Plans.FindAsync(id);
            if (plans == null)
            {
                return NotFound();
            }

            _context.Plans.Remove(plans);
            await _context.SaveChangesAsync();

            return Ok(plans);
        }

        private bool PlansExists(int id)
        {
            return _context.Plans.Any(e => e.ID == id);
        }
    }
}