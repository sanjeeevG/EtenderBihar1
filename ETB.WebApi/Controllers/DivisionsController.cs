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
    public class DivisionsController : ControllerBase
    {
        private readonly ETBContext _context;

        public DivisionsController(ETBContext context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Division>>> Get()
        {
            try
            {
                return await _context.Divisions.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<DivisionsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Division>> GetById(int id)
        {
            try
            {
                var item = await _context.Divisions.FindAsync(id);


                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }
            catch (Exception ex)
            {
                Log.ForContext<DivisionsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Division>> PostAnItem([FromBody] Division item)
        {
            try
            {
                _context.Divisions.Add(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<DivisionsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnItem(int id)
        {
            try
            {
                var item = await _context.Divisions.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                _context.Divisions.Remove(item);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<DivisionsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

    }
}