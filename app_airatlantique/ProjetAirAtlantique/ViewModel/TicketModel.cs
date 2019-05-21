using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetAirAtlantique.ViewModel
{
    public class TicketModel
    {
        public static void DeleteTicket(int id)
        {
            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

            currentBDD.Open();
            string sqlselect = "DELETE ticket FROM ticket WHERE journey_id = " + id + "";
            using (MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD))
            {
                cmd.ExecuteNonQuery();
            }
        }
    }
}
