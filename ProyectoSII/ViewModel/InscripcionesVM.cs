using ProyectoSII.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;

namespace ProyectoSII.ViewModel
{
    public class InscripcionesVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Boleta> boletas;
        public ObservableCollection<Boleta> Boletas
        {
            get;set;

        }
    }
}
