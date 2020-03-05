using System.Collections.Generic;

namespace GpoSion.API.Models
{
    public class GraphDataWLabel
    {
        public IEnumerable<GraphData> Datos { get; set; }
        public IEnumerable<string> Leyendas { get; set; }
    }
}