using Acr.UserDialogs;
using ProyectoSII.Models;
using ProyectoSII.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoSII.ViewModel
{
    public class InscripcionesVM : InscripcionesModel
    {
        private ObservableCollection<InscripcionesModel> listaInscripciones;

        public ObservableCollection<InscripcionesModel> ListaInscripciones
        {
            get { return listaInscripciones; }
            set { listaInscripciones = value; 
                OnPropertyChanged();
            }
        }

        public Command GuardarInscripcion { get; set; }
        public InscripcionesVM()
        {
            Task.Run(GetInscripciones);
            GuardarInscripcion = new Command(async () => { await GuardarInformacion(); });
        }
        
        public async Task GuardarInformacion()
        {
            List<InscripcionesModel> inscripcion = listaInscripciones.Where(x => x.IsChecked == true).ToList();
            if (inscripcion.Count() > 0)
            {
                await App.SQLiteDB.SaveInscripcion(inscripcion);
                UserDialogs.Instance.Alert("Inscrito exitosamente", "Información", "Ok");
                await Application.Current.MainPage.Navigation.PushAsync(new MenuPrincipal());
            }
            else
            {
                UserDialogs.Instance.Alert("Seleccionar almenos una Materia", "Información", "Ok");
            }
        }

        public async Task GetInscripciones()
        {
            listaInscripciones = new ObservableCollection<InscripcionesModel>();
            IEnumerable<Horario> inscripciones = await App.SQLiteDB.GetInscripciones(StaticUsuario.Id);
            if(inscripciones == null)
            {
                UserDialogs.Instance.Alert("Aun no hay materias cargadas, puede que estes cursando materias", "Información", "Ok");
            }
            else
            {
                foreach (var horario in inscripciones)
                {
                    List<string> horas = horario.Horas.Split(';').Select(p => p.Trim()).ToList();
                    List<string> dias = horario.Dias.Split(',').Select(p => p.Trim()).ToList();
                    Dictionary<string, string> horasDias = new Dictionary<string, string>();
                    for (int i = 0; i < horas.Count(); i++)
                    {

                        horasDias.Add(dias[i], horas[i]); 
                    }

                    for(int i = 0; i < 5; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (!horasDias.ContainsKey("Lunes"))
                                {
                                    horasDias.Add("Lunes", "");
                                }
                                break;
                            case 1:
                                if (!horasDias.ContainsKey("Martes"))
                                {
                                    horasDias.Add("Martes", "");
                                }
                                break;
                            case 2:
                                if (!horasDias.ContainsKey("Miercoles"))
                                {
                                    horasDias.Add("Miercoles", "");
                                }
                                break;
                            case 3:
                                if (!horasDias.ContainsKey("Jueves"))
                                {
                                    horasDias.Add("Jueves", "");
                                }
                                break;
                            case 4:
                                if (!horasDias.ContainsKey("Viernes"))
                                {
                                    horasDias.Add("Viernes", "");
                                }
                                break;

                        }
                    }

                    listaInscripciones.Add(new InscripcionesModel
                    {
                        IsChecked = false,
                        Maestro= horario.Maestro,
                        Materia = await App.SQLiteDB.GetAsignatura(horario.AsignaturaClave),
                        Semestre = horario.Semestre.ToString(),
                        Lunes = horasDias["Lunes"],
                        Martes = horasDias["Martes"],
                        Miercoles = horasDias["Miercoles"],
                        Jueves = horasDias["Jueves"],
                        Viernes = horasDias["Viernes"],
                        ClaveMateria = horario.AsignaturaClave
                    });
                    ListaInscripciones = listaInscripciones;
                }

            }

        }
    }
}
