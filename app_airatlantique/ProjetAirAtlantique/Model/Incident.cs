using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAirAtlantique.Class
{
    public class Incident 
    {
        public int Id { get; set; }
        // public Employe employe {get; set;}
        public Plane Plane { get; set; }
        public string Libelle { get; set; }
        public string Report { get; set; }

    }
}
