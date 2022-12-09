using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProyectoSII.Models
{
    public class InscripcionesModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

		public void OnPropertyChanged([CallerMemberName]string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
        private bool isChecked;

		public bool IsChecked
		{
			get { return isChecked; }
			set { isChecked = value;
				OnPropertyChanged();
			}
		}

		private string materia;	

		public string Materia
		{
			get { return materia; }
			set { materia = value;
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

		private string maestro;

		public string Maestro
		{
			get { return maestro; }
			set { maestro = value;
                OnPropertyChanged();
            }
		}

		private string lunes;

		public string Lunes
		{
			get { return lunes; }
			set { lunes = value;
                OnPropertyChanged();
            }
		}

		private string martes;

		public string Martes
		{
			get { return martes; }
			set { martes = value;
                OnPropertyChanged();
            }
		}

		private string miercoles;

		public string Miercoles
		{
			get { return miercoles; }
			set { miercoles = value;
                OnPropertyChanged();
            }
		}

		private string jueves;

		public string Jueves
		{
			get { return jueves; }
			set { jueves = value;
                OnPropertyChanged();
            }
		}

		private string viernes;


        public string Viernes
		{
			get { return viernes; }
			set { viernes = value;
                OnPropertyChanged();
            }
		}

		private string claveMateria;

		public string ClaveMateria
		{
			get { return claveMateria; }
			set { claveMateria = value;
                OnPropertyChanged();
            }
		}


	}
}
