using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using UnitofWork_Implemention.Core.IConfiguration;
using UnitofWork_Implemention.Models;

namespace UnitofWork_Implemention.Controllers
{
    [ApiController]
    [Route("api")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly IUnitOfWork _uow;

        public UserController(ILogger<UserController> logger, IUnitOfWork uow)
        {
            _logger = logger;
            _uow = uow;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = System.Guid.NewGuid();

                await _uow.Users.Add(user);
                await _uow.CompleteAsync();

                return CreatedAtAction("GetItem", new {user.Id}, user);
            }
            return new JsonResult("Something went wrong") { StatusCode = 500};
        }
        
        [HttpGet("{id}")] 
        public async Task<IActionResult> GetItem(Guid id)
        {
            var user = await _uow.Users.GetById(id);
            if(user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}
