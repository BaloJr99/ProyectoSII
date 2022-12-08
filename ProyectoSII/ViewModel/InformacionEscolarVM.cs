using Acr.UserDialogs;
using FluentValidation.Results;
using ProyectoSII.Models;
using ProyectoSII.Servicios;
using ProyectoSII.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using static Xamarin.Essentials.Permissions;

namespace ProyectoSII.ViewModel
{
    public class InformacionEscolarVM:InformacionEscolarModel
    {
        public Command Guardar { get; set; }

        InformacionEscolarModel infoEscolar;

        public InformacionEscolarVM(INavigation navigation)
        {
            Task.Run(GetInformacionEscolar);
            Guardar = new Command(async () => await GuardarInformacion(navigation));
        }

        private async Task GuardarInformacion(INavigation navigation)
        {
            InformacionEscolarValidacion validation = new InformacionEscolarValidacion();
            infoEscolar = new InformacionEscolarModel
            {
                IdInformacion = IdInformacion,
                NumControl = NumControl,
                NombreAlumno = NombreAlumno,
                Semestre = Semestre,
                Entidad = Entidad,
                Correo = Correo,
                Colonia = Colonia,
                Calle = Calle,
                Telefono = Telefono,
                Carrera = Carrera,
                Ciudad = Ciudad,
                CodigoPostal = CodigoPostal,
                Especialidad = Especialidad,
                NumExt = NumExt,
                NumInt = NumInt,
                Promedio = Promedio
            };
            ValidationResult result = validation.Validate(infoEscolar);
            if (result.IsValid)
            {
                if(await App.SQLiteDB.SaveInformacionEscolar(infoEscolar))
                {
                    UserDialogs.Instance.Alert("Datos Guardados", "Información", "Ok");
                }
            }
            else
            {
                UserDialogs.Instance.Alert(result.Errors[0].ToString(), "Advertencia", "Ok");
            }
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
