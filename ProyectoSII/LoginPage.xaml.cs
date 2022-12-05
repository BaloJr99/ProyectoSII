using ProyectoSII.Models;
using ProyectoSII.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace ProyectoSII
{
    public partial class LoginPage : ContentPage
    {
        SensorSpeed speed = SensorSpeed.Fastest;

        public LoginPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            Accelerometer.ShakeDetected += Accelerometer_ShakeDetected;
            Accelerometer.Start(speed);
        }
        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            Accelerometer.ShakeDetected -= Accelerometer_ShakeDetected;
            Accelerometer.Stop();
        }

        private void Accelerometer_ShakeDetected(object sender, EventArgs e)
        {
            eUser.Text = "";
            ePassword.Text = "";
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                await DisplayAlert("Advertencia", "Advertencia Ingresar todos los datos", "Ok");
            }
            else
            {
                Usuarios user = new Usuarios
                {
                    User = eUser.Text,
                    Password = ePassword.Text
                };
                if (await App.SQLiteDB.CheckUserPassword(user) != 0)
                {
                    await Navigation.PushAsync(new MenuPrincipal());
                }
                else
                {
                    await DisplayAlert("Login", "Contraseñas incorrectas", "Ok");
                }
            }
        }

        private bool CheckInputs()
        {
            if (string.IsNullOrEmpty(eUser.Text))
            {
                return true;
            }else if (string.IsNullOrEmpty(ePassword.Text))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private async void Button_Clicked_1(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegistrarUsuario());
        }
    }
}
