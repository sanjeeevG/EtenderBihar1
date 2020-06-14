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
    public class DistrictsController : ControllerBase
    {
        private readonly ETBContext _context;

        public DistrictsController(ETBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<District>>> Get()
        {
            try
            {
                return await _context.Districts.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<ServicesController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}