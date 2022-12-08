using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public class InformacionEscolar
    {
        [PrimaryKey, AutoIncrement]
        public int IdInformacionEscolar { get; set; }
        [ForeignKey(typeof(Alumno))]
        public string NumControl { get; set; }
        public string Calle { get; set; }
        public string Colonia { get; set; }
        public int NumInt { get; set; }
        public string NumExt { get; set; }
        public int CodigoPostal { get; set; }
        public string Ciudad { get; set; }
        public string Entidad { get; set; }
        public string NumTelefono { get; set; }
        public string Correo { get; set; }
    }
}
