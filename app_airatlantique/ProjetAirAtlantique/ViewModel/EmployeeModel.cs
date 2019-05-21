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
    public class EmployeeModel
    {
        public static List<Employee> GetEmployees()
        {
            try
            {
                List<Employee> employes = new List<Employee>();

                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
                currentBDD.Open();
                string sqlselect = String.Concat("SELECT id, surname, name FROM employee;");
                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    employes.Add(new Employee { Id = Convert.ToInt32(rdr[0]), Surname = Convert.ToString(rdr[1]), Name = Convert.ToString(rdr[2]) });
                }
                return employes;
            }
            catch
            {
                return null;
            }
        }
        public static Employee GetResponsible(int id)
        {

            try
            {

                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

                currentBDD.Open();
                string sqlselect = String.Concat("SELECT employee_id FROM maintenance_employee where maintenance_id =", id, " and responsible = 1;");
                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Employee employe = EmployeeModel.GetEmployee(Convert.ToInt32(rdr[0]));

                return employe;
            }
            catch
            {
                return null;
            }
        }
        public static Employee GetEmployee(int idEmploye)
        {

            try
            {

                MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);
                currentBDD.Open();

                string sqlselect = String.Concat("SELECT id, name, surname FROM employee where id =", idEmploye, ";");
                MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
                MySqlDataReader rdr = cmd.ExecuteReader();
                rdr.Read();
                Employee employe = new Employee() { Id = Convert.ToInt32(rdr[0]), Name = Convert.ToString(rdr[1]), Surname = Convert.ToString(rdr[2]) };

                return employe;
            }
            catch
            {
                return null;
            }
        }
    }
}
