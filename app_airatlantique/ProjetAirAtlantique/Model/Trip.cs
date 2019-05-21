using ProjetAirAtlantique.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAirAtlantique.Class
{
    public class Trip
    {
        public int Id { get; set; }
        public Airport StartAirport { get; set; }
        public Airport EndAirport { get; set; }
    }
}
