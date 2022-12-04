using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public class Horario
    {
        [PrimaryKey, AutoIncrement]
        public int IdHorario { get; set; }
        public string Maestro { get; set; }
        public string Dias { get; set; }
        public string Horas { get; set; }
        public int Semestre { get; set; }
        [ForeignKey(typeof(Asignatura))]
        public string AsignaturaClave { get; set; }
        [ForeignKey(typeof(Reticula))]
        public int IdReticula { get; set; }
        public bool Enabled { get; set; }
    }
}
