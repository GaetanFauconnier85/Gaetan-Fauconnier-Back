
using MaterialDesignThemes.Wpf;
using ProjetAirAtlantique.Class;
using ProjetAirAtlantique.Model;
using ProjetAirAtlantique.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjetAirAtlantique.Xaml
{
    public partial class AddMaintenance : Page
    {
        public AddMaintenance()
        {
            InitializeComponent();
            this.Loaded += HomePage_Loaded;
            datedebut.DisplayDateStart = DateTime.Now;
            datedebut.DisplayDate = DateTime.Now;
            dateprevu.DisplayDateStart = DateTime.Now;
            dateprevu.DisplayDate = DateTime.Now;
        }

        private void HomePage_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                // Binding  
                this.avionList.DisplayMemberPath = "Libelle";
                this.avionList.SelectedValuePath = "Id";
                this.avionList.ItemsSource = PlaneModel.GetStopedPlanes();

                this.incidentList.DisplayMemberPath = "Libelle";
                this.incidentList.SelectedValuePath = "Id";

                this.responsableList.DisplayMemberPath = "Name";
                this.responsableList.SelectedValuePath = "Id";

                List<Employee> employees = EmployeeModel.GetEmployees();

                foreach(Employee employee in employees)
                {
                    CheckBox c = new CheckBox();
                    c.FontSize = 18;
                    c.Content = employee.Name;
                    c.CommandParameter = employee.Id;
                    c.Click += new RoutedEventHandler(CheckBoxValidated);
                    this.StackEmploye.Children.Add(c);
                }
            }
            catch
            {
            }
        }

        private void CheckBoxValidated(object sender, EventArgs e)
        {
            List<Employee> CurrEmploye = new List<Employee>();
            foreach(CheckBox check in this.StackEmploye.Children)
            {
                if(check.IsChecked == true)
                {
                    int temp = Convert.ToInt32(check.CommandParameter);
                    CurrEmploye.Add(EmployeeModel.GetEmployee(temp));
                }
            }
            this.responsableList.ItemsSource = CurrEmploye;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                List<Employee> employes = new List<Employee>();
                foreach (CheckBox check in this.StackEmploye.Children)
                {
                    if (check.IsChecked == true)
                    {
                        int temp = Convert.ToInt32(check.CommandParameter);
                        employes.Add(EmployeeModel.GetEmployee(temp));
                    }
                }
                Plane CurrAvion = (Plane)avionList.SelectedItem;
                Incident CurrIncident = (Incident)incidentList.SelectedItem;
                DateTime dd = Convert.ToDateTime(datedebut.Text + " " + heuredebut.Text);
                DateTime dp = Convert.ToDateTime(dateprevu.Text + " " + heurefin.Text);
                Employee responsable = (Employee)responsableList.SelectedItem;
                Maintenance maint = new Maintenance { Plane = CurrAvion, start_date = dd, Incident = CurrIncident, Responsible = responsable, planned_date = dp, Employees = employes };
                MaitenanceModel.AddMaintenance(maint);
            } catch
            {
                if (avionList.SelectedItem is null)
                {
                    ErrorAvion.Visibility = Visibility.Visible;
                } else {
                    ErrorAvion.Visibility = Visibility.Hidden;
                }
                if (incidentList.SelectedItem is null)
                {
                    ErrorIncident.Visibility = Visibility.Visible;
                } else {
                    ErrorIncident.Visibility = Visibility.Hidden;
                }
                if (responsableList.SelectedItem is null)
                {
                    ErrorResponsible.Visibility = Visibility.Visible;
                } else {
                    ErrorResponsible.Visibility = Visibility.Hidden;
                }
                if (datedebut.Text == "" || dateprevu.Text == "" ||heuredebut.Text is null || heurefin.Text is null )
                {
                    ErrorDate.Visibility = Visibility.Visible;
                } else {
                    ErrorDate.Visibility = Visibility.Hidden;
                }
                bool test = new bool();
                foreach (CheckBox check in this.StackEmploye.Children)
                {
                    if (check.IsChecked == true)
                    {
                        test = true;
                        break;
                    }
                }
                if (test is false)
                {
                    ErrorEmployee.Visibility = Visibility.Visible;
                } else {
                    ErrorEmployee.Visibility = Visibility.Hidden;
                }
            }
        }

        private void avionList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Plane CurrAvion = (Plane)avionList.SelectedItem;
            int idCurrAvion = CurrAvion.Id;

            List<Incident> test = IncidentModel.GetIncidents(idCurrAvion);

            this.incidentList.ItemsSource = IncidentModel.GetIncidents(idCurrAvion);
            
        }
    }
}
