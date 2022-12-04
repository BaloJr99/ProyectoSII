using ProyectoSII.Views;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public class AlumnoReticula
    {
        [PrimaryKey, AutoIncrement]
        public int IdAlumnoReticula { get; set; }
        [ForeignKey(typeof(Reticula))]
        public int IdReticula { get; set; }
        [ForeignKey(typeof(Alumno))]
        public int IdAlumno { get; set; }
    }
}
