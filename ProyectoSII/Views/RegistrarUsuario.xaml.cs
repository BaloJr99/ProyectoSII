using Plugin.Media.Abstractions;
using ProyectoSII.Models;
using ProyectoSII.ViewModel;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProyectoSII.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegistrarUsuario : ContentPage
    {

        byte[] fotoperfil;
        public RegistrarUsuario()
        {
            InitializeComponent();
            BindingContext = new RegistrarVM();
            dpFecha.MaximumDate = DateTime.Now.AddYears(-15);
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            if (!camposVacios())
            {
                Semester Semestre = (Semester)ChoosenSemester.SelectedItem;
                Alumno alumno = new Alumno
                {
                    Nombre = eNombre.Text,
                    ApellidoPaterno = eApellidoP.Text,
                    ApellidoMaterno = eApellidoM.Text,
                    NumControl = eControl.Text,
                    FechaNacimiento = dpFecha.Date,
                    FotoPerfil = fotoperfil,
                    Semestre = Semestre.Value
                };
                alumno.IdAlumno = await App.SQLiteDB.SaveAlumnoAsync(alumno);

                Random rnd = new Random();
                Usuarios usuarios = new Usuarios
                {
                    AlumnoId = alumno.IdAlumno,
                    User = eControl.Text,
                    Password = rnd.Next(1111, 9999).ToString()
                };

                await App.SQLiteDB.SaveUsuarioAsync(usuarios);
                await DisplayAlert("Contraseña", "Este es tu usuario " + alumno.NumControl + " y contraseña " + usuarios.Password, "Ok");

                await Navigation.PushAsync(new LoginPage());
            }
            else
            {
                await DisplayAlert("Advertencia","Favor de llenar los campos", "Ok");
            }
        }

        private bool camposVacios()
        {
            if (string.IsNullOrEmpty(eNombre.Text))
                return true;
            else if (string.IsNullOrEmpty(eApellidoP.Text))
                return true;
            else if (string.IsNullOrEmpty(eApellidoM.Text))
                return true;
            else if (string.IsNullOrEmpty(eControl.Text))
                return true;
            else if (fotoperfil == null)
                return true;
            return false;
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var camera = new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
                SaveToAlbum = true,
                AllowCropping = true,
                DefaultCamera = CameraDevice.Rear
            };

            var foto = await Plugin.Media.CrossMedia.Current.TakePhotoAsync(camera);
            if (foto != null)
            {
                Stream stream = foto.GetStream();
                MemoryStream ms = new MemoryStream();
                stream.CopyTo(ms);
                fotoperfil = ms.ToArray();

                prefoto.Source = ImageSource.FromStream(() =>
                {
                    return foto.GetStream();
                });
            }
        }
    }
}