using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public class Asignatura
    {
        [PrimaryKey]
        public string ClaveAsignatura { get; set; }
        public string NombreAsignatura { get; set; }
        public int Ht { get; set; }
        public int Hp { get; set; }
        public int Tc { get; set; }
        public string Clave2 { get; set; }

        [OneToOne]
        public ReticulaMateria Retmat { get; set; }
        [OneToOne]
        public Boleta Boleta { get; set; }
    }
}
