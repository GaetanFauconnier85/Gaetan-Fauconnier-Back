using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAirAtlantique.ViewModel
{
    public class JourneyModel
    {
        public static void DeleteJourney(int id)
        {
            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
            currentBDD.Open();

            string sqlselect = "DELETE FROM journey WHERE id = " + id + "";
            using (MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD))
            {
                cmd.ExecuteNonQuery();
            }
        }

        public static void DeleteJourneyFly(int id)
        {
            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
            currentBDD.Open();

            string sqlselect = "DELETE FROM journey_fly WHERE journey_id = " + id + "";
            using (MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
