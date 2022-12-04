using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public class Boleta
    {
        [PrimaryKey, AutoIncrement]
        public int IdBoleta { get; set; }
        [ForeignKey(typeof(Alumno))]
        public int IdAlumno { get; set; }
        [ForeignKey(typeof(Asignatura))]
        public string IdAsignatura { get; set; }
        public string Calificacion { get; set; }
        public bool Aprobada { get; set; }
    }
}
