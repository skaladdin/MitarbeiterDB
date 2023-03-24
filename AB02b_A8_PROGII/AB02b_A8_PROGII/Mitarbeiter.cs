using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AB02b_A8_PROGII
{
    internal class Mitarbeiter
    {
        public int MitarbeiterID { get; set; }
        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Adresse { get; set; }
        public int OeID { get; set; }
        public Organisationseinheit Organisationseinheit { get; set; }

    }
}
