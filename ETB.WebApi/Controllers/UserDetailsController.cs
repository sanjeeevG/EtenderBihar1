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
    public class UserDetailsController : ControllerBase
    {
        private readonly ETBContext _context;

        public UserDetailsController(ETBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> Get()
        {
            try
            {
                return await _context.UserDetails.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [Route("/api/AUserDetails")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetActiveUserDetails()
        {
            try
            {
                return await _context.UserDetails.Where(x => x.IsActive == IsActive.Y).ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [Route("/api/DAUserDetails")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetail>>> GetDeActiveUserDetails()
        {
            try
            {
                return await _context.UserDetails.Where(x => x.IsActive == IsActive.N).ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDetail>> GetById(int id)
        {
            try
            {
                var item = await _context.UserDetails.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }
                await _context.Entry(item).Reference(x => x.UserInfo).LoadAsync();
                return item;
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/api/DeActivateUser/{id}")]
        public async Task<ActionResult<UserDetail>> DeActivateUserById(int id)
        {
            try
            {
                var item = await _context.UserDetails.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }
                await _context.Entry(item).Reference(x => x.UserInfo).LoadAsync();

                item.IsActive = IsActive.N;
                item.ModificationDate = DateTime.Now;
                item.UserInfo.Allow = IsActive.N;

                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item.UserInfo).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return AcceptedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("/api/ActivateUser/{id}")]
        public async Task<ActionResult<UserDetail>> ActivateUserById(int id)
        {
            try
            {
                var item = await _context.UserDetails.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }
                await _context.Entry(item).Reference(x => x.UserInfo).LoadAsync();

                item.IsActive = IsActive.Y;
                item.UserInfo.Allow = IsActive.Y;

                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item.UserInfo).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return AcceptedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/UserInfoDetail/{userId}")]
        public async Task<ActionResult<UserDetail>> GetUserInfoDetail(string userId)
        {
            try
            {
                var item = await _context.UserDetails.Where(x => x.IsActive == IsActive.Y 
                                                            && x.UserInfo.UserId == userId).SingleOrDefaultAsync();

                if (item == null)
                {
                    return NotFound();
                }
                await _context.Entry(item).Reference(x => x.UserInfo).LoadAsync();
                return item;
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserDetail>> PostAnItem([FromBody] UserDetail item)
        {
            try
            {
                _context.UserDetails.Add(item);
                var returnval = await _context.SaveChangesAsync();

                if (returnval >= 1)
                {
                    //return Ok(new { returnData = item, status = "Successful", error = "" });
                    return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
                }
                else
                {
                    string message = "UserDetail data didn't get saved";
                    Log.ForContext<UserDetailsController>().Error(message);
                    return BadRequest(message);
                }
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnItem(int id, [FromBody] UserDetail item)
        {
            try
            {
                if (id != item.Id)
                {
                    return BadRequest();
                }

                _context.Entry(item).State = EntityState.Modified;
                _context.Entry(item.UserInfo).State = EntityState.Unchanged;
                await _context.SaveChangesAsync();

                return AcceptedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnItem(int id)
        {
            try
            {
                var item = await _context.UserDetails.FindAsync(id);
                await _context.Entry(item).Reference(x => x.UserInfo).LoadAsync();

                if (item == null)
                {
                    return NotFound();
                }

                _context.UserDetails.Remove(item);
                _context.Entry(item.UserInfo).State = EntityState.Deleted;
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserDetailsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}