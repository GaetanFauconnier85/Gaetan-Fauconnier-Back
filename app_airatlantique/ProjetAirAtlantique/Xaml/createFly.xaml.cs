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
using System.Windows.Shapes;

namespace ProjetAirAtlantique.Xaml
{
    /// <summary>
    /// Logique d'interaction pour createFly.xaml
    /// </summary>
    public partial class createFly : Window
    {
        int idAvion;
        DateTime minD;
        DateTime maxF;
        public createFly(DateTime d , DateTime f , int idA)
        {
            InitializeComponent();
            minD = d;
            maxF = f;
            idAvion = idA;

            foreach (Trip t in TripModel.GetTrips())
            {
                infoTrajet it = new infoTrajet
                {
                    nomAeroportDepart = t.StartAirport.Libelle,
                    nomAeroportArrive = t.EndAirport.Libelle,
                    id = t.Id
                };

                trajetList.Items.Add(it);
            }

            trajetList.SelectedValuePath = "id";

            datedebut.DisplayDate = d;
            datefin.DisplayDate = f;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (trajetList.SelectedValue != null && datedebut.SelectedDate != null && datefin.SelectedDate != null && PresetTimePickerDebut.SelectedTime != null && PresetTimePickerFin.SelectedTime != null)
            {
                if (datedebut.SelectedDate > minD && datefin.SelectedDate < maxF)
                {
                    FlyModel.AddFly(new Fly()
                    {
                        hour_start = datedebut.SelectedDate.Value.AddHours(PresetTimePickerDebut.SelectedTime.Value.Hour).AddMinutes(PresetTimePickerDebut.SelectedTime.Value.Minute),
                        hour_end = datefin.SelectedDate.Value.AddHours(PresetTimePickerFin.SelectedTime.Value.Hour).AddMinutes(PresetTimePickerFin.SelectedTime.Value.Minute),
                        trip_used = TripModel.GetTrip(Convert.ToInt32(trajetList.SelectedValue)),
                        plane = PlaneModel.GetPlane(idAvion)

                    });
                    Close();
                }
                else
                {
                    MessageBox.Show("Veuillez choisir les dates de départ et d'arrivé entre le " + minD + " et le " + maxF + "");
                }
            }
            else
            {
                Error.Visibility = Visibility.Visible;
            }
            
            
        }
        
    }
}
