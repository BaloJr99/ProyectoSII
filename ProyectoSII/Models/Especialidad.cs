using ProyectoSII.Views;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Text;

namespace ProyectoSII.Models
{
    public class Especialidad
    {
        [PrimaryKey]
        public string ClaveEspecialidad { get; set; }

        public string NombreEspecialidad { get; set; }
        [OneToOne]
        public Reticula Reticula { get; set; }
    }
}
