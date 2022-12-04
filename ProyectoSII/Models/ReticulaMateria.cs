using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public class ReticulaMateria
    {
        [PrimaryKey, AutoIncrement]
        public int IdReticulaMateria { get; set; }
        [ForeignKey(typeof(Asignatura))]
        public string IdAsignatura { get; set; }
        public int semestre { get; set; }
        [ForeignKey(typeof(Reticula))]
        public int IdReticula { get; set; }
    }
}
