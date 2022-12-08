using Plugin.Media.Abstractions;
using ProyectoSII.ViewModel;
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
    public partial class Perfil : ContentPage
    {
        EditarPerfilVM editarPerfil = new EditarPerfilVM();
        public Perfil()
        {
            InitializeComponent();
            BindingContext = editarPerfil;
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
                editarPerfil.FotoPerfil = ms.ToArray();
            }
        }
    }
}