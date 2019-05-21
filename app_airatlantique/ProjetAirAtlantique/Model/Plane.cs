using ProjetAirAtlantique.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAirAtlantique.Class
{
    public class Plane
    {
        public int Id { get; set; }
        public string Libelle { get; set; }
        public int economic { get; set; }
        public int premium { get; set; }
        public int buisness { get; set; }
        public State State { get; set; }

    }
}
