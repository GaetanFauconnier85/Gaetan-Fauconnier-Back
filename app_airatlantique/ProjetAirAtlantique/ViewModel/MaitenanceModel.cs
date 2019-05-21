using MySql.Data.MySqlClient;
using ProjetAirAtlantique.Class;
using ProjetAirAtlantique.ViewModel;

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ProjetAirAtlantique.Model
{
    public class MaitenanceModel
    {
        public static void AddMaintenance(Maintenance maintenance)
        {

            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

            string sqlinsert = "INSERT INTO maintenance (incident_id, start_date, planned_date) VALUES (@incident_id, @dateDebut, @dateEstimee);";
            using (MySqlCommand cmd = new MySqlCommand(sqlinsert, currentBDD))
            {
                cmd.Parameters.AddWithValue("@incident_id", maintenance.Incident.Id);
                cmd.Parameters.AddWithValue("@dateDebut", maintenance.start_date);
                cmd.Parameters.AddWithValue("@dateEstimee", maintenance.planned_date);

                currentBDD.Open();
                int result = cmd.ExecuteNonQuery();
                currentBDD.Close();
            }

            string sqlinsert2 = "UPDATE `plane` SET `state_id`= (Select id from state where libelle = \"En maintenance\") WHERE id = @plane_id;";
            using (MySqlCommand cmd = new MySqlCommand(sqlinsert2, currentBDD))
            {
                cmd.Parameters.AddWithValue("@plane_id", maintenance.Plane.Id);
                currentBDD.Open();
                int result = cmd.ExecuteNonQuery();
                currentBDD.Clone();
            }

            int id;

            string sqlinsert3 = "SELECT id FROM maintenance WHERE end_date is NULL Order by id desc LIMIT 1";
            MySqlCommand cmd3 = new MySqlCommand(sqlinsert3, currentBDD);
            using (MySqlDataReader rdr = cmd3.ExecuteReader())
            {
                rdr.Read();
                id = Convert.ToInt32(rdr[0]);
            }

            foreach (Employee employee in maintenance.Employees)
            {
                string sqlinsert4 = "INSERT INTO maintenance_employee (employee_id, maintenance_id, responsible) VALUES (@idEmploye, @id, @responsable);";
                using (MySqlCommand cmd2 = new MySqlCommand(sqlinsert4, currentBDD))
                {
                    cmd2.Parameters.AddWithValue("@idEmploye", employee.Id);
                    cmd2.Parameters.AddWithValue("@id", id);
                    if(maintenance.Responsible.Id == employee.Id)
                    {
                        cmd2.Parameters.AddWithValue("@responsable", 1);
                    } else
                    {
                        cmd2.Parameters.AddWithValue("@responsable", 0);
                    }

                    int result = cmd2.ExecuteNonQuery();
                    currentBDD.Clone();
                }
            }
        }
        public static List<Maintenance> GetCurrentMaintenances()
        {

            List<Maintenance> maintenances = new List<Maintenance>();
            MySqlConnection currentBDD = new MySqlConnection(ConfigurationManager.ConnectionStrings["connexionString"].ConnectionString);

            currentBDD.Open();
            string sqlselect = "SELECT maintenance.id, incident_id, start_date, planned_date, plane_id FROM maintenance join incident on maintenance.incident_id = incident.id WHERE end_date is NULL Order by id asc";
            MySqlCommand cmd = new MySqlCommand(sqlselect, currentBDD);
            using (MySqlDataReader rdr = cmd.ExecuteReader())
            {
                    
                while (rdr.Read())
                {
                    maintenances.Add(
                        new Maintenance() {
                        Responsible = EmployeeModel.GetResponsible(Convert.ToInt32(rdr[0])),
                        Plane = PlaneModel.GetPlane(Convert.ToInt16(rdr[4])),
                        Incident = IncidentModel.GetIncident(Convert.ToInt16(rdr[1])),
                        start_date = Convert.ToDateTime(rdr[2]),
                        planned_date = Convert.ToDateTime(rdr[3])
                    });
                }

                return maintenances;
                    
            }
        }
    }
}
