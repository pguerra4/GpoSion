using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Dtos;
using GpoSion.API.Models;
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

        [HttpGet]
        public async Task<IActionResult> GetNumerosParte()
        {
            var numerosParte = await _repo.GetNumerosParte();
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

        [HttpPost()]
        public async Task<IActionResult> PostNumeroParte(NumeroParteToCreateDto numeroParteforCreationDto)
        {

            // var file = numeroParteforCreationDto.File;

            // if (file.Length > 0)
            // {
            //     var filePath = Path.Combine("Data/Photos/",
            //         Path.GetRandomFileName());

            //     numeroParteforCreationDto.UrlImagenPieza = filePath;
            //     using (var stream = System.IO.File.Create(filePath))
            //     {
            //         await file.CopyToAsync(stream);
            //     }
            // }



            var numeroParte = _mapper.Map<NumeroParte>(numeroParteforCreationDto);
            if (numeroParteforCreationDto.Materiales.Count > 0)
            {
                var materiales = new List<MaterialNumeroParte>();

                foreach (MaterialForPutDto material in numeroParteforCreationDto.Materiales)
                {
                    materiales.Add(new MaterialNumeroParte { MaterialId = material.MaterialId });
                }
                numeroParte.MaterialesNumeroParte = materiales;
            }

            if (numeroParteforCreationDto.Moldes.Count > 0)
            {
                var moldes = new List<MoldeNumeroParte>();
                foreach (MoldeForPutDto molde in numeroParteforCreationDto.Moldes)
                {
                    moldes.Add(new MoldeNumeroParte { MoldeId = molde.Id });
                }
                numeroParte.MoldesNumeroParte = moldes;
            }


            _repo.Add(numeroParte);



            if (await _repo.SaveAll())
            {
                var numeroParteToReturn = _mapper.Map<NumeroParteForDetailDto>(numeroParte);
                return CreatedAtAction("GetNumeroParte", new { id = numeroParte.NoParte }, numeroParteToReturn);
            }


            throw new Exception("Numero de parte no guardado");
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> PutNumeroParte(string id, NumeroParteToCreateDto numeroParteFP)
        {
            var numeroParte = await _repo.GetNumeroParte(id);
            if (numeroParte == null)
                return BadRequest();
            if (numeroParte.NoParte != numeroParteFP.NoParte)
                return BadRequest();


            numeroParte.ClienteId = numeroParteFP.ClienteId;
            // numeroParte.MaterialId = numeroParteFP.MaterialId;
            numeroParte.Peso = numeroParteFP.Peso;
            numeroParte.Costo = numeroParteFP.Costo;
            numeroParte.Descripcion = numeroParteFP.Descripcion;
            numeroParte.LeyendaPieza = numeroParteFP.LeyendaPieza;


            if (numeroParteFP.Materiales.Count > 0)
            {

                if (numeroParte.MaterialesNumeroParte != null)
                {
                    numeroParte.MaterialesNumeroParte.Clear();
                }
                var materiales = new List<MaterialNumeroParte>();

                foreach (MaterialForPutDto material in numeroParteFP.Materiales)
                {
                    materiales.Add(new MaterialNumeroParte { MaterialId = material.MaterialId });
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
                foreach (MoldeForPutDto molde in numeroParteFP.Moldes)
                {
                    moldes.Add(new MoldeNumeroParte { MoldeId = molde.Id });
                }
                numeroParte.MoldesNumeroParte = moldes;
            }


            await _repo.SaveAll();
            return NoContent();


        }


        [HttpPost("{id}/Photo")]
        public async Task<IActionResult> PostImagenNumeroParte(string id, [FromForm] ImagenNumeroParteDto imagen)
        {
            var numeroParte = await _repo.GetNumeroParte(id);
            if (numeroParte == null)
                return NotFound();

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



            await _repo.SaveAll();

            return NoContent();


        }

        [HttpGet("{id}/Photo")]
        public async Task<IActionResult> GetImagenNumeroParte(string id)
        {
            var numeroParte = await _repo.GetNumeroParte(id);
            if (numeroParte == null)
                return NotFound();

            var file = Path.Combine(Directory.GetCurrentDirectory(),
                            numeroParte.UrlImagenPieza);

            return PhysicalFile(file, "image/jpg");

        }

        [HttpGet("{id}/Existe")]
        public async Task<IActionResult> ExisteNumeroParte(string id)
        {

            return Ok(await _repo.ExisteNumeroParte(id));

        }



    }
}