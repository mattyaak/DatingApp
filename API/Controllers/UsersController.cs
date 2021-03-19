using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
            _context = context;
        }

        //Adding endpoints: togetalltheusers / togetspecificuser

        [HttpGet]
        [AllowAnonymous]
        //return a type of actionresult we specify the type of thing
        //we are going to send back list of users
        //several collection for retruning list, now IEnumerable / could be also a List 
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            //creating a variable to store our users in
            return await _context.Users.ToListAsync();

        }

        // api/users/3
        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            //creating a variable to store our users in
            return await _context.Users.FindAsync(id);

        }


    }
}