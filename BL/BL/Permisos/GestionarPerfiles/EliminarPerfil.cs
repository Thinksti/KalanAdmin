using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contextos;

namespace KalanBlazor.BL.Permisos.GestionarPerfiles
{
    public class EliminarPerfil
    {

        /// <summary>
        /// Metodo para eliminar un perfil de usuario.
        /// </summary>
        public bool EliminarPerfilPorID(string Id)
        {
            //Console.WriteLine($"[LOG BACKEND] Eliminar perfil: Id={Id}");
            var KalanDB = new KalanDB(CadenaConexion);
            var perfil = KalanDB.aspnetroles.FirstOrDefault(r => r.Id == Id);
            if (perfil != null)
            {
                KalanDB.aspnetroles.Remove(perfil);
                KalanDB.SaveChanges();
                return true;
            }
            return false;
        }

        /// <summary>
        /// Constructor de la clase GestionPerfil.
        /// </summary>
        public EliminarPerfil(string cadenaConexion)

        {
            CadenaConexion = cadenaConexion;
            DateTime fechaInicial = DateTime.Now;
            DateTime fechaFinal = DateTime.Now;
        }


        /// <summary>
        /// Clase que representa un perfil de usuario en el sistema.
        /// </summary>  
        public class GestPerfil
        {
            public string Id { get; set; }
            public int Numero { get; set; }
            public string Nombre { get; set; }
            public bool Activo { get; set; }
            public string UsuarioCreacion { get; set; } = null!;

            public DateTime FechaCreacion { get; set; }

            public string? UsuarioModifica { get; set; }

            public DateTime? FechaModifica { get; set; }
        }


        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        public string CadenaConexion { get; set; }
    }
}

