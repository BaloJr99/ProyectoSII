using ProyectoSII.ViewModel;
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
    public partial class Boleta : ContentPage
    {
        BoletaVM boleta;
        public Boleta()
        {
            InitializeComponent();
            boleta = new BoletaVM();
            BindingContext = boleta;
        }
    }
}