using ProjetAirAtlantique.Class;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace ProjetAirAtlantique.Model
{
    public class TripModel
    {
        public static List<Trip> GetTrips()
        {

            try
            {
                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

                List<Trip> trajets = new List<Trip>();

                currentBDD.Open();

                string sqlselect = "SELECT airport_start_id, airport_end_id, id from trip";

                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    trajets.Add(new Trip() { StartAirport = AirportModel.GetAirport(Convert.ToInt32(rdr[0])), EndAirport = AirportModel.GetAirport(Convert.ToInt32(rdr[1])), Id = Convert.ToInt32(rdr[2]) });
                }
                
                rdr.Close();

                return trajets;
            }
            catch
            {
                return null;
            }
        }

        public static Trip GetTrip(int id)
        {

            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

            currentBDD.Open();

            string sqlselect = "SELECT airport_start_id, airport_end_id, id from trip where id = " + id + ";";

            MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
            MySqlDataReader rdr = cmd.ExecuteReader();
            Trip trip = new Trip();
            while (rdr.Read()) {
                trip = new Trip() { StartAirport = AirportModel.GetAirport(Convert.ToInt32(rdr[0])), EndAirport = AirportModel.GetAirport(Convert.ToInt32(rdr[1])), Id = Convert.ToInt32(rdr[2]) };
            }

            rdr.Close();

            return trip;
        }
    }
}
