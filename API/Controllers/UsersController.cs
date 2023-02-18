using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    // Adding authorize attribute to the controller will make all the endpoints in the controller to be 
    // authorized by default and we can override it by adding AllowAnonymous attribute to the endpoint.
    // We cannot use the AllowAnonymous attribute on the controller as it will override the authorize attribute specified at the endpoint.
    [Authorize]
    // {url}/api/users
    public class UsersController : BaseApiController
    {
        // _context would be used to access the database
        private readonly DataContext _context;

        private readonly IRepository _repository;

        // As we want to use data from the database, we need to inject the DataContext into the constructor
        public UsersController(DataContext context, IRepository repository)
        {
            _context = context;
            _repository = repository;
        }

        // Now lets create an endpoint to get all the users from the database
        // we are using async await so that a request is not blocked while waiting for the database to respond
        // {url}/api/users

        // AllowAnonymous attribute is used to allow unauthenticated users to access the endpoint and it overrides the authorize attribute.
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDetailDto>>> GetUsers()
        {
            // We need to return an ActionResult, so we can return certain status codes
            // We need to return an IEnumerable of AppUser, so we can return a list of users
            // We need to make this method asynchronous, so we can use await
            // We need to use await to get the users from the database
            return await _repository.GetUsersAsync();
        }

        // Now lets create an endpoint to get a single user from the database
        // {url}/api/users/id/1
        [HttpGet("id/{id}")]
        public async Task<ActionResult<UserDetailDto>> GetUser(int id)
        {
            // We need to return an ActionResult, so we can return certain status codes
            // We need to return an AppUser, so we can return a single user
            // We need to make this method asynchronous, so we can use await
            // We need to use await to get the user from the database
            return await _repository.GetUserByIdAsync(id);
        }

        [HttpGet("username/{username}")]
        public async Task<ActionResult<UserDetailDto>> GetUser(string username)
        {
            // We need to return an ActionResult, so we can return certain status codes
            // We need to return an AppUser, so we can return a single user
            // We need to make this method asynchronous, so we can use await
            // We need to use await to get the user from the database
            return await _repository.GetUserByUsernameAsync(username);
        }

        [HttpGet("fullDetails")]
        public async Task<ActionResult<List<FullUserDetailsDto>>> GetFullUsers()
        {
            return Ok(await _repository.GetFullUsersAsync());
        }

        [HttpGet("fullDetails/{id}")]
        public async Task<ActionResult<FullUserDetailsDto>>  GetFullUser(int id)
        {
            return Ok(await _repository.GetFullUserAsync(id));
        }

    }
}