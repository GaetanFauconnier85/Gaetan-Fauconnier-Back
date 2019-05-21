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
    public class StateModel
    {
        public static List<State> GetStates()
        {

            try
            {

                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

                List<State> states = new List<State>();
            
                currentBDD.Open();
                string sqlselect = "SELECT id, libelle FROM state Order by id asc";
                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    states.Add(new State() { Id = Convert.ToInt16(rdr[0]), Libelle = Convert.ToString(rdr[1])});
                }

                return states;
            }
            catch
            {
                return null;
            }
        }

        public static State GetState(string libEtat)
        {

            try
            {

                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

                currentBDD.Open();
                string sqlselect = String.Concat("SELECT id, libelle FROM state where libelle =", libEtat, ";");
                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();
                State state = new State(){ Id = Convert.ToInt16(rdr[0]), Libelle = Convert.ToString(rdr[1]) };

                return state;
            }
            catch
            {
                return null;
            }
        }
    }
}
