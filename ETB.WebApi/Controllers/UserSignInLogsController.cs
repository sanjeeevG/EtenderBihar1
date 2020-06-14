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
    public class UserSignInLogsController : ControllerBase
    {
        private readonly ETBContext _context;

        public UserSignInLogsController(ETBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSignInLog>>> Get()
        {
            try
            {
                return await _context.UserSignInLogs.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserSignInLogsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserSignInLog>> GetById(int id)
        {
            try
            {
                var item = await _context.UserSignInLogs.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch (Exception ex)
            {
                Log.ForContext<UserSignInLogsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserSignInLog>> PostAnItem([FromBody] UserSignInLog item)
        {
            try
            {
                _context.UserSignInLogs.Add(item);
                _context.Entry(item.UserInfo).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<UserSignInLogsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnItem(int id, [FromBody] UserSignInLog item)
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
                Log.ForContext<UserSignInLogsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnItem(int id)
        {
            try
            {
                var item = await _context.UserSignInLogs.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                _context.UserSignInLogs.Remove(item);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserSignInLogsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}