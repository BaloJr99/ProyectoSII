using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public class Reticula
    {
        [PrimaryKey, AutoIncrement]
        public int IdReticula { get; set; }
        [ForeignKey(typeof(Carrera))]
        public string IdCarrera { get; set; }
        [ForeignKey(typeof(Especialidad))]
        public string IdEspecialidad { get; set; }
        [OneToOne]
        public ReticulaMateria RetMat { get; set; }

    }
}
