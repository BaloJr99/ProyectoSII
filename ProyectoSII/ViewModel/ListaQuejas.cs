using ProyectoSII.Models;
using ProyectoSII.Servicios;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace ProyectoSII.ViewModel
{
    public class ListaQuejas : BindableObject
    {
		private ObservableCollection<Quejas> listaDeQuejas;
		public ObservableCollection<Quejas> ListaDeQuejas
		{
			get { return listaDeQuejas; }
			set {
                listaDeQuejas = value; 
				OnPropertyChanged();
			}
		}

		public ListaQuejas()
		{
			ListaDeQuejas = new ObservableCollection<Quejas>();
			Task.Run(GetInformation);
		}

		private async Task GetInformation()
		{
			var lista = await new QuejasService().GetListQuejas();
			foreach (var item in lista) {
                listaDeQuejas.Add(item);
            }
		}

	}
}
