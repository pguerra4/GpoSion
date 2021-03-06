using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Helpers;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class NumerosParteController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public NumerosParteController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;

        }

        [AllowAnonymous]
        [HttpGet("{id}/Photo")]
        public async Task<IActionResult> GetImagenNumeroParte(string id)
        {
            var numeroParte = await _repo.GetNumeroParte(id);
            if (numeroParte == null)
                return NotFound();

            if (numeroParte.UrlImagenPieza == null)
                return NoContent();

            var file = Path.Combine(Directory.GetCurrentDirectory(),
                            numeroParte.UrlImagenPieza);

            return PhysicalFile(file, "image/jpg");

        }


        [HttpGet]
        public async Task<IActionResult> GetNumerosParte([FromQuery] NumeroParteParams npParams)
        {
            var numerosParte = await _repo.GetNumerosParte(npParams);
            var numerosParteToReturn = _mapper.Map<IEnumerable<NumeroParteToListDto>>(numerosParte);
            return Ok(numerosParteToReturn);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetNumeroParte(string id)
        {
            var numeroParte = await _repo.GetNumeroParte(id);
            var numeroParteToReturn = _mapper.Map<NumeroParteForDetailDto>(numeroParte);

            return Ok(numeroParteToReturn);
        }

        [Authorize(Policy = "VentasAlmacen")]
        [HttpPost()]
        public async Task<IActionResult> PostNumeroParte(NumeroParteToCreateDto numeroParteforCreationDto)
        {

            numeroParteforCreationDto.NoParte = numeroParteforCreationDto.NoParte.Trim();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var numeroParte = _mapper.Map<NumeroParte>(numeroParteforCreationDto);
            if (numeroParteforCreationDto.Materiales.Count > 0)
            {
                var materiales = new List<MaterialNumeroParte>();

                foreach (MaterialNumeroParteToListDto material in numeroParteforCreationDto.Materiales)
                {
                    materiales.Add(new MaterialNumeroParte { MaterialId = material.Material.MaterialId, Cantidad = material.Cantidad });
                }
                numeroParte.MaterialesNumeroParte = materiales;
            }

            if (numeroParteforCreationDto.Moldes.Count > 0)
            {
                var moldes = new List<MoldeNumeroParte>();
                foreach (MoldeNumeroParteToListDto molde in numeroParteforCreationDto.Moldes)
                {
                    moldes.Add(new MoldeNumeroParte { MoldeId = molde.Molde.Id, Cavidades = molde.Cavidades });
                }
                numeroParte.MoldesNumeroParte = moldes;
            }
            numeroParte.FechaCreacion = DateTime.Now;
            numeroParte.CreadoPorId = userId;

            _repo.Add(numeroParte);



            if (await _repo.SaveAll())
            {
                var numeroParteToReturn = _mapper.Map<NumeroParteForDetailDto>(numeroParte);
                return CreatedAtAction("GetNumeroParte", new { id = numeroParte.NoParte }, numeroParteToReturn);
            }


            throw new Exception("Numero de parte no guardado");
        }


        [Authorize(Policy = "VentasAlmacen")]
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumeroParte(string id, NumeroParteToCreateDto numeroParteFP)
        {
            var numeroParte = await _repo.GetNumeroParte(id);
            if (numeroParte == null)
                return BadRequest();
            if (numeroParte.NoParte != numeroParteFP.NoParte)
                return BadRequest();

            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            numeroParte.ClienteId = numeroParteFP.ClienteId;
            // numeroParte.MaterialId = numeroParteFP.MaterialId;
            numeroParte.Peso = numeroParteFP.Peso;
            numeroParte.Costo = numeroParteFP.Costo;
            numeroParte.Descripcion = numeroParteFP.Descripcion;
            numeroParte.LeyendaPieza = numeroParteFP.LeyendaPieza;
            numeroParte.UltimaModificacion = DateTime.Now;
            numeroParte.ModificadoPorId = userId;


            if (numeroParteFP.Materiales.Count > 0)
            {

                if (numeroParte.MaterialesNumeroParte != null)
                {
                    numeroParte.MaterialesNumeroParte.Clear();
                }
                var materiales = new List<MaterialNumeroParte>();

                foreach (MaterialNumeroParteToListDto material in numeroParteFP.Materiales)
                {
                    materiales.Add(new MaterialNumeroParte { MaterialId = material.Material.MaterialId, Cantidad = material.Cantidad });
                }
                numeroParte.MaterialesNumeroParte = materiales;
            }

            if (numeroParteFP.Moldes.Count > 0)
            {
                if (numeroParte.MoldesNumeroParte != null)
                {
                    numeroParte.MoldesNumeroParte.Clear();
                }
                var moldes = new List<MoldeNumeroParte>();
                foreach (MoldeNumeroParteToListDto molde in numeroParteFP.Moldes)
                {
                    moldes.Add(new MoldeNumeroParte { MoldeId = molde.Molde.Id, Cavidades = molde.Cavidades });
                }
                numeroParte.MoldesNumeroParte = moldes;
            }


            await _repo.SaveAll();
            return NoContent();


        }




        [Authorize(Policy = "VentasAlmacen")]
        [HttpPost("{id}/Photo")]
        public async Task<IActionResult> PostImagenNumeroParte(string id, [FromForm] ImagenNumeroParteDto imagen)
        {
            try
            {
                var numeroParte = await _repo.GetNumeroParte(id);
                if (numeroParte == null)
                    return NotFound();

                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var file = imagen.File;

                if (file.Length > 0)
                {
                    var filePath = Path.Combine("Data/Photos/",
                        id + ".jpg");

                    numeroParte.UrlImagenPieza = filePath;
                    using (var stream = System.IO.File.Create(filePath))
                    {
                        await file.CopyToAsync(stream);
                    }
                }

                numeroParte.ModificadoPorId = userId;
                numeroParte.UltimaModificacion = DateTime.Now;

                await _repo.SaveAll();

                return NoContent();
            }
            catch (System.Exception e)
            {

                return Ok(e.GetBaseException().Message);
            }



        }



        [HttpGet("{id}/Existe")]
        public async Task<IActionResult> ExisteNumeroParte(string id)
        {

            return Ok(await _repo.ExisteNumeroParte(id));

        }


        [HttpGet("{id}/ExistenciaAlmacen")]
        public async Task<IActionResult> ExistenciaAlmacenNumeroParte(string id, bool certificadas = true)
        {

            var numeroParte = await _repo.GetNumeroParte(id);
            if (numeroParte == null)
                return Ok(0);


            var existencias = numeroParte.ExistenciasProducto.FirstOrDefault();
            if (existencias != null)
            {
                if (certificadas)
                {
                    return Ok(existencias.PiezasCertificadas);
                }
                else
                {
                    return Ok(existencias.PiezasRechazadas);
                }
            }
            else
            {
                return Ok(0);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNumeroParte(string id)
        {



            var npFromRepo = await _repo.GetNumeroParte(id);

            if (npFromRepo == null)
                return NotFound();

            foreach (var item in npFromRepo.MaterialesNumeroParte)
            {
                _repo.Delete(item);
            }


            foreach (var item in npFromRepo.MoldesNumeroParte)
            {
                _repo.Delete(item);
            }

            _repo.Delete(npFromRepo);



            if (await _repo.SaveAll())
                return NoContent();

            return BadRequest("Fallo el borrado del número de parte " + npFromRepo.NoParte + " probablemente ya tenga movimientos.");
        }
    }


}