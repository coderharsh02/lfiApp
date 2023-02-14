using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // {url}/api/users
    public class UsersController : BaseApiController
    {
        // _context would be used to access the database
        private readonly DataContext _context;

        // As we want to use data from the database, we need to inject the DataContext into the constructor
        public UsersController(DataContext context)
        {
            _context = context;
        }

        // Now lets create an endpoint to get all the users from the database
        // we are using async await so that a request is not blocked while waiting for the database to respond
        // {url}/api/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            // We need to return an ActionResult, so we can return certain status codes
            // We need to return an IEnumerable of AppUser, so we can return a list of users
            // We need to make this method asynchronous, so we can use await
            // We need to use await to get the users from the database
            var users = await _context.Users.ToListAsync();
            return users;
        }

        // Now lets create an endpoint to get a single user from the database
        // {url}/api/users/1
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            // We need to return an ActionResult, so we can return certain status codes
            // We need to return an AppUser, so we can return a single user
            // We need to make this method asynchronous, so we can use await
            // We need to use await to get the user from the database
            var user = await _context.Users.FindAsync(id);
            return user;
        }

    }
}