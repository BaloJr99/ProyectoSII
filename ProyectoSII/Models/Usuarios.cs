using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;

namespace ProyectoSII.Models
{
    public class Usuarios
    {
        [PrimaryKey, AutoIncrement]
        public int IdUsuario { get; set; }

        public string User { get; set; }
        public string Password { get; set; }
        [ForeignKey(typeof(Alumno))]
        public int AlumnoId { get; set; }
    }
}
