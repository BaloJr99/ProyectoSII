using ProyectoSII.Models;
using ProyectoSII.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;
using Image = Xamarin.Forms.Image;

namespace ProyectoSII.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Inscripciones : ContentPage
    {
        InscripcionesVM inscripcionesVM;
        public Inscripciones()
        {
            InitializeComponent();
            inscripcionesVM = new InscripcionesVM();
            this.BindingContext = inscripcionesVM;
            //Device.BeginInvokeOnMainThread(() =>
            //{
            //    getInscripciones();
            //});
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Send(this, "SetLandscape");
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Send(this, "RemoveLandscape");
        }

        private async void getInscripciones()
        {
            IEnumerable<Horario> inscripciones = await App.SQLiteDB.GetInscripciones(StaticUsuario.Id);
            if(inscripciones == null)
            {
                StackLayout stack = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                };
                Image warning = new Image
                {
                    Source = "warning.png"
                };
                Label warningMsg = new Label
                {
                    Text = "Lo sentimos aun no existen materias cargadas",
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                };
                stack.Children.Add(warning);
                stack.Children.Add(warningMsg);
                mainPage.Children.Add(stack);
            }
            else
            {
                Grid inscriptionGrid = new Grid
                {
                    BackgroundColor = Color.Black,
                    ColumnSpacing = 2,
                    RowSpacing = 2
                };
                inscriptionGrid.RowDefinitions.Add(new RowDefinition());
                inscriptionGrid.RowDefinitions.Add(new RowDefinition());
                inscriptionGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Auto)
                });
                inscriptionGrid.ColumnDefinitions.Add(new ColumnDefinition());
                inscriptionGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Auto)
                });
                inscriptionGrid.ColumnDefinitions.Add(new ColumnDefinition());
                inscriptionGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Auto)
                });
                inscriptionGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Auto)
                });
                inscriptionGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Auto)
                });
                inscriptionGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Auto)
                });
                inscriptionGrid.ColumnDefinitions.Add(new ColumnDefinition
                {
                    Width = new GridLength(1, GridUnitType.Auto)
                });

                for (int i = 0; i < inscripciones.Count(); i++)
                {
                    inscriptionGrid.RowDefinitions.Add(new RowDefinition());
                    inscriptionGrid.Children.Add(new BoxView
                    {
                        Color = Color.White
                    }, 0, i + 2);
                    inscriptionGrid.Children.Add(new CheckBox(), 0, i + 2); 
                    inscriptionGrid.Children.Add(new BoxView
                    {
                        Color = Color.White
                    }, 1, i + 2);
                    inscriptionGrid.Children.Add(new Label
                    {
                        Text = await App.SQLiteDB.GetAsignatura(inscripciones.ElementAt(i).AsignaturaClave),
                        VerticalTextAlignment = TextAlignment.Center,
                        Padding = new Thickness(10, 0, 0, 0)
                    }, 1, i + 2);
                    inscriptionGrid.Children.Add(new BoxView
                    {
                        Color = Color.White
                    }, 2, i + 2);
                    inscriptionGrid.Children.Add(new Label
                    {
                        Text = inscripciones.ElementAt(i).Semestre.ToString(),
                        VerticalTextAlignment = TextAlignment.Center,
                        HorizontalTextAlignment = TextAlignment.Center
                    }, 2, i + 2);
                    inscriptionGrid.Children.Add(new BoxView
                    {
                        Color = Color.White
                    }, 3, i + 2);
                    inscriptionGrid.Children.Add(new Label
                    {
                        Text = inscripciones.ElementAt(i).Maestro,
                        VerticalTextAlignment = TextAlignment.Center,
                        Padding = new Thickness(10, 0, 0, 0)
                    }, 3, i + 2);

                    List<string> horas = inscripciones.ElementAt(i).Horas.Split(';').Select(p => p.Trim()).ToList();
                    List<string> dias = inscripciones.ElementAt(i).Dias.Split(',').Select(p => p.Trim()).ToList();

                    for (int j = 0; j < dias.Count(); j++)
                    {
                        Label lbl = new Label
                        {
                            VerticalTextAlignment = TextAlignment.Center,
                            HorizontalTextAlignment = TextAlignment.Center,
                            Padding = new Thickness(5, 0, 5, 0)
                        };
                        BoxView boxInside = new BoxView
                        {
                            Color = Color.White
                        };
                        if (dias[j].Equals("Lunes"))
                        {
                            lbl.Text = horas[j];

                            inscriptionGrid.Children.Add(boxInside, 4, i + 2);
                            inscriptionGrid.Children.Add(lbl, 4, i + 2);
                        }
                        else if (dias[j].Equals("Martes"))
                        {
                            lbl.Text = horas[j];
                            inscriptionGrid.Children.Add(boxInside, 5, i + 2);
                            inscriptionGrid.Children.Add(lbl, 5, i + 2);
                        }
                        else if (dias[j].Equals("Miercoles"))
                        {
                            lbl.Text = horas[j];
                            inscriptionGrid.Children.Add(boxInside, 6, i + 2);
                            inscriptionGrid.Children.Add(lbl, 6, i + 2);
                        }
                        else if (dias[j].Equals("Jueves"))
                        {
                            lbl.Text = horas[j];
                            inscriptionGrid.Children.Add(boxInside, 7, i + 2);
                            inscriptionGrid.Children.Add(lbl, 7, i + 2);
                        }
                        else if (dias[j].Equals("Viernes"))
                        {
                            lbl.Text = horas[j];
                            inscriptionGrid.Children.Add(boxInside, 8, i + 2);
                            inscriptionGrid.Children.Add(lbl, 8, i + 2);
                        }
                    }
                }

                BoxView box = new BoxView
                {
                    Color = Color.RoyalBlue
                };

                string carrera = await App.SQLiteDB.GetCarrera();

                Label lblCarrera = new Label
                {
                    Text = carrera.ToUpper(),
                    TextColor = Color.White,
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                };

                Grid.SetColumnSpan(box, 9);
                Grid.SetRow(box, 0);
                Grid.SetColumnSpan(lblCarrera, 9);
                Grid.SetRow(lblCarrera, 0);
                inscriptionGrid.Children.Add(box);
                inscriptionGrid.Children.Add(lblCarrera);
                
                BoxView boxCol = new BoxView
                {
                    Color = Color.White
                }; 
                Grid.SetColumnSpan(boxCol, 9);
                Grid.SetRow(boxCol, 1);
                inscriptionGrid.Children.Add(boxCol);

                inscriptionGrid.Children.Add(new Label
                {
                    Text = "MATERIA",
                    VerticalTextAlignment= TextAlignment.Center,
                }, 1, 1);
                inscriptionGrid.Children.Add(new Label
                {
                    Text = "SEM",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                }, 2, 1); 
                inscriptionGrid.Children.Add(new Label
                {
                    Text = "MAESTRO",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                }, 3, 1);
                inscriptionGrid.Children.Add(new Label
                {
                    Text = "LUN",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                }, 4, 1); 
                inscriptionGrid.Children.Add(new Label
                {
                    Text = "MAR",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                }, 5, 1);
                inscriptionGrid.Children.Add(new Label
                {
                    Text = "MIER",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                }, 6, 1);
                inscriptionGrid.Children.Add(new Label
                {
                    Text = "JUE",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                }, 7, 1);
                inscriptionGrid.Children.Add(new Label
                {
                    Text = "VIE",
                    VerticalTextAlignment = TextAlignment.Center,
                    HorizontalTextAlignment = TextAlignment.Center
                }, 8, 1);
                mainPage.Children.Add(inscriptionGrid);
                StackLayout stack = new StackLayout
                {
                    Orientation = StackOrientation.Vertical,
                };

                Button btnInscribir = new Button
                {
                    Text = "Finalizar",
                    CornerRadius = 5,
                    BackgroundColor = Color.DeepSkyBlue,
                    HorizontalOptions = LayoutOptions.End
                };

                stack.Children.Add(btnInscribir);
                mainPage.Children.Add(stack);
            }
        }
    }
}