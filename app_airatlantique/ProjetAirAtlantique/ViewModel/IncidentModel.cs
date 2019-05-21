using MySql.Data.MySqlClient;
using ProjetAirAtlantique.Class;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetAirAtlantique.Model
{
    public class IncidentModel
    {
        public static Incident GetIncident(int id)
        {
            try
            {

                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
                currentBDD.Open();

                string sqlselect = String.Concat("SELECT id, libelle FROM incident WHERE id = " + id + "; ");
                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Incident incident = new Incident() { Id = Convert.ToInt16(rdr[0]), Libelle = Convert.ToString(rdr[1]) };

                return incident;
            }
            catch
            {
                return null;
            }
        }

        public static List<Incident> GetIncidents(int idAvion)
        {
            List<Incident> listIncident = new List<Incident>();

            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
            currentBDD.Open();

            string sqlselect = String.Concat("SELECT id, libelle FROM incident where id NOT IN (Select incident_id from maintenance) and plane_id = ", idAvion, ";");
            MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
            MySqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                listIncident.Add(new Incident() { Id = Convert.ToInt16(rdr[0]), Libelle = Convert.ToString(rdr[1]) });

            }

            return listIncident;
        }
    }
}
