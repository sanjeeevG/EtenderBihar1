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
    public class UserSubscriptionsController : ControllerBase
    {
        private readonly ETBContext _context;

        public UserSubscriptionsController(ETBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserSubscription>>> Get()
        {
            try
            {
                var datas = await _context.UserSubscriptions.ToListAsync();
                datas.ForEach(x => _context.Entry(x).Reference(r => r.UserDetail).Load());
                datas.ForEach(x => _context.Entry(x).Reference(r => r.Service).Load());
                return datas;
            }
            catch (Exception ex)
            {
                Log.ForContext<UserSubscriptionsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserSubscription>> GetById(int id)
        {
            try
            {
                var item = await _context.UserSubscriptions.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch (Exception ex)
            {
                Log.ForContext<UserSubscriptionsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserSubscription>> PostAnItem([FromBody] UserSubscription item)
        {
            try
            {
                _context.UserSubscriptions.Add(item);
                _context.Entry(item.UserDetail).State = EntityState.Unchanged;
                _context.Entry(item.Service).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<UserSubscriptionsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnItem(int id, [FromBody] UserSubscription item)
        {
            try
            {
                if (id != item.Id)
                {
                    return BadRequest();
                }

                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item.UserDetail).State = EntityState.Unchanged;
                _context.Entry(item.Service).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserSubscriptionsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}