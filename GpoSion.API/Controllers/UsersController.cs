using System;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;

        public UsersController(UserManager<User> userManager, IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
            _userManager = userManager;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _repo.GetUser(id);
            if (user == null)
                return NotFound("Usuario no encontrado");

            var userToReturn = _mapper.Map<UserForListDto>(user);

            return Ok(userToReturn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(string id, UserToEditDto userToEdit)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id != userId)
                return Unauthorized();

            var user = await _repo.GetUser(id);
            if (user == null)
                return NotFound("Usuario no encontrado");

            if (user.Id != userToEdit.Id)
                return BadRequest("Ids no coinciden");

            userToEdit.eMail = userToEdit.eMail.Trim();
            userToEdit.Nombre = userToEdit.Nombre.Trim();
            userToEdit.Paterno = userToEdit.Paterno.Trim();
            userToEdit.Materno = userToEdit.Materno.Trim();


            _mapper.Map(userToEdit, user);

            user.ModificadoPorId = userId;
            user.UltimaModificacion = DateTime.Now;

            await _repo.SaveAll();

            return NoContent();
        }

        [HttpPut("changepassword/{id}")]
        public async Task<IActionResult> ChangePassword(string id, UserForPasswordChangeDto userToEdit)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (id != userId)
                return Unauthorized();

            var user = await _userManager.GetUserAsync(this.User);
            if (user == null)
                return BadRequest("Usuario no válido");

            user.UltimaModificacion = DateTime.Now;
            user.ModificadoPorId = userId;

            var result = await _userManager.ChangePasswordAsync(user, userToEdit.OldPassword, userToEdit.NewPassword);

            if (result.Succeeded)
                return NoContent();

            return BadRequest(result.Errors);
        }


    }
}