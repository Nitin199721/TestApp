using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TestAPI.Data;
using Microsoft.EntityFrameworkCore;
using TestAPI.Models;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace TestAPI.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }
        // GET: /<controller>/
        [HttpGet]
        public async Task<IActionResult> GetUser()
        {
            var user = await _context.Users.ToListAsync();
            return Ok(user);
        }

        // POST api/SaveUser
        [HttpPost]
        public IActionResult SaveUser([FromBody]Users user)
        {
            if (string.IsNullOrEmpty(user.Username) && string.IsNullOrEmpty(user.Email) && string.IsNullOrEmpty(user.Password))
            {
                return BadRequest("Invalid data");
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return Ok(user);
            }
           
        }

        
    }
}
