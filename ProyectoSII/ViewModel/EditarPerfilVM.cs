using ProyectoSII.Models;
using ProyectoSII.Servicios;
using ProyectoSII.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ProyectoSII.ViewModel
{
    public class EditarPerfilVM: PerfilModel
    {
        private readonly PerfilService service = new PerfilService();
        PerfilModel alumno;

        public EditarPerfilVM()
        {
            Task.Run(GetPerfil);
            ModificarPerfil = new Command(async () => await EditarPerfil());
        }

        public async Task GetPerfil()
        {
            alumno = await service.GetPerfil();
            Nombre = alumno.Nombre;
            ApellidoPaterno = alumno.ApellidoPaterno;
            ApellidoMaterno = alumno.ApellidoMaterno;
            NumControl = alumno.NumControl;
            FechaNacimiento = alumno.FechaNacimiento;
            FotoPerfil = alumno.FotoPerfil;
            Semestre = alumno.Semestre;
        }

        public Command ModificarPerfil { get; set; }

        private async Task EditarPerfil()
        {
            IsBusy = true;
            alumno = new PerfilModel
            {
                Nombre = Nombre,
                ApellidoPaterno = ApellidoPaterno,
                ApellidoMaterno = ApellidoMaterno,
                NumControl = NumControl,
                FechaNacimiento = FechaNacimiento,
                FotoPerfil = FotoPerfil,
                Semestre = Semestre
            };
            await service.EditarPerfil(alumno);
            IsBusy = false;
        }
    }
}
