using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETB.Core.Entities;
using ETB.WebApi.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ETB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly ETBContext _context;

        public ServicesController(ETBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> Get()
        {
            try
            {
                return await _context.Services.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<ServicesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [Route("/api/AServices")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Service>>> GetActiveServices()
        {
            try
            {
                return await _context.Services.Include(s => s.ServiceDetails).Where(x => x.IsActive == IsActive.Y).ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<ServicesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Service>> Get(int id)
        {
            try
            {
                var item = await _context.Services.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }
                await _context.Entry(item).Collection(x => x.ServiceDetails).LoadAsync();
                
                return item;
            }
            catch (Exception ex)
            {
                Log.ForContext<ServicesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Service>> PostAnItem([FromBody] Service item)
        {
            try
            {
                _context.Services.Add(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(Service), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<ServicesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnItem(int id, [FromBody] Service item)
        {
            try
            {
                if (id != item.Id)
                {
                    return BadRequest();
                }

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<ServicesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnItem(int id)
        {
            try
            {
                var item = await _context.Services.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                _context.Services.Remove(item);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<ServicesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}