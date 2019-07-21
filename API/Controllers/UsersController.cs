using System;
using API.Entities;
using API.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/users")]
    public class UsersController : ControllerBase
    {

        private IUsersRepository repository;

        public UsersController(IUsersRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet()]
        public IActionResult GetUsers(){
            return Ok(repository.GetUsers());
        }

        [HttpGet("{id}")]
        public IActionResult GetUser(Guid id){
            User user = repository.GetUser(id);
            
            if(user == null){
                return NotFound();
            }
            return Ok(user);
        }

    }
}
