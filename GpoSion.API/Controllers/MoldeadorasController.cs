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
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{

    [Authorize(Policy = "ProduccionRole")]
    [Route("api/[controller]")]
    [ApiController]
    public class MoldeadorasController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public MoldeadorasController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [HttpGet]
        public async Task<IActionResult> GetMoldeadoras()
        {
            var moldeadoras = await _repo.GetMoldeadoras();
            var moldeadorasToReturn = _mapper.Map<IEnumerable<MoldeadoraToListDto>>(moldeadoras);
            return Ok(moldeadorasToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMoldeadora(int id)
        {
            var moldeadora = await _repo.GetMoldeadora(id);
            var moldeadoraToReturn = _mapper.Map<MoldeadoraToListDto>(moldeadora);

            return Ok(moldeadoraToReturn);
        }

        [HttpPost()]
        public async Task<IActionResult> PostMoldeadora(MoldeadoraToCreateDto moldeadoraToCreateDto)
        {
            if (await _repo.ExisteMoldeadora(moldeadoraToCreateDto.Clave))
                return BadRequest("Moldeadora ya existe");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            moldeadoraToCreateDto.Clave = moldeadoraToCreateDto.Clave.Trim();

            var moldeadora = _mapper.Map<Moldeadora>(moldeadoraToCreateDto);
            moldeadora.Estatus = "Detenida";
            moldeadora.CreadoPorId = userId;
            moldeadora.FechaCreacion = DateTime.Now;

            _repo.Add(moldeadora);

            if (await _repo.SaveAll())
                return CreatedAtAction("GetMoldeadora", new { id = moldeadora.MoldeadoraId }, moldeadora);

            throw new Exception("Moldeadora no guardada");
        }


        [HttpPut("edit/{id}")]
        public async Task<IActionResult> EditMoldeadora(int id, MoldeadoraToEditDto moldeadoraFP)
        {
            var moldeadora = await _repo.GetMoldeadora(id);
            if (moldeadora == null)
                return NotFound();
            if (moldeadora.MoldeadoraId != moldeadoraFP.MoldeadoraId)
                return BadRequest("Ids no coinciden");

            if (moldeadora.Clave.Trim().ToLower() != moldeadoraFP.Clave.Trim().ToLower())
                if (await _repo.ExisteMoldeadora(moldeadoraFP.Clave))
                    return BadRequest("Moldeadora ya existe");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            moldeadora.Clave = moldeadoraFP.Clave.Trim();
            moldeadora.DisparosPorHora = moldeadoraFP.DisparosPorHora;
            moldeadora.UltimaModificacion = DateTime.Now;
            moldeadora.ModificadoPorId = userId;




            await _repo.SaveAll();
            return NoContent();

        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutMoldeadora(int id, MoldeadoraForPutDto moldeadoraFP)
        {
            var moldeadora = await _repo.GetMoldeadora(id);
            if (moldeadora == null)
                return NotFound();
            if (moldeadora.MoldeadoraId != moldeadoraFP.MoldeadoraId)
                return BadRequest("Ids no coinciden");

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            foreach (var item in moldeadoraFP.NumerosParte)
            {
                if (!await _repo.ExisteOrdenCompraActiva(item))
                {
                    return BadRequest("El No. Parte " + item + " no tiene ordenes de compra activa");
                }
            }

            moldeadora.MoldeId = moldeadoraFP.MoldeId;
            moldeadora.MaterialId = moldeadoraFP.MaterialId;
            moldeadora.Estatus = moldeadoraFP.Estatus;
            moldeadora.UltimaModificacion = DateTime.Now;
            moldeadora.ModificadoPorId = userId;

            moldeadora.MoldeadoraNumerosParte.Clear();


            foreach (var item in moldeadoraFP.NumerosParte)
            {
                moldeadora.MoldeadoraNumerosParte.Add(new MoldeadoraNumeroParte { NoParte = item, MoldeadoraId = moldeadora.MoldeadoraId });
            }



            var movimiento = new MovimientoMoldeadora
            {
                MoldeadoraId = moldeadora.MoldeadoraId,
                Movimiento = "Setup",
                Observaciones = "",
                Fecha = DateTime.Now,
                Estatus = moldeadora.Estatus,
                MoldeId = moldeadora.MoldeId,
                MaterialId = moldeadora.MaterialId,
                MotivoTiempoMuertoId = null,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId
            };
            if (moldeadora.MoldeadoraNumerosParte != null && moldeadora.MoldeadoraNumerosParte.Count > 0)
            {
                movimiento.MovimientoMoldeadoraNumerosParte = new List<MovimientoMoldeadoraNumeroParte>();
                foreach (var MoldNp in moldeadora.MoldeadoraNumerosParte)
                {
                    movimiento.MovimientoMoldeadoraNumerosParte.Add(new MovimientoMoldeadoraNumeroParte { NoParte = MoldNp.NoParte });
                }
            }


            _repo.Add(movimiento);


            await _repo.SaveAll();
            return NoContent();

        }

        [HttpPost("{id}")]
        public async Task<IActionResult> ArrancarMoldeadora(int id)
        {


            var moldeadora = await _repo.GetMoldeadora(id);
            if (moldeadora == null)
                return NotFound();

            foreach (var item in moldeadora.MoldeadoraNumerosParte)
            {
                if (!await _repo.ExisteOrdenCompraActiva(item.NoParte))
                {
                    return BadRequest("El No. Parte " + item.NoParte + " no tiene ordenes de compra activa");
                }
            }
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            moldeadora.Estatus = "Operando";
            moldeadora.UltimaModificacion = DateTime.Now;
            moldeadora.ModificadoPorId = userId;
            moldeadora.UltimoMotivoParo = null;



            var movimiento = new MovimientoMoldeadora
            {
                MoldeadoraId = moldeadora.MoldeadoraId,
                Movimiento = "Arranque",
                Observaciones = "",
                Fecha = DateTime.Now,
                Estatus = "Operando",
                MoldeId = moldeadora.MoldeId,
                MaterialId = moldeadora.MaterialId,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId,
                MotivoTiempoMuertoId = null
            };
            if (moldeadora.MoldeadoraNumerosParte != null && moldeadora.MoldeadoraNumerosParte.Count > 0)
            {
                movimiento.MovimientoMoldeadoraNumerosParte = new List<MovimientoMoldeadoraNumeroParte>();
                foreach (var MoldNp in moldeadora.MoldeadoraNumerosParte)
                {
                    movimiento.MovimientoMoldeadoraNumerosParte.Add(new MovimientoMoldeadoraNumeroParte { NoParte = MoldNp.NoParte });
                }
            }


            _repo.Add(movimiento);

            await _repo.SaveAll();
            return NoContent();
        }

        [HttpPost("{id}/stop")]
        public async Task<IActionResult> DetenerMoldeadora(int id, MoldeadoraForStopDto moldeadoraForStop)
        {
            if (id != moldeadoraForStop.MoldeadoraId)
                return BadRequest("Los Ids no coinciden");

            var moldeadora = await _repo.GetMoldeadora(id);
            if (moldeadora == null)
                return NotFound();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            moldeadora.Estatus = "Detenida";
            moldeadora.UltimaModificacion = DateTime.Now;
            moldeadora.ModificadoPorId = userId;
            moldeadora.UltimoMotivoParo = moldeadoraForStop.MotivoTiempoMuertoId;

            var movimiento = new MovimientoMoldeadora
            {
                MoldeadoraId = moldeadora.MoldeadoraId,
                Movimiento = moldeadoraForStop.Movimiento,
                Observaciones = moldeadoraForStop.Observaciones,
                Fecha = DateTime.Now,
                Estatus = "Detenida",
                MoldeId = moldeadora.MoldeId,
                MaterialId = moldeadora.MaterialId,
                MotivoTiempoMuertoId = moldeadoraForStop.MotivoTiempoMuertoId,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId
            };
            if (moldeadora.MoldeadoraNumerosParte != null && moldeadora.MoldeadoraNumerosParte.Count > 0)
            {
                movimiento.MovimientoMoldeadoraNumerosParte = new List<MovimientoMoldeadoraNumeroParte>();
                foreach (var MoldNp in moldeadora.MoldeadoraNumerosParte)
                {
                    movimiento.MovimientoMoldeadoraNumerosParte.Add(new MovimientoMoldeadoraNumeroParte { NoParte = MoldNp.NoParte });
                }
            }


            _repo.Add(movimiento);
            await _repo.SaveAll();
            return NoContent();
        }


        [HttpPost("{id}/reset")]
        public async Task<IActionResult> ResetMoldeadora(int id)
        {


            var moldeadora = await _repo.GetMoldeadora(id);
            if (moldeadora == null)
                return NotFound();
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);


            moldeadora.Estatus = "Detenida";
            moldeadora.UltimaModificacion = DateTime.Now;
            moldeadora.ModificadoPorId = userId;
            moldeadora.UltimoMotivoParo = null;

            moldeadora.MoldeadoraNumerosParte.Clear();
            moldeadora.MoldeId = null;
            moldeadora.Molde = null;
            moldeadora.MaterialId = null;
            moldeadora.Material = null;


            var movimiento = new MovimientoMoldeadora
            {
                MoldeadoraId = moldeadora.MoldeadoraId,
                Movimiento = "Reset",
                Observaciones = "",
                Fecha = DateTime.Now,
                Estatus = "Detenida",
                MotivoTiempoMuertoId = null,
                FechaCreacion = DateTime.Now,
                CreadoPorId = userId
            };


            _repo.Add(movimiento);

            await _repo.SaveAll();
            return NoContent();
        }

    }
}