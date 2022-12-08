using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProyectoSII.Models
{
    public class InformacionEscolarModel:INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName] string name = "")
		{
			PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
		}

		private int idInformacion;

		public int IdInformacion
		{
			get { return idInformacion; }
			set { idInformacion = value;
				OnPropertyChanged();
			}
		}


		private string numControl;

		public string NumControl
		{
			get { return numControl; }
			set { numControl = value;
				OnPropertyChanged();
			}
		}

		private string nombreAlumno;

		public string NombreAlumno
		{
			get { return nombreAlumno; }
			set { nombreAlumno = value;
                OnPropertyChanged();
            }
		}

		private string semestre;

		public string Semestre
		{
			get { return semestre; }
			set { semestre = value;
                OnPropertyChanged();
            }
		}

		private float promedio;

		public float Promedio
		{
			get { return promedio; }
			set { promedio = value;
                OnPropertyChanged();
            }
		}

		private string carrera;

		public string Carrera
		{
			get { return carrera; }
			set { carrera = value;
                OnPropertyChanged();
            }
		}

		private string especialidad;

		public string Especialidad
		{
			get { return especialidad; }
			set { especialidad = value;
                OnPropertyChanged();
            }
		}

		private string calle;

		public string Calle
		{
			get { return calle; }
			set { calle = value;
                OnPropertyChanged();
            }
		}

		private string colonia;

		public string Colonia
		{
			get { return colonia; }
			set { colonia = value;
                OnPropertyChanged();
            }
		}

		private int numInt;

		public int NumInt
		{
			get { return numInt; }
			set { numInt = value;
                OnPropertyChanged();
            }
		}

		private string numExt;

		public string NumExt
		{
			get { return numExt; }
			set { numExt = value;
                OnPropertyChanged();
            }
		}

		private int codigoPostal;

		public int CodigoPostal
		{
			get { return codigoPostal; }
			set { codigoPostal = value;
                OnPropertyChanged();
            }
		}

		private string ciudad;

		public string Ciudad
		{
			get { return ciudad; }
			set { ciudad = value;
                OnPropertyChanged();
            }
		}

		private string entidad;

		public string Entidad
		{
			get { return entidad; }
			set { entidad = value;
                OnPropertyChanged();
            }
		}

		private string telefono;

		public string Telefono
		{
			get { return telefono; }
			set { telefono = value;
                OnPropertyChanged();
            }
		}

		private string correo;

        public string Correo
		{
			get { return correo; }
			set { correo = value;
                OnPropertyChanged();
            }
		}

	}
}
