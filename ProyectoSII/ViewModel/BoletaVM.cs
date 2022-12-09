using ProyectoSII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSII.ViewModel
{
    public class BoletaVM:BoletaModel
    {
        private List<PeriodoModel> listPeriodos;

        public List<PeriodoModel> ListPeriodos
        {
            get { return listPeriodos; }
            set
            {
                listPeriodos = value;
                OnPropertyChanged();
            }
        }

        private List<BoletaModel> listBoleta;   

        public List<BoletaModel> ListBoleta
        {
            get { return listBoleta; }
            set {
                listBoleta = value; 
                OnPropertyChanged();
            }
        }

        private bool isVisible;

        public bool IsVisible
        {
            get { return isVisible; }
            set { isVisible = value; 
                OnPropertyChanged();
            }
        }


        public BoletaVM()
        {
            IsVisible = false;
            Task.Run(GetSemesters);
        }

        private PeriodoModel selectedPeriod { get; set; }

        public PeriodoModel SelectedPeriod
        {
            get { return selectedPeriod; }
            set
            {
                if(selectedPeriod!= value)
                {
                    selectedPeriod = value;
                    Task.Run(async () =>
                    {
                        await GetBoletaSeleccionada(selectedPeriod.Value);
                    });
                    IsVisible = true;
                    OnPropertyChanged();
                }
            }
        }

        public async Task GetSemesters()
        {
            List<string> periodos = await App.SQLiteDB.GetSemesters();
            List<PeriodoModel> lPeriodo = new List<PeriodoModel>();
            if (periodos.Count() > 0)
            {
                for (int i = 0; i < periodos.Count(); i++)
                {
                    lPeriodo.Add(new PeriodoModel
                    {
                        Key = i,
                        Value = periodos[i]
                    });
                }
            }
            else
            {
                lPeriodo.Add(new PeriodoModel
                {
                    Key = 1,
                    Value = "No hay Datos"
                });

            }
            ListPeriodos = lPeriodo;
        }
        public async Task GetBoletaSeleccionada(string periodo)
        {
            ListBoleta = await App.SQLiteDB.GetBoleta(periodo);
        }
    }
}
