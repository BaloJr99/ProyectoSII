using SQLite;
using SQLiteNetExtensions.Attributes;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoSII.Models
{
    public static class StaticUsuario
    {
        public static int Id { get; set; }
        public static string NumControl { get; set; }
        public static string Nombre { get; set; }
        public static string ApellidoPaterno { get; set; }
        public static string ApellidoMaterno { get; set; }
        public static DateTime FechaNacimiento { get; set; }
        public static byte[] FotoPerfil { get; set; }
        public static string Semestre { get; set; }
    }
}
