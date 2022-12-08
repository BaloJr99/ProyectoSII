using ProyectoSII.Models;
using ProyectoSII.Servicios;
using ProyectoSII.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace ProyectoSII.ViewModel
{
    public class InformacionEscolarVM:InformacionEscolarModel
    {
        public Command Guardar { get; set; }
        private readonly PerfilService service = new PerfilService();
        InformacionEscolarModel infoEscolar;

        public InformacionEscolarVM()
        {
            Task.Run(GetInformacionEscolar);
            Guardar = new Command(async () => await GuardarInformacion());
        }

        private async Task GuardarInformacion()
        {

        }

        private async Task GetInformacionEscolar()
        {
            infoEscolar = await App.SQLiteDB.GetInformacionEscolar();
            IdInformacion = infoEscolar.IdInformacion;
            NumControl = infoEscolar.NumControl;
            NombreAlumno = infoEscolar.NombreAlumno;
            Semestre = infoEscolar.Semestre;
            Entidad = infoEscolar.Entidad;
            Correo = infoEscolar.Correo;
            Colonia = infoEscolar.Colonia;
            Calle = infoEscolar.Calle;
            Telefono = infoEscolar.Telefono;
            Carrera = infoEscolar.Carrera;
            Ciudad = infoEscolar.Ciudad;
            CodigoPostal = infoEscolar.CodigoPostal;
            Especialidad = infoEscolar.Especialidad;
            NumExt = infoEscolar.NumExt;
            NumInt = infoEscolar.NumInt;
            Promedio = infoEscolar.Promedio;

        }
    }
}
