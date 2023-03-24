using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB02b_A8_PROGII
{
    internal class Organisationseinheit
    {
        public int OeID { get; set; }
        public string Name { get; set; }
        public string Kuerzel { get; set; }

        public ICollection<Mitarbeiter> Mitarbeiter { get; set; }
    }
}
