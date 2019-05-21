using ProjetAirAtlantique.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAirAtlantique.ViewModel
{
    public class Fly
    {
        public int Id { get; set; }
        public DateTime hour_start { get; set; }
        public DateTime hour_end { get; set; }
        public Trip trip_used { get; set; }
        public Plane plane { get; set; }

    }
}
