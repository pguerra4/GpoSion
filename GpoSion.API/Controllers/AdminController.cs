using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        public readonly RoleManager<Role> _roleManager;

        private readonly IMapper _mapper;

        public AdminController(DataContext context, UserManager<User> userManager, RoleManager<Role> roleManager, IMapper mapper)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
            _mapper = mapper;
        }


        [HttpGet("userswithroles")]
        public async Task<IActionResult> GetUsersWithRoles()
        {
            var userList = await _userManager.Users.OrderBy(u => u.UserName).ToListAsync();

            var userWithRoles = new List<UserWithRoles>();

            foreach (var item in userList)
            {
                var roles = await _userManager.GetRolesAsync(item);
                var uwr = new UserWithRoles { Id = item.Id, UserName = item.UserName, Nombre = item.Nombre, Paterno = item.Paterno, Materno = item.Materno, Roles = roles.ToList() };
                userWithRoles.Add(uwr);

            }

            return Ok(userWithRoles);
        }

        [HttpGet("userwithroles/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound("Usuario no encontrado");

            var roles = await _userManager.GetRolesAsync(user);
            var uwr = new UserWithRoles { Id = user.Id, UserName = user.UserName, Nombre = user.Nombre, Paterno = user.Paterno, Materno = user.Materno, Roles = roles.ToList() };


            return Ok(uwr);
        }

        [HttpGet("roles")]
        public async Task<IActionResult> GetRoles()
        {
            var rolesList = await _roleManager.Roles.OrderBy(u => u.Name).ToListAsync();

            var rolesToList = rolesList.Select(r => r.Name);

            return Ok(rolesToList);
        }

        [HttpPut("users/{id}")]
        public async Task<IActionResult> PutUser(string id, UserToEditDto userToEdit)
        {
            var userFromRepo = await _context.Users.FindAsync(id);
            if (userFromRepo == null)
                return NotFound("Usuario no encontrado");

            if (userFromRepo.Id != userToEdit.Id)
                return BadRequest("Ids no coinciden");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            _mapper.Map(userToEdit, userFromRepo);

            userFromRepo.ModificadoPorId = userId;
            userFromRepo.UltimaModificacion = DateTime.Now;

            var rolesAusentes = await _roleManager.Roles.Where(r => !userToEdit.Roles.Contains(r.Name)).ToListAsync();



            foreach (var rol in userToEdit.Roles)
            {
                await _userManager.AddToRoleAsync(userFromRepo, rol);
            }

            foreach (var rol in rolesAusentes)
            {
                await _userManager.RemoveFromRoleAsync(userFromRepo, rol.Name);
            }




            await _context.SaveChangesAsync();


            return NoContent();


        }

        [HttpPost("users")]
        public async Task<IActionResult> PostUser(UserForRegisterDto userToRegister)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var userToCreate = _mapper.Map<User>(userToRegister);
            userToCreate.CreadoPorId = userId;
            userToCreate.FechaCreacion = DateTime.Now;

            var result = await _userManager.CreateAsync(userToCreate, userToRegister.Password);

            if (result.Succeeded)
            {
                foreach (var rol in userToRegister.Roles)
                {
                    await _userManager.AddToRoleAsync(userToCreate, rol);
                }
                var userToReturn = _mapper.Map<UserForListDto>(userToCreate);


                return CreatedAtAction("GetUser", new { controller = "Admin", id = userToCreate.Id }, userToReturn);

            }
            return BadRequest(result.Errors);




        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id == userId)
                return BadRequest("No esta permitido borrar al usuario actual");

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
            if (user == null)
                return NotFound("Usuario no encontrado");

            if (user.UserName == "Admin")
                return BadRequest("No puedes borrar al usuario administrador");

            var results = await _userManager.DeleteAsync(user);

            if (results.Succeeded)
                return NoContent();

            return BadRequest(results.Errors);

        }


    }

    public class UserWithRoles
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public string Nombre { get; set; }

        public string Paterno { get; set; }

        public string Materno { get; set; }

        public List<string> Roles { get; set; }
    }
}