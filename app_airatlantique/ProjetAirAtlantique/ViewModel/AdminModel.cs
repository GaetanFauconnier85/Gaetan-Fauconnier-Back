using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetAirAtlantique.Model
{
    public class AdminModel
    {
        public bool CheckUser(string email, string password)
        {
            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

            currentBDD.Open();

            string sqlrequest = String.Concat("SELECT password FROM admin where login='", email, "';");
            MySqlCommand cmd = new MySqlCommand(sqlrequest, currentBDD);
            MySqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    if (SHA.GenerateSHA512String(password) == Convert.ToString(rdr[0]))
                    {
                        return true;
                    }
                }

            }
            return false;
        }

    }
}
