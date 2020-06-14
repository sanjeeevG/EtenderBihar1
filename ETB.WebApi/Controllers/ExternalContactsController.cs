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
    public class ExternalContactsController : ControllerBase
    {
        private readonly ETBContext _context;

        public ExternalContactsController(ETBContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExternalContact>> GetById(int id)
        {
            try
            {
                var item = await _context.ExternalContacts.FindAsync(id);

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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExternalContact>>> Get()
        {
            try
            {
                return await _context.ExternalContacts.ToListAsync();
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
        public async Task<ActionResult<ExternalContact>> PostAnItem([FromBody] ExternalContact item)
        {
            try
            {
                _context.ExternalContacts.Add(item);
                var returnval = await _context.SaveChangesAsync();

                if (returnval >= 1)
                {
                    return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
                }
                else
                {
                    string message = "External contract data didn't get saved";
                    Log.ForContext<ExternalContactsController>().Error(message);
                    return BadRequest(message);
                }
            }
            catch (Exception ex)
            {
                Log.ForContext<ExternalContactsController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }
    }
}