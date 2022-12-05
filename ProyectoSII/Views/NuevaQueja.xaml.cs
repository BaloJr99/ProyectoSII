using ProyectoSII.Models;
using ProyectoSII.Servicios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSII.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuevaQueja : ContentPage
    {
        public NuevaQueja()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!await camposVacios())
            {
                QuejasService quejas = new QuejasService();
                Quejas queja = new Quejas
                {
                    Fecha = DateTime.Now,
                    Apartado = section.SelectedItem.ToString(),
                    Queja = eQueja.Text
                };
                if(!await quejas.AgregarQueja(queja))
                {
                    await DisplayAlert("Advertencia", "Ocurrio un error", "Ok");
                }
                else
                {
                    await Navigation.PopAsync();
                }
            }
        }

        private async Task<bool> camposVacios()
        {
            if (section.SelectedItem == null ||
                string.IsNullOrEmpty(eQueja.Text))
            {
                await DisplayAlert("Advertencia", "Llenar todos los campos", "Ok");
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}