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

    public partial class PageMaintenance : Page
    {
        public PageMaintenance()
        {
            InitializeComponent();

            List<Maintenance> ListMaintenance = new List<Maintenance>();
            ListMaintenance = MaitenanceModel.GetCurrentMaintenances();
            dataGrid.ItemsSource = ListMaintenance;
        }
    }
}
