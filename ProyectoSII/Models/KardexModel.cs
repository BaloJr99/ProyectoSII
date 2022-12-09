using ProyectoSII.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProyectoSII.Models
{
    public class KardexModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string titulo;

		public string Titulo
		{
			get { return titulo; }
			set { titulo = value;
				OnPropertyChanged();
			}
		}

        private List<BoletaModel> listBoleta;

        public List<BoletaModel> ListBoleta
        {
            get { return listBoleta; }
            set
            {
                listBoleta = value;
                OnPropertyChanged();
            }
        }
    }
}
