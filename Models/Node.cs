using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// Directives using.
// Dyrektywy using.

namespace MultiscaleModelling.Models
{
    public class Node
    // Classes are declared with the Class keyword followed by a unique identifier.
    // Klasy są deklarowane za pomocą słowa kluczowego Class , po którym następuje unikatowy identyfikator.
    {
        public TypeEnum Type { get; set; }
        // Provides the base class for enumerations.
        // Dostarcza klasę bazową dla wyliczeń.
        public Color Color { get; set; }
        // Shows the ARGB Color(alpha, red, green, blue).
        // Przedstawia Kolor ARGB (alfa, czerwony, zielony, niebieski).
        public int X { get; set; }
        public int Y { get; set; }
        public int Id { get; set; }
        // A signed 32-bit integer.
        // Podpisana 32-bitowa całkowita.
        public double H { get; set; }
        // Represents a double-precision floating-point number.
        // Reprezentuje liczbę zmiennoprzecinkową o podwójnej precyzji.
    }
}
