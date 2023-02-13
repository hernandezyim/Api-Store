using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StoreApi.CreationModels;
using StoreApi.Models;

namespace StoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UppergarmentsController : ControllerBase
    {
        private readonly StoreContext _context;

        public UppergarmentsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Uppergarment>>> GetUppergarments()
        {
            return await _context.Uppergarments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Uppergarment>> GetUppergarment(string id)
        {
            var uppergarment = await _context.Uppergarments.FindAsync(id);

            if (uppergarment == null)
            {
                return NotFound();
            }

            return uppergarment;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUppergarment(string id,CreateUppergarment _uppergarment)
        {
            var uppergarment = await _context.Undergarments.FindAsync(id);

            if (uppergarment == null)
            {
                return NotFound();
            }

            uppergarment.Brand = _uppergarment.Brand;
            uppergarment.Color = _uppergarment.Color;
            uppergarment.Size = _uppergarment.Size;
            uppergarment.Kind = _uppergarment.Kind;
            uppergarment.States = _uppergarment.States;
            uppergarment.IdClient = _uppergarment.IdClient;
            uppergarment.IdCubicle = _uppergarment.IdCubicle;

            _context.Entry(uppergarment).State = EntityState.Modified;

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Uppergarment>> PostUppergarment(CreateUppergarment _uppergarment)
        {
            var uppergarment = new Undergarment()
            {
                Id = Guid.NewGuid().ToString(),
                Brand = _uppergarment.Brand,
                Color = _uppergarment.Color,
                Size = _uppergarment.Size,
                Kind = _uppergarment.Kind,
                States = _uppergarment.States,
                IdClient = _uppergarment.IdClient,
                IdCubicle = _uppergarment.IdCubicle
            };

            _context.Undergarments.Add(uppergarment);
            await _context.SaveChangesAsync();

            return Created("", uppergarment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUppergarment(string id)
        {
            var uppergarment = await _context.Uppergarments.FindAsync(id);
            if (uppergarment == null)
            {
                return NotFound();
            }

            _context.Uppergarments.Remove(uppergarment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        [HttpPut("states/{id}")]
        public async Task<IActionResult> PutState(string id, bool state)
        {
            var uppergarment = await _context.Uppergarments.FindAsync(id);

            if (uppergarment == null)
            {
                return NotFound();
            }

            uppergarment.States = state;

            _context.Entry(uppergarment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("cubicle/{id}")]
        public async Task<IActionResult> PutCubicle(string id, string IdCubicle)
        {
            var uppergarment = await _context.Uppergarments.FindAsync(id);

            if (uppergarment == null)
            {
                return NotFound();
            }

            uppergarment.IdCubicle = IdCubicle;

            _context.Entry(uppergarment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
