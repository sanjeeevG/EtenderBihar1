using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ETB.Core.Entities;
using ETB.WebApi.DataAccess;
using ETB.WebApi.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;

namespace ETB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TendersController : ControllerBase
    {
        private readonly ETBContext _context;
        private readonly IOptions<ApplicationSettingsApi> _appSettings;
        public TendersController(ETBContext context, IOptions<ApplicationSettingsApi> appSettings)
        {
            _context = context;
            _appSettings = appSettings;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tender>>> Get()
        {
            try
            {
                return await _context.Tenders.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<TendersController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/ATenders")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tender>>> GetActiveTender()
        {
            try
            {
                var headers = HttpContext.Request.Headers;
                if (!string.IsNullOrEmpty(headers[_appSettings.Value.TotalNoOfRowsKey]))
                {
                    var noofRows = int.Parse(headers[_appSettings.Value.TotalNoOfRowsKey]);
                    if (noofRows != 0)
                    {
                        return await _context.Tenders.Where(x => x.IsActive == IsActive.Y && x.BidSubmissionEnDate >= DateTime.Now).Take(noofRows).ToListAsync();
                    }
                    else
                    {
                        return await _context.Tenders.Include(x => x.TenderDocs).Where(x => x.IsActive == IsActive.Y).ToListAsync();
                    }
                }
                else
                {
                    return await _context.Tenders.Include(x => x.TenderDocs).Where(x => x.IsActive == IsActive.Y).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                Log.ForContext<TendersController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Tender>> GetById(int id)
        {
            try
            {
                var tenderitem = await _context.Tenders.FindAsync(id);


                if (tenderitem == null)
                {
                    return NotFound();
                }

                await _context.Entry(tenderitem).Collection(x => x.TenderDocs).LoadAsync();
                return tenderitem;
            }
            catch (Exception ex)
            {
                Log.ForContext<TendersController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Tender>> PostAnItem([FromBody] Tender item)
        {
            try
            {
                _context.Tenders.Add(item);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<TendersController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnItem(int id, [FromBody] Tender item)
        {
            try
            {
                if (id != item.Id)
                {
                    return BadRequest();
                }

                _context.Entry(item).State = EntityState.Modified;
                if (item.TenderDocs != null)
                {
                    foreach (var childItem in item.TenderDocs)
                    {
                        if (childItem.Id == 0)
                            _context.Entry(childItem).State = EntityState.Added;
                        else
                            _context.Entry(childItem).State = EntityState.Modified;
                    }
                }
                await _context.SaveChangesAsync();
                return AcceptedAtAction(nameof(GetById), new { id = item.Id }, item);

            }
            catch (Exception ex)
            {
                Log.ForContext<TendersController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnItem(int id)
        {
            try
            {
                var tenderItem = await _context.Tenders.FindAsync(id);
                await _context.Entry(tenderItem).Collection(x => x.TenderDocs).LoadAsync();

                if (tenderItem == null)
                {
                    return NotFound();
                }

                _context.Tenders.Remove(tenderItem);
                foreach (var td in tenderItem.TenderDocs)
                {
                    _context.Entry(td).State = EntityState.Deleted;
                }
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<TendersController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}