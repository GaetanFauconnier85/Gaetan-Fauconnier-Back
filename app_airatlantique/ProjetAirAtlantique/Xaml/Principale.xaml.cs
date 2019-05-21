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
using System.Windows.Shapes;

namespace ProjetAirAtlantique.Xaml
{

    public partial class Principale : Window
    {
        public Principale()
        {
            InitializeComponent();
            Frame_Principale.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;
            Frame_Principale.Navigate(new Page1());
        }
        
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;

            tb1.Visibility = Visibility.Visible;
            Grid1.Width = 300;
            btnAddFly.HorizontalAlignment = HorizontalAlignment.Left;
            Thickness margin1 = btnAddFly.Margin;
            margin1.Left = 15;
            btnAddFly.Margin = margin1;

            tb2.Visibility = Visibility.Visible;
            Grid2.Width = 300;
            btnSearchFly.HorizontalAlignment = HorizontalAlignment.Left;
            Thickness margin2 = btnSearchFly.Margin;
            margin2.Left = 15;
            btnSearchFly.Margin = margin2;

            tb3.Visibility = Visibility.Visible;
            Grid3.Width = 300;
            btnSeeMaintenance.HorizontalAlignment = HorizontalAlignment.Left;
            Thickness margin3 = btnSeeMaintenance.Margin;
            margin3.Left = 15;
            btnSeeMaintenance.Margin = margin3;

            tb4.Visibility = Visibility.Visible;
            Grid4.Width = 300;
            btnAddMaintenance.HorizontalAlignment = HorizontalAlignment.Left;
            Thickness margin4 = btnAddMaintenance.Margin;
            margin4.Left = 15;
            btnAddMaintenance.Margin = margin4;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            tb1.Visibility = Visibility.Hidden;
            tb2.Visibility = Visibility.Hidden;
            tb3.Visibility = Visibility.Hidden;
            tb4.Visibility = Visibility.Hidden;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            const string message = "Voulez-vous vraiment vous déconnecter ?";
            const string caption = "Déconnection";
            MessageBoxResult result = MessageBox.Show(message, caption,
                                         MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                Login log = new Login();
                log.Show();
                Close();
            }

        }

        private void btn_GestionVol(object sender, RoutedEventArgs e)
        {
            Frame_Principale.Navigate(new Page1());
        }
        
        private void btn_Maintenances(object sender, RoutedEventArgs e)
        {
            Frame_Principale.Navigate(new PageMaintenance());
        }
        private void btn_SearchFly(object sender, RoutedEventArgs e)
        {
            Frame_Principale.Navigate(new seeFly());
        }

        private void btn_AddMaintenance(object sender, RoutedEventArgs e)
        {
            Frame_Principale.Navigate(new AddMaintenance());
        }

    }
}
