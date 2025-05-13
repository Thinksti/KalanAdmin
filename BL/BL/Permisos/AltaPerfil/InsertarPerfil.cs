using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contextos;

namespace KalanBlazor.BL.Permisos.AltaPerfil
{
    public class InsertarPerfil
    {

        public static void Insertar(string cadenaConexion, string Name, string UsuarioCreacion)
        {
            using var context = new KalanDB(cadenaConexion);

            var nuevoRol = new Shared.Kalan.Entidades.aspnetroles
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Activo = true,
                UsuarioCreacion = UsuarioCreacion,
                FechaCreacion = DateTime.Now,
                UsuarioModifica = null,
                FechaModifica = DateTime.Now
            };

            context.aspnetroles.Add(nuevoRol);
            context.SaveChanges();
        }
    }
}
