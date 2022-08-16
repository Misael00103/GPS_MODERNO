using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Essentials;
using Plugin.Geolocator;


namespace GPS_MODERNO
{
    public partial class MainPage : ContentPage
    {
        double latitud;
        double longitud;
        public MainPage()
        {
            InitializeComponent();
            IniciarGPS();

        }


        private void VerMapa_Clicked(object sender, EventArgs e)
        {

        }
        private async void IniciarGPS()
        {
            var geolocator = CrossGeolocator.Current;

            geolocator.DesiredAccuracy = 50;

            if (geolocator.IsGeolocationEnabled)
            {
                if (!geolocator.IsListening)
                {
                    await geolocator.StartListeningAsync(TimeSpan.FromSeconds(1), 5);
                }
                geolocator.PositionChanged += (cambio, args) =>
                {
                    var loc = args.Position;
                    lon.Text = loc.Longitude.ToString();
                    longitud = double.Parse(lon.Text);
                    lat.Text = loc.Latitude.ToString();
                    latitud = double.Parse(lat.Text);
                };

            }
        }

        private async void VerMapa_Clicked1(object sender, EventArgs e)
        {
            MapLaunchOptions options = new MapLaunchOptions { Name = "Mi Posicion Actual" };
            await Map.OpenAsync(latitud, longitud, options);

        }

    }
}
