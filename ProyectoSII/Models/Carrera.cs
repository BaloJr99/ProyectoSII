using ProyectoSII.Views;
using SQLite;
using SQLiteNetExtensions.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public class Carrera
    {
        [PrimaryKey]
        public string ClaveCarrera { get; set; }

        public string NombreCarrera { get; set; }
        [OneToOne]
        public Reticula Reticula { get; set; }
    }
}
