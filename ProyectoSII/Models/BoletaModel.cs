using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSII.Models
{
    public class BoletaModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        private string asignatura;

        public string Asignatura
        {
            get { return asignatura; }
            set { asignatura = value;
                OnPropertyChanged();
            }
        }

        private float calificacion;

        public float Calificacion
        {
            get { return calificacion; }
            set { calificacion = value; 
                OnPropertyChanged();
            }
        }

    }

    public class PeriodoModel
    {
        public int Key { get; set; }
        public string Value { get; set; }
    } 
}
