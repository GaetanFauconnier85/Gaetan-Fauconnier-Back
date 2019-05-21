using ProjetAirAtlantique.Class;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAirAtlantique.ViewModel
{
    public class Maintenance
    {
        public int Id { get; set; }
        public Plane Plane { get; set; }
        public Incident Incident { get; set; }
        public DateTime start_date { get; set; }
        public DateTime planned_date { get; set; }
        public DateTime end_date { get; set; }
        public string Report { get; set; }
        public Employee Responsible { get; set; }
        public List<Employee> Employees { get; set; }
    }
}
