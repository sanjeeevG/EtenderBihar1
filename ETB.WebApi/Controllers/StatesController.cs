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
    public class StatesController : ControllerBase
    {
        private readonly ETBContext _context;

        public StatesController(ETBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> Get()
        {
            try
            {
                return await _context.States.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<StatesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetById(int id)
        {
            try
            {
                var item = await _context.States.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }
            catch (Exception ex)
            {
                Log.ForContext<StatesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<State>> PostAnItem([FromBody] State item)
        {
            try
            {
                _context.States.Add(item);
                var returnval = await _context.SaveChangesAsync();

                if (returnval >= 1)
                {
                    return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
                }
                else
                {
                    string message = "State data didn't get saved";
                    Log.ForContext<StatesController>().Error(message);
                    return BadRequest(message);
                }
            }
            catch (Exception ex)
            {
                Log.ForContext<StatesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnItem(int id, [FromBody] State item)
        {
            try
            {
                if (id != item.Id)
                {
                    return BadRequest();
                }

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return AcceptedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<StatesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnItem(int id)
        {
            try
            {
                var item = await _context.States.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                _context.States.Remove(item);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<StatesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}