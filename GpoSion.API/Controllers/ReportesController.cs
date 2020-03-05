using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using GpoSion.API.Data;
using GpoSion.API.Helpers;
using GpoSion.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GpoSion.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IGpoSionRepository _repo;
        private readonly IMapper _mapper;
        public ReportesController(IGpoSionRepository repo, IMapper mapper)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet("embarquesporfecha")]
        public async Task<IActionResult> GetReporteEmbarquesPorFecha([FromQuery] ReporteParams reporteParams)
        {
            var embarques = await _repo.GetDetalleEmbarques(reporteParams);

            var fechas = embarques.Select(e => e.Embarque.Fecha.Date.ToShortDateString()).Distinct().OrderBy(e => e);

            var datos = new List<GraphData>();

            GraphData data;

            var numerosParte = embarques.Select(e => e.NoParte).Distinct();
            foreach (string noParte in numerosParte)
            {

                var valores = new List<int>();
                foreach (var fecha in fechas)
                {
                    valores.Add(embarques.Where(e => e.NoParte == noParte && e.Embarque.Fecha.Date.ToShortDateString() == fecha).Sum(e => e.Entregadas));
                }
                data = new GraphData { Label = noParte, Data = valores };
                datos.Add(data);
            }

            var resultado = new GraphDataWLabel { Datos = datos, Leyendas = fechas };



            // var reporteEmbarques = embarques.GroupBy(e => new
            // {
            //     Fecha = e.Embarque.Fecha.Date,
            //     NoParte = e.NoParte
            // })
            // .Select(e => new
            // {
            //     e.Key.Fecha,
            //     e.Key.NoParte,
            //     Piezas = e.Sum(k => k.Entregadas)
            // }).OrderBy(g => g.Fecha).ThenBy(g => g.NoParte);

            return Ok(resultado);
        }

        [HttpGet("embarquesnumeroparte")]
        public async Task<IActionResult> GetReporteEmbarquesNumeroParte([FromQuery] ReporteParams reporteParams)
        {
            var embarques = await _repo.GetDetalleEmbarques(reporteParams);



            var datos = new List<GraphData>();

            GraphData data;

            var numerosParte = embarques.Select(e => e.NoParte).Distinct().OrderBy(e => e);
            var valores = embarques.GroupBy(e => e.NoParte).OrderBy(e => e.Key).Select(e => new { Piezas = e.Sum(x => x.Entregadas) }).Select(y => y.Piezas);


            data = new GraphData { Data = valores };
            datos.Add(data);


            var resultado = new GraphDataWLabel { Datos = datos, Leyendas = numerosParte };

            return Ok(resultado);
        }


        [HttpGet("embarques")]
        public async Task<IActionResult> GetReporteEmbarques([FromQuery] ReporteParams reporteParams)
        {
            var embarques = await _repo.GetDetalleEmbarques(reporteParams);



            var embarquesCount = embarques.Select(de => de.EmbarqueId).Distinct().Count();



            var numerosParteCount = embarques.Select(e => e.NoParte).Distinct().Count();

            var piezasentregadas = embarques.Sum(de => de.Entregadas);





            var resultado = new { embarques = embarquesCount, numerosParte = numerosParteCount, piezasentregadas = piezasentregadas };

            return Ok(resultado);
        }


        [HttpGet("embarquesTop10")]
        public async Task<IActionResult> GetReporteEmbarquesTop10([FromQuery] ReporteParams reporteParams)
        {
            var embarques = await _repo.GetDetalleEmbarques(reporteParams);


            var top10 = embarques.GroupBy(de => de.NoParte).Select(de => new
            {
                noParte = de.Key,
                piezasentregadas = de.Sum(d => d.Entregadas)
            }).OrderByDescending(g => g.piezasentregadas).Take(10);


            return Ok(top10);
        }
    }
}