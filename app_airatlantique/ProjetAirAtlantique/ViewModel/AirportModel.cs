using MySql.Data.MySqlClient;
using ProjetAirAtlantique.ViewModel;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetAirAtlantique.Model
{
    public class AirportModel
    {
        public static Airport GetAirport(int id)
        {
            try
            {
                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

                currentBDD.Open();
                string sqlselect = String.Concat("SELECT id, libelle FROM airport where id = ", id, ";");
                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Airport airport = new Airport() { Id = Convert.ToInt32(rdr[0]), Libelle = Convert.ToString(rdr[1])};

                return airport;
            }
            catch
            {
                return null;
            }
        }
    }
}
