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
    public class UndergarmentsController : ControllerBase
    {
        private readonly StoreContext _context;

        public UndergarmentsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Undergarment>>> GetUndergarments()
        {
            return await _context.Undergarments.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Undergarment>> GetUndergarment(string id)
        {
            var undergarment = await _context.Undergarments.FindAsync(id);

            if (undergarment == null)
            {
                return NotFound();
            }

            return undergarment;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUndergarment(string id, CreateUndergarment _undergarment)
        {
            var undergarment = await _context.Undergarments.FindAsync(id);

            if (undergarment == null)
            {
                return NotFound();
            }

            undergarment.Brand = _undergarment.Brand;
            undergarment.Color = _undergarment.Color;
            undergarment.Size = _undergarment.Size;
            undergarment.Kind = _undergarment.Kind;
            undergarment.States = _undergarment.States;
            undergarment.IdClient = _undergarment.IdClient;
            undergarment.IdCubicle = _undergarment.IdCubicle;

            _context.Entry(undergarment).State = EntityState.Modified;

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Undergarment>> PostUndergarment(CreateUndergarment _undergarment)
        {
            var undergarment = new Undergarment()
            {
                Id = Guid.NewGuid().ToString(),
                Brand = _undergarment.Brand,
                Color = _undergarment.Color,
                Size = _undergarment.Size,
                Kind = _undergarment.Kind,
                States = _undergarment.States,
                IdClient = _undergarment.IdClient,
                IdCubicle = _undergarment.IdCubicle
            };

            _context.Undergarments.Add(undergarment);
            await _context.SaveChangesAsync();

            return Created("", undergarment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUndergarment(string id)
        {
            var undergarment = await _context.Undergarments.FindAsync(id);
            if (undergarment == null)
            {
                return NotFound();
            }

            _context.Undergarments.Remove(undergarment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("states/{id}")]
        public async Task<IActionResult> PutState(string id, bool state)
        {
            var undergarment = await _context.Undergarments.FindAsync(id);

            if (undergarment == null)
            {
                return NotFound();
            }

            undergarment.States = state;

            _context.Entry(undergarment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("cubicle/{id}")]
        public async Task<IActionResult> PutCubicle(string id, string IdCubicle)
        {
            var undergarment = await _context.Undergarments.FindAsync(id);

            if (undergarment == null)
            {
                return NotFound();
            }

            undergarment.IdCubicle = IdCubicle;

            _context.Entry(undergarment).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
