using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contexto;

namespace KalanBlazor.BL.Permisos.AltaPermiso
{
    public class CargarPerfil
    {
        #region Perfiles Logica
        //CLASE PARA OBTENER LOS PERFILES
        public List<MostrarPerfil> MostrarPerfiles()
        {
            var KalanDB = new KalanDB(CadenaConexion);
            var mostrarPerfil = KalanDB.aspnetroles
                .Where(r => r.Activo == true)
                .OrderBy(r => r.Name)
                .Select(r => new MostrarPerfil
                {
                    Id = r.Id,
                    Nombre = r.Name,
                    Activo = r.Activo
                }).ToList();

            if (mostrarPerfil.Count == 0)
            {
                Console.WriteLine("No hay perfiles disponibles.");
            }
            else
            {
                //Console.WriteLine("Perfiles disponibles: " + mostrarPerfil.Count);
                // Aquí imprimes cada perfil
                //foreach (var perfil in mostrarPerfil)
                //{
                //    Console.WriteLine($"ID: {perfil.Id}, Nombre: {perfil.Nombre}, Activo: {perfil.Activo}");
                //}

            }
            return mostrarPerfil;
        }

        /// <summary>
        /// Constructor de la clase GestionPerfil.
        /// </summary>
        public CargarPerfil(string cadenaConexion)

        {
            CadenaConexion = cadenaConexion;
            DateTime fechaInicial = DateTime.Now;
            DateTime fechaFinal = DateTime.Now;
        }


        /// <summary>
        /// Clase que representa un perfil de usuario en el sistema.
        /// </summary>  
        public class MostrarPerfil
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
        #endregion

        /// <summary>
        /// Cadena de conexión a la base de datos.
        /// </summary>
        public string CadenaConexion { get; set; }
    }
}
