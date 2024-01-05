using gubiarpa.prosegur_coffee.web_api.Data;
using gubiarpa.prosegur_coffee.web_api.Dtos.Users;
using gubiarpa.prosegur_coffee.web_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace gubiarpa.prosegur_coffee.web_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly CoffeeDbContext _dbContext;

        public UserController(CoffeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }

        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetUserById([FromRoute] Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        public async Task<IActionResult> AddUser(AddUserRequest user)
        {
            var newUser = new User()
            {
                IDUser = Guid.NewGuid(),
                Fullname = user.Fullname,
                DocumentNumber = user.DocumentNumber,
                Birthdate = user.Birthdate
            };

            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();

            return Ok(newUser);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateUser([FromRoute] Guid id, UpdateUserRequest user)
        {
            var updateUser = await _dbContext.Users.FindAsync(id);

            if (updateUser == null)
                return NotFound();

            updateUser.Fullname = user.Fullname;
            updateUser.Birthdate = user.Birthdate;

            await _dbContext.SaveChangesAsync();

            return Ok(updateUser);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteUser([FromRoute] Guid id)
        {
            var user = await _dbContext.Users.FindAsync(id);

            if (user == null)
                return NotFound();

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync();

            return Ok(user);
        }
    }
}
