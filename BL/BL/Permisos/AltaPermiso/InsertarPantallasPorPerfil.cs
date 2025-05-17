using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contexto;

namespace KalanBlazor.BL.Permisos.AltaPermiso
{
    public class InsertarPantallasPorPerfil
    {
        #region Guardar el Permiso en la base de datos

            public static void InsertarRolPantalla(string cadenaConexion, string IdPerfil, string IdPantalla)
            {
                Console.WriteLine($"[LOG BACKEND] Actualizando perfil: IdPerfil={IdPerfil}, IdPantalla={IdPantalla}");
                using var context = new KalanDB(cadenaConexion);

                var nuevoPantallaPorPerfil = new Shared.Kalan.Entidades.aspnetrolpantalla
                {
                    Id = Guid.NewGuid().ToString(),
                    roles_id = IdPerfil,
                    pantallas_id = IdPantalla,
                    Activo = true,
                    UsuarioCreacion = "gera@gmail.com",
                    FechaCreacion = DateTime.Now,
                    UsuarioModifica = null,
                    FechaModifica = null
                };

                context.aspnetrolpantalla.Add(nuevoPantallaPorPerfil);
                context.SaveChanges();
            }

        #endregion

        public InsertarPantallasPorPerfil(string cadenaConexion)

        {
            CadenaConexion = cadenaConexion;
            DateTime fechaInicial = DateTime.Now;
            DateTime fechaFinal = DateTime.Now;
        }

        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        public string CadenaConexion { get; set; }
    }
}
