using ProyectoSII.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSII.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FlyoutMenuPage : ContentPage
    {
        public FlyoutMenuPage()
        {
            InitializeComponent();
            FotoPerfil.Source = ImageSource.FromStream(() => new MemoryStream(StaticUsuario.FotoPerfil));
            Nombre.Text = String.Concat(StaticUsuario.Nombre, " ",StaticUsuario.ApellidoPaterno, " ", StaticUsuario.ApellidoMaterno);
            NumControl.Text = StaticUsuario.NumControl;
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            bool answer = await DisplayAlert("Regresando al Login", "Esta seguro que desea cerrar sesión", "Si", "No");
            if (answer)
            {
                await Navigation.PushAsync(new LoginPage());
            }
        }
    }
}