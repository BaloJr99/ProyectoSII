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
    public partial class InformacionEscolar : ContentPage
    {
        public InformacionEscolar()
        {
            InitializeComponent();
            this.BindingContext = new InformacionEscolarVM(Navigation);
        }
    }
}