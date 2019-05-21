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
    public class FlyModel
    {

        public static void AddFly (Fly fly)
        {
            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
            currentBDD.Open();

            string sqlselect = "INSERT INTO fly (hour_start, hour_end, plane_id, trip_used_id) VALUES (@hour_start, @hour_end, @plane_id, @trip_used_id);";
            using (MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD))
            {
                cmd.Parameters.AddWithValue("@hour_start", fly.hour_start);
                cmd.Parameters.AddWithValue("@hour_end", fly.hour_end);
                cmd.Parameters.AddWithValue("@plane_id", fly.plane.Id);
                cmd.Parameters.AddWithValue("@trip_used_id", fly.trip_used.Id);
                
                int result = cmd.ExecuteNonQuery();

            }
        }

        public static void DeleteFly(int id)
        {
            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
            currentBDD.Open();

            string sqlselect = "DELETE fly FROM fly  WHERE id = "+id+"";
            using (MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static List<int> selectJourneyId(int id)
        {
            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
            currentBDD.Open();

            List<int> journeysId = new List<int>();

            string sqlselect = "SELECT journey_id FROM journey_fly WHERE fly_id =" + id + "";

            MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                journeysId.Add(Convert.ToInt32(rdr[0]));
            }

            rdr.Close();

            return journeysId;
        }

        public static List<Fly> GetFlies()
        {
            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
            currentBDD.Open();

            List<Fly> flies = new List<Fly>();

            string sqlselect = "SELECT t.id, f.hour_start, f.hour_end, f.id FROM fly f join trip t on t.id=f.trip_used_id JOIN airport a on a.id = t.airport_start_id join airport b on b.id = t.airport_end_id";
            MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {

                while (rdr.Read())
                {
                    flies.Add(
                        new Fly()
                        {
                            trip_used = TripModel.GetTrip(Convert.ToInt32(rdr[0])),
                            hour_start = Convert.ToDateTime(rdr[1]),
                            hour_end = Convert.ToDateTime(rdr[2]),
                            Id = Convert.ToInt32(rdr[3])
                        });
                }

                return flies;

            }
        }

    }
}
