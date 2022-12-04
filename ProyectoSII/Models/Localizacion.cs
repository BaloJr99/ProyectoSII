using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;

namespace ProyectoSII.Models
{
    public class Localizacion:INotifyPropertyChanged
    {

        private string error;

        public string Error
        {
            get { return error; }
            set { error = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string nombre = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nombre));
        }
        private double longitud;

        public double Longitud
        {
            get { return longitud; }
            set
            {
                longitud = value;
                OnPropertyChanged();
            }
        }

        private double latitud;

        public double Latitud
        {
            get { return latitud; }
            set
            {
                latitud = value;
                OnPropertyChanged();
            }
        }

    }
}
