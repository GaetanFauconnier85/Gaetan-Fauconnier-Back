using GMap.NET;
using GMap.NET.WindowsForms;
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
    /// Logique d'interaction pour GoogleMap.xaml
    /// </summary>
    public partial class GoogleMap : Page
    {
        public GoogleMap()
        {
            InitializeComponent();
        }
        private void mapView_Loaded(object sender, RoutedEventArgs e)
        {
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;
            // choose your provider here
            gmap.MapProvider = GMap.NET.MapProviders.OpenStreetMapProvider.Instance;
            gmap.MinZoom = 2;
            gmap.MaxZoom = 17;
            // whole world zoom
            gmap.Zoom = 2;
            // lets the map use the mousewheel to zoom
            gmap.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            // lets the user drag the map
            gmap.CanDragMap = true;
            // lets the user drag the map with the left mouse button
            GMapOverlay routes = new GMapOverlay("routes");
            List<PointLatLng> points = new List<PointLatLng>();
            points.Add(new PointLatLng(48.866383, 2.323575));
            points.Add(new PointLatLng(48.863868, 2.321554));
            points.Add(new PointLatLng(48.861017, 2.330030));
            GMapRoute route = new GMapRoute(points, "A walk in the park");
            routes.Routes.Add(route);
            gmap.Overlays.Add(routes);
        }


    }
}
