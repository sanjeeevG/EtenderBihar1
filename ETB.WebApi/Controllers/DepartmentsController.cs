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
    public class DepartmentsController : ControllerBase
    {
        private readonly ETBContext _context;

        public DepartmentsController(ETBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> Get()
        {
            try
            {
                return await _context.Departments.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<DepartmentsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetById(int id)
        {
            try
            {
                var item = await _context.Departments.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }
                return item;
            }
            catch (Exception ex)
            {
                Log.ForContext<DepartmentsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Department>> PostAnItem([FromBody] Department item)
        {
            try
            {
                _context.Departments.Add(item);
                var returnval = await _context.SaveChangesAsync();

                if (returnval >= 1)
                {
                    return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
                }
                else
                {
                    string message = "Department data didn't get saved";
                    Log.ForContext<DepartmentsController>().Error(message);
                    return BadRequest(message);
                }
            }
            catch (Exception ex)
            {
                Log.ForContext<DepartmentsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnItem(int id, [FromBody] Department item)
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
                Log.ForContext<DepartmentsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnItem(int id)
        {
            try
            {
                var item = await _context.Departments.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                _context.Departments.Remove(item);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<DepartmentsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}