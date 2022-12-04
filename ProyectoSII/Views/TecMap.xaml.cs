using ProyectoSII.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Xaml;

namespace ProyectoSII.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TecMap : ContentPage
    {
        public TecMap()
        {
            InitializeComponent();
            Device.InvokeOnMainThreadAsync(() =>
            {
                LoadLocation();
            });
        }

        private async void LoadLocation()
        {
            var location = await Geolocation.GetLastKnownLocationAsync();
            if(location == null) { 
                location = await Geolocation.GetLocationAsync(new GeolocationRequest()
                {
                    DesiredAccuracy = GeolocationAccuracy.Medium,
                    Timeout = TimeSpan.FromSeconds(25)
                });
            }

            if(location != null)
            {
                myMap.MoveToRegion(MapSpan.FromCenterAndRadius(new Position(location.Latitude, location.Longitude), Distance.FromMeters(100)));
            }
        }
    }
}