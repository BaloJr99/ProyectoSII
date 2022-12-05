using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProyectoSII.Models
{
	public class Quejas
    {

        private string queja;

		public string Queja
		{
			get { return queja; }
			set { queja = value; }
		}

		private string apartado;

		public string Apartado
		{
			get { return apartado; }
			set { apartado = value; }
		}

		private DateTime fecha;

        public DateTime Fecha
		{
			get { return fecha; }
			set { fecha = value; }
		}

	}
}
