using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLiteNetExtensions;
using SQLiteNetExtensions.Attributes;
using SQLitePCL;

namespace ProyectoSII.Models
{
    public class Alumno
    {
        [PrimaryKey, AutoIncrement]
        public int IdAlumno { get; set; }
        [Unique]
        public string NumControl { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public byte[] FotoPerfil { get; set; }
        public string Semestre { get; set; }

        [OneToOne]
        public Usuarios Usuarios { get; set; }
        [OneToOne]
        public AlumnoReticula AlumnoReticula { get; set; }
        [OneToMany]
        public HashSet<Boleta> Boletas { get; set; }
    }
}
