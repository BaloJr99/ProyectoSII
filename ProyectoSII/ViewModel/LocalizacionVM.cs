using ProyectoSII.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProyectoSII.ViewModel
{
    public class LocalizacionVM:Localizacion
    {
        public Command Localizame { get; set; }
        public LocalizacionVM()
        {
            Localizame = new Command(Localizar);
        }

        private async void Localizar()
        {
            try
            {
                var localizacion = await Geolocation.GetLastKnownLocationAsync();
                if(localizacion == null)
                {
                    localizacion = await Geolocation.GetLocationAsync(
                        new GeolocationRequest()
                        {
                            DesiredAccuracy= GeolocationAccuracy.Medium,
                            Timeout = TimeSpan.FromSeconds(25)
                        });
                }

                if(localizacion == null)
                {
                    Error = "Nose donde estoy";
                }
                else
                {
                    Longitud = localizacion.Longitude;
                    Latitud = localizacion.Latitude;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
        }
    }
}
