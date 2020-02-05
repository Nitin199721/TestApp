using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Models;
using TestAPI.Data;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserProfileController : Controller
    {
        private readonly DataContext _context;
        public UserProfileController(DataContext context)
        {
            _context = context;
        }
        // GET: api/values
        [HttpGet]
        public IActionResult  login([FromQuery] Users user)
        {
            var data = _context.Users.Where(s=> (s.Email == user.Username || s.Username == user.Username) && s.Password == user.Password ).Select(
                s=> new Users()
                {
                    ID = s.ID,
                    Username = s.Username,
                    Email = s.Email,
                    Password = s.Password

                }).FirstOrDefault();
            if (data == null)
            {
                return Ok(StatusCode(401));
            }
            return Ok(data);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/SaveUserProfile
        [HttpPost]
        public IActionResult SaveUserProfile([FromBody]UserProfile user)
        {
            if (string.IsNullOrEmpty(user.ID.ToString()) && string.IsNullOrEmpty(user.PhoneNumber))
            {
                return BadRequest("Invalid data");
            }
            else
            {
                _context.UserProfile.Add(user);
                _context.SaveChanges();

            }
            return Ok();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
