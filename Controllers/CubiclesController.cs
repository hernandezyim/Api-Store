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
    public class CubiclesController : ControllerBase
    {
        private readonly StoreContext _context;

        public CubiclesController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cubicle>>> GetCubicles()
        {
            return await _context.Cubicles.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cubicle>> GetCubicle(string id)
        {
            var cubicle = await _context.Cubicles.FindAsync(id);

            if (cubicle == null)
            {
                return NotFound();
            }

            return cubicle;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCubicle(string id, CreateCubicle _cubicle)
        {
            var cubicle = await _context.Cubicles.FindAsync(id);

            if(cubicle == null)
            {
                return NotFound();
            }

            cubicle.Width = _cubicle.Width;
            cubicle.Height = _cubicle.Height;
            cubicle.Longitude = _cubicle.Longitude;

            _context.Entry(cubicle).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Cubicle>> PostCubicle(CreateCubicle _cubicle)
        {

            var cubicle = new Cubicle()
            {
                Id = Guid.NewGuid().ToString(),
                Width = _cubicle.Width,
                Height = _cubicle.Height,
                Longitude = _cubicle.Longitude,
                IdClient = _cubicle.IdClient,
            };

            _context.Cubicles.Add(cubicle);
            await _context.SaveChangesAsync();

            return Created("", cubicle);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCubicle(string id)
        {
            var cubicle = await _context.Cubicles.FindAsync(id);
            if (cubicle == null)
            {
                return NotFound();
            }

            _context.Cubicles.Remove(cubicle);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
