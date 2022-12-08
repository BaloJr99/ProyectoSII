using ProyectoSII.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSII.Servicios
{
    public class PerfilService
    {
        public async Task<bool> EditarPerfil(PerfilModel perfil)
        {
            return await App.SQLiteDB.EditPerfil(perfil);
        }

        public async Task<PerfilModel> GetPerfil()
        {
            return await App.SQLiteDB.GetPerfil();
        }
    }
}
