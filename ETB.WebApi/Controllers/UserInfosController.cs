using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ETB.Core.Entities;
using ETB.Utilities;
using ETB.WebApi.DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace ETB.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserInfosController : ControllerBase
    {
        private readonly ETBContext _context;
        private readonly DataProtector _dataProtector;
        private readonly EncryptionDecryption _encryptionDecryption;
        public UserInfosController(ETBContext context, DataProtector dataProtector, EncryptionDecryption encryptionDecryption)
        {
            _context = context;
            _dataProtector = dataProtector;
            _encryptionDecryption = encryptionDecryption;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> Get()
        {
            try
            {
                return await _context.UserInfos.ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserInfosController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [Route("/api/AUserInfos")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserInfo>>> GetActiveUserInfos()
        {
            try
            {
                return await _context.UserInfos.Where(x => x.Allow == IsActive.Y).ToListAsync();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserInfosController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/ValidateCredentials")]
        [HttpPost]
        public async Task<ActionResult<UserInfoAuthenticationResult>> ValidateCredentials(UserInfo userInfo)
        {
            try
            {
                var item = await _context.UserInfos.Where(x => x.Allow == IsActive.Y
                                                    && x.UserId == userInfo.UserId).FirstOrDefaultAsync();
                if (item == null)
                {
                    return NotFound();
                }
                else
                {
                    if (!_encryptionDecryption.VerifyHashedPassword(item.Pass , userInfo.Pass))
                    {
                        return new UserInfoAuthenticationResult()
                        {
                            Id = item.Id,
                            UserId = item.UserId,
                            IsAuthenticated = false,
                            UserRole = item.UserRole,
                            HashedData = HashUserDataForIdentityProtection(item, false)
                        }; ;
                    }
                }
                return new UserInfoAuthenticationResult() {
                    Id = item.Id,
                    UserId = item.UserId,
                    IsAuthenticated = true,
                    UserRole = item.UserRole,
                    HashedData = HashUserDataForIdentityProtection(item, true)
                };
            }
            catch (Exception ex)
            {
                Log.ForContext<UserInfosController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        private string HashUserDataForIdentityProtection(UserInfo userInfo, bool isValid)
        {
            string data = $"{userInfo.UserId}~{isValid.ToString()}~{userInfo.UserRole.ToString()}";
            return _encryptionDecryption.HashPassword(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserInfo>> GetById(int id)
        {
            try
            {
                var item = await _context.UserInfos.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                return item;
            }
            catch (Exception ex)
            {
                Log.ForContext<UserInfosController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("/api/Users/IsUserExists/{userId}")]
        public async Task<ActionResult<bool>> IsUserExists(string userId)
        {
            try
            {
                var item = await _context.UserInfos.FirstOrDefaultAsync<UserInfo>(x => x.UserId == userId);
            
                if (item == null)
                {
                    return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.ForContext<UserInfosController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<UserInfo>> PostAnItem([FromBody] UserInfo item)
        {
            try
            {
                if (item.UserRole == 0)
                {
                    var adminUsers = _context.UserInfos.Where(x => x.UserRole == UserRole.Admin);
                    if (adminUsers.Count() >= 1)
                    {
                        return BadRequest("Cannot have more than one Admin user in database.");
                    }
                }
                _context.UserInfos.Add(item);
                var returnval = await _context.SaveChangesAsync();

                if (returnval >= 1)
                {
                    //return Ok(new { returnData = item, status = "Successful", error = "" });
                    return CreatedAtAction(nameof(GetById), new { id = item.Id }, item);
                }
                else
                {
                    string message = "UserInfo data didn't get saved";
                    Log.ForContext<UserInfosController>().Error(message);
                    return BadRequest(message);
                }
                
            }
            catch (Exception ex)
            {
                Log.ForContext<UserInfosController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnItem(int id, [FromBody] UserInfo item)
        {
            try
            {
                if (id != item.Id)
                {
                    return BadRequest();
                }

                _context.Entry(item).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return AcceptedAtAction("GetById", new { id = item.Id }, item);
            }
            catch (Exception ex)
            {
                Log.ForContext<UserInfosController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnItem(int id)
        {
            try
            {
                var item = await _context.UserInfos.FindAsync(id);

                if (item == null)
                {
                    return NotFound();
                }

                _context.UserInfos.Remove(item);
                await _context.SaveChangesAsync();

                return NoContent();
            }
            catch (Exception ex)
            {
                Log.ForContext<UserInfosController>().Error(ex.Message);
                return BadRequest(ex.Message);
            }

        }
    }
}