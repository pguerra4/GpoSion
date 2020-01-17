using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GpoSion.API.Controllers
{

    [Authorize(Policy = "RequireAdminRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {

        public readonly DataContext _context;
        public readonly UserManager<User> _userManager;

        public AdminController(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }


        [HttpGet("userswithroles")]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            var userList = await _userManager.Users.OrderBy(u => u.UserName).ToListAsync();

            var userWithRoles = new List<UserWithRoles>();

            foreach (var item in userList)
            {
                var roles = await _userManager.GetRolesAsync(item);
                var uwr = new UserWithRoles { Id = item.Id, Name = item.UserName, Roles = roles.ToList() };
                userWithRoles.Add(uwr);

            }

            return Ok(userWithRoles);
        }



    }

    public class UserWithRoles
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public List<string> Roles { get; set; }
    }
}