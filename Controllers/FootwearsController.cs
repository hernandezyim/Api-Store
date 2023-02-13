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
    public class FootwearsController : ControllerBase
    {
        private readonly StoreContext _context;

        public FootwearsController(StoreContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Footwear>>> GetFootwears()
        {
            return await _context.Footwears.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Footwear>> GetFootwear(string id)
        {
            var footwear = await _context.Footwears.FindAsync(id);

            if (footwear == null)
            {
                return NotFound();
            }

            return footwear;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutFootwear(string id, CreateFootwear _footwear)
        {
            var footwear = await _context.Footwears.FindAsync(id);

            if(footwear == null)
            {
                return NotFound();
            }

            footwear.Brand = _footwear.Brand;
            footwear.Color = _footwear.Color;
            footwear.Size = _footwear.Size;
            footwear.Kind = _footwear.Kind;
            footwear.States = _footwear.States;
            footwear.IdClient = _footwear.IdClient;
            footwear.IdCubicle = _footwear.IdCubicle;

            _context.Entry(footwear).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Footwear>> PostFootwear(CreateFootwear _footwear)
        {
            var footwear = new Footwear()
            {
                Id = Guid.NewGuid().ToString(),
                Brand = _footwear.Brand,
                Color = _footwear.Color,
                Size = _footwear.Size,
                Kind = _footwear.Kind,
                States = _footwear.States,
                IdClient = _footwear.IdClient,
                IdCubicle = _footwear.IdCubicle
            };

            _context.Footwears.Add(footwear);
            await _context.SaveChangesAsync();

            return Created("", footwear);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFootwear(string id)
        {
            var footwear = await _context.Footwears.FindAsync(id);
            if (footwear == null)
            {
                return NotFound();
            }

            _context.Footwears.Remove(footwear);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FootwearExists(string id)
        {
            return _context.Footwears.Any(e => e.Id == id);
        }
    }
}
