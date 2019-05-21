using MySql.Data.MySqlClient;
using ProjetAirAtlantique.Class;
using ProjetAirAtlantique.ViewModel;

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetAirAtlantique.Model
{
    public class PlaneModel
    {

        public static List<Plane> GetStopedPlanes()
        {
            try
            {
                List<Plane> planes = new List<Plane>();

                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

                currentBDD.Open();
                string sqlselect = String.Concat("SELECT id, libelle FROM plane where state_id IN ( select id from state where libelle = \"En arret\" OR libelle = \"En maintenance\"); ");
                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    planes.Add(new Plane() { Id = Convert.ToInt16(rdr[0]), Libelle = Convert.ToString(rdr[1]) });
                }

                return planes;
            }
            catch
            {
                return null;
            }
        }

        public static Plane GetPlane(int plane_id)
        {

            try
            {

                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

                currentBDD.Open();
                string sqlselect = String.Concat("SELECT id, libelle, economic,buisness,premium FROM plane where id=", plane_id, ";");
                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Plane plane = new Plane() { Id = Convert.ToInt16(rdr[0]), Libelle = Convert.ToString(rdr[1]), economic = Convert.ToInt16(rdr[2]), buisness = Convert.ToInt16(rdr[3]), premium = Convert.ToInt16(rdr[4]) };

                return plane;
            }
            catch
            {
                return null;
            }
        }

        public static List<Plane> GetFreePlanes(string start_date, string end_date)
        {

            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

            List<Plane> planes = new List<Plane>();

            currentBDD.Open();

            string sqlselect = " Select libelle, id , economic,buisness,premium from plane where not EXISTS( " +
                                " Select * from plane " +
                                " join fly on plane.id = fly.plane_id " +
                                " where hour_start BETWEEN \"" + start_date + "\" AND \"" + end_date + "\" AND hour_end BETWEEN \"" + start_date + "\" AND \"" + end_date + "\");";
            MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
            MySqlDataReader rdr = cmd.ExecuteReader();
            
            while (rdr.Read())
            {
                planes.Add(new Plane() { Id = Convert.ToInt16(rdr[1]), Libelle = Convert.ToString(rdr[0]), economic = Convert.ToInt16(rdr[2]), buisness = Convert.ToInt16(rdr[3]), premium = Convert.ToInt16(rdr[4]) });
            }

            rdr.Close();

            return planes;
            
        }
    }
}