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
using System.Configuration;

namespace KalanBlazor.BL.Permisos.AltaPerfil
{
    public class InsertarPerfil
    {

        public static void Insertar(string cadenaConexion, string Name, string correo)
        {

            Console.WriteLine($"[LOG BACKEND] datos: Nombre={Name}, ");

            using var context = new KalanDB(cadenaConexion);

            var nuevoRol = new Shared.Kalan.Entidades.aspnetroles
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Activo = true,
                UsuarioCreacion = correo,
                FechaCreacion = DateTime.Now,
                UsuarioModifica = null,
                FechaModifica = null
            };

            context.aspnetroles.Add(nuevoRol);
            context.SaveChanges();
        }
    }
}
