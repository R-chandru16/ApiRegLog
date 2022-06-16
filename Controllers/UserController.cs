using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersApi.Models;
using UsersApi.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace UsersApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }
        // GET: api/<UserController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<UserDto>> Post([FromBody] UserDto userDto)
        {
            UserDto dto = _userService.Register(userDto);
            if (dto != null)
            {
                return dto;
            }
            return BadRequest("Couldnt Add");
        }

        // PUT api/<UserController>/5
        [HttpPost,Route("Login")]
        public async Task<ActionResult<UserDto>> Login([FromBody] UserDto userDto)
        {
            UserDto dto = _userService.Login(userDto);
            if (dto != null)
                return dto;
            return BadRequest("No Such User Present");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
