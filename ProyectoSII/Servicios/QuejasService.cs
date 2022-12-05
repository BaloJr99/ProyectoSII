using Firebase.Database;
using Firebase.Database.Query;
using Newtonsoft.Json;
using ProyectoSII.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSII.Servicios
{
    public class QuejasService
    {
        private readonly FirebaseClient fc = new FirebaseClient("https://xamarinfirebase-178bd-default-rtdb.firebaseio.com/");
        public async Task<List<Quejas>> GetListQuejas()
        {
            var GetQuejas = (await fc.Child(StaticUsuario.NumControl).OnceAsync<Quejas>()).Select(items => new Quejas
            {
                Queja = items.Object.Queja,
                Apartado= items.Object.Apartado,
                Fecha = items.Object.Fecha
            }).ToList().OrderByDescending(i => i.Fecha);
            return GetQuejas.ToList();
        }

        public async Task<bool> AgregarQueja(Quejas queja)
        {
            var data = await fc.Child(StaticUsuario.NumControl).PostAsync(JsonConvert.SerializeObject(queja));
            if (string.IsNullOrEmpty(data.Key))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
