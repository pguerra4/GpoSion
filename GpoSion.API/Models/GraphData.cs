using System.Collections.Generic;

namespace GpoSion.API.Models
{
    public class GraphData
    {
        public IEnumerable<int> Data { get; set; }
        public string Label { get; set; }
    }
}