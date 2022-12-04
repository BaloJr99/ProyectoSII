using ProyectoSII.Models;
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
    public partial class Reticula : ContentPage
    {

        public Reticula()
        {
            InitializeComponent();
            BindingContext = new ReticulaVM();
            ChoosenSemester.SelectedIndex = 0;
        }

        private async Task FillKardex(int semester)
        {
            KardexGrid.Children.Clear();
            var Asignaturas = await App.SQLiteDB.GetReticula(StaticUsuario.Id, semester + 1);

            int index = 0;

            int rowCount = KardexGrid.RowDefinitions.Count();

            while (rowCount != Asignaturas.Count())
            {
                if(rowCount > Asignaturas.Count())
                {
                    KardexGrid.RowDefinitions.RemoveAt(rowCount - 1);
                }
                else
                {
                    KardexGrid.RowDefinitions.Add(new RowDefinition
                    {
                        Height = 130
                    });
                }
                rowCount = KardexGrid.RowDefinitions.Count();
            }

            for (int rowIndex = 0; rowIndex < Asignaturas.Count(); rowIndex++)
            {

                BoxView box = new BoxView
                {
                    Color = Color.White
                    
                };
                StackLayout stackLayoutHeader = new StackLayout { 
                    Orientation = StackOrientation.Horizontal,
                    BackgroundColor = Color.SkyBlue,
                };
                string ht = Asignaturas[index].Tc != 0 ? Asignaturas[index].Ht.ToString() : "";
                Label lblHt = new Label
                {
                    Text = ht,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                string hp = Asignaturas[index].Tc != 0 ? Asignaturas[index].Hp.ToString() : "";
                Label lblHp = new Label
                {
                    Text = hp,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                string tc = Asignaturas[index].Tc != 0 ? Asignaturas[index].Tc.ToString() : "";
                Label lblTc = new Label
                {
                    Text = tc,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20,
                    HorizontalOptions = LayoutOptions.FillAndExpand
                };
                stackLayoutHeader.Children.Add(lblHt);
                stackLayoutHeader.Children.Add(lblHp);
                stackLayoutHeader.Children.Add(lblTc);
                StackLayout stackLayout = new StackLayout {Orientation = StackOrientation.Vertical};
                stackLayout.Children.Add(stackLayoutHeader);
                Label asignatura = new Label
                {
                    Text = Asignaturas[index].NombreAsignatura,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 20
                };
                Label claveAsignatura = new Label
                {
                    Text = Asignaturas[index].ClaveAsignatura,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center,
                    FontSize = 18
                };
                stackLayout.Children.Add(asignatura);
                stackLayout.Children.Add(claveAsignatura);
                index++;
                KardexGrid.Children.Add(box, 0, rowIndex);
                KardexGrid.Children.Add(stackLayout, 0, rowIndex);
            }
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await FillKardex(ChoosenSemester.SelectedIndex);
        }
    }
}