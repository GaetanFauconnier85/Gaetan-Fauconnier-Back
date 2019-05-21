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
using MySql.Data.MySqlClient;
using ProjetAirAtlantique.Model;

namespace ProjetAirAtlantique.Xaml
{

    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        public void Button_Click(object sender, RoutedEventArgs e)
        {
            string MDP = mdp.Password.ToString();
            string ID = identifiant.Text;

            AdminModel user = new AdminModel();

            if (user.CheckUser(ID, MDP))
            {
                Principale log = new Principale();
                log.Show();
                Close();
            }
            else
            {
                Error.Visibility = Visibility.Visible;
            }
        }

        private void Identifiant_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                string MDP = mdp.Password.ToString();
                string ID = identifiant.Text;

                AdminModel user = new AdminModel();
                
                if (user.CheckUser(ID, MDP))
                {
                    Principale log = new Principale();
                    log.Show();
                    Close();
                } else
                {
                    Error.Visibility = Visibility.Visible;
                }
            }
        }
    }
}
