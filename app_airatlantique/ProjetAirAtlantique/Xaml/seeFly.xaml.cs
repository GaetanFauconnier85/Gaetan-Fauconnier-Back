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
    /// <summary>
    /// Logique d'interaction pour seeFly.xaml
    /// </summary>
    public partial class seeFly : Page
    {
        public List<Fly> ListFlies = new List<Fly>();
        public seeFly()
        {
            InitializeComponent();

            ListFlies = FlyModel.GetFlies();
            dataGridFlies.ItemsSource = ListFlies;
            dataGridFlies.SelectedValuePath = "Id";
        }

        private void Supprimer_Click(object sender, RoutedEventArgs e)
        {
            List<int> journeyId = FlyModel.selectJourneyId(Convert.ToInt32(dataGridFlies.SelectedValue));
            foreach (var item in journeyId)
            {
                TicketModel.DeleteTicket(item);
                JourneyModel.DeleteJourney(item);
                JourneyModel.DeleteJourneyFly(item);
            }
            FlyModel.DeleteFly(Convert.ToInt32(dataGridFlies.SelectedValue));
            dataGridFlies.ItemsSource = null;
            dataGridFlies.ItemsSource = FlyModel.GetFlies();
        }
    }
}
