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
    public class infoTrajet
        {
            public string nomAeroportDepart { get; set; }
            public string nomAeroportArrive { get; set; }
            public int id { get; set; }
        }

    public partial class Page1 : Page
    {

        public Page1()
        {
            InitializeComponent();

            
            dataGridVol.IsEnabled = false;
            
            depart.DisplayDateStart = DateTime.Now;
            depart.SelectedDate = DateTime.Now;
            fin.DisplayDateStart = DateTime.Now;
            fin.SelectedDate = DateTime.Now;
        }


        private void Enregistrer_Click(object sender, RoutedEventArgs e)
        {
            DateTime d = Convert.ToDateTime(depart.Text);
            DateTime f = Convert.ToDateTime(fin.Text);
            createFly c = new createFly(d, f, Convert.ToInt32(dataGridVol.SelectedValue));
            c.ShowDialog();
            
            
            

            // Convert.ToString(trajetList.SelectedValue), d.ToString("yyyy/MM/dd"),Convert.ToInt32(dataGridVol.SelectedValue)
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            dataGridVol.ItemsSource = null;
            dataGridVol.IsEnabled = true;
            List<Plane> planes = new List<Plane>();

            DateTime d = Convert.ToDateTime(depart.Text);
            DateTime f = Convert.ToDateTime(fin.Text);

            planes = PlaneModel.GetFreePlanes(d.ToString("yyyy-MM-dd"), f.ToString("yyyy-MM-dd"));            
            dataGridVol.ItemsSource = planes;
            dataGridVol.SelectedValuePath = "Id";

        }
    }
}
