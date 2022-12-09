using ProyectoSII.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSII.ViewModel
{
    public class KardexVM: KardexModel
    {
		private List<KardexModel> listaBoletasKardex;

		public List<KardexModel> ListaBoletasKardex
        {
			get { return listaBoletasKardex; }
			set { listaBoletasKardex = value;
				OnPropertyChanged();
			}
		}

		private string promedio;

		public string Promedio
		{
			get { return promedio; }
			set { promedio = value;
				OnPropertyChanged();
			}
		}


		public KardexVM()
		{
			Task.Run(GetKardexModel);
		}

		public async Task GetKardexModel()
		{
			
			List<string> listaBoletas = await App.SQLiteDB.GetSemestersKardex();
			List<KardexModel> listKardex = new List<KardexModel>();
			foreach (var boleta in listaBoletas)
			{
                listKardex.Add(new KardexModel
				{
					Titulo = boleta,
					ListBoleta = await App.SQLiteDB.GetBoletaKardex(boleta)
				});
			}
			int count = 0;
			float promedio = 0f;
			foreach (var kardex in listKardex)
			{
				foreach (var boleta in kardex.ListBoleta)
				{
					promedio += boleta.Calificacion;
					count++;
				}
			}
			Promedio = "Promedio General: " + (promedio / (float)count).ToString("#.##");
			ListaBoletasKardex = listKardex;
		}
	}
}
