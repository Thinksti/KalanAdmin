using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contextos;

namespace KalanBlazor.BL.Permisos.GestionarPerfiles
{
    public class CargarPerfiles
    {

        /// <summary>
        /// Método para obtener la lista de perfiles de usuario.
        /// </summary>
        public List<GestPerfil> ResGestionPerfiles()
        {
            var KalanDB = new KalanDB(CadenaConexion);
            var gestPerfil = KalanDB.aspnetroles
                .Where(r => r.Name != null)
                .Select(r => new GestPerfil
                {
                    Id = r.Id,
                    Nombre = r.Name,
                    Activo = r.Activo
                }).ToList();
            for (int i = 0; i < gestPerfil.Count; i++)
            {
                gestPerfil[i].Numero = i + 1; // Empezar desde 1
            }
            if (gestPerfil.Count == 0)
            {
                Console.WriteLine("No hay perfiles disponibles.");
            }
            else
            {
                Console.WriteLine("Perfiles disponibles: " + gestPerfil.Count);
            }
            return gestPerfil;
        }



        /// <summary>
        /// Constructor de la clase GestionPerfil.
        /// </summary>
        public CargarPerfiles(string cadenaConexion)

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
