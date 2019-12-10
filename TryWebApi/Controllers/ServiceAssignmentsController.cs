using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TryWebApi.Data;
using TryWebApi.Models;

namespace TryWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceAssignmentsController : ControllerBase
    {
        private readonly TryWebApiContext _context;

        public ServiceAssignmentsController(TryWebApiContext context)
        {
            _context = context;
        }

        // GET: api/ServiceAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceAssignment>>> GetServiceAssignments()
        {
            return await _context.ServiceAssignments.ToListAsync();
        }

        // GET: api/ServiceAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceAssignment>> GetServiceAssignment(int id)
        {
            ServiceAssignment serviceAssignment = await _context.ServiceAssignments.FindAsync(id);

            if (serviceAssignment == null)
            {
                return NotFound();
            }

            return serviceAssignment;
        }

        // PUT: api/ServiceAssignments/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceAssignment(int id, ServiceAssignment serviceAssignment)
        {
            if (id != serviceAssignment.UserID)
            {
                return BadRequest();
            }

            _context.Entry(serviceAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceAssignmentExists(id))
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

        // POST: api/ServiceAssignments
        [HttpPost]
        public async Task<ActionResult<ServiceAssignment>> PostServiceAssignment(ServiceAssignment serviceAssignment)
        {
            _context.ServiceAssignments.Add(serviceAssignment);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (ServiceAssignmentExists(serviceAssignment.UserID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return serviceAssignment;
        }

        // DELETE: api/ServiceAssignments/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceAssignment>> DeleteServiceAssignment(int id)
        {
            var serviceAssignment = await _context.ServiceAssignments.FindAsync(id);
            if (serviceAssignment == null)
            {
                return NotFound();
            }

            _context.ServiceAssignments.Remove(serviceAssignment);
            await _context.SaveChangesAsync();

            return serviceAssignment;
        }

        private bool ServiceAssignmentExists(int id)
        {
            return _context.ServiceAssignments.Any(e => e.UserID == id);
        }
    }
}
