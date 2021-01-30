using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Models
{
    public class ConfigurationRecrystallization
    {
        public int NumberOfStates { get; set; }
        public NucleonsType NucleonsType { get; set; }
        public bool OnlyGBGeneration { get; set; }
        public int Iterations { get; set; }
        public int TotalNucleons { get; set; }
        public double J { get; set; }

    }
}
