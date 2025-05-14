using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml.Office2010.Excel;
using DocumentFormat.OpenXml.Wordprocessing;
using Shared.Kalan.Contextos;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace KalanBlazor.BL.Permisos.AltaPerfil
{
    public class InsertarPerfil
    {

        public static void Insertar(string cadenaConexion, string Name, string UsuarioCreacion)
        {
            Console.WriteLine($"[LOG BACKEND] Datos para insertar en perfil: Name={Name}, UsuarioCreacion={UsuarioCreacion}");
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
