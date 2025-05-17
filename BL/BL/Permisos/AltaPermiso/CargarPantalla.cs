using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contexto;

namespace KalanBlazor.BL.Permisos.AltaPermiso
{
    public class CargarPantalla
    {



        #region Mostrar Pantallas dependiendo el Id de un Submodulo

        public List<MostrarPantalla> MostrarPantallaPorSubModulo(string submoduloId)
        {
            Console.WriteLine($"[LOG BACKEND] Actualizando SubModulo ID: Id={submoduloId}");
            var KalanDB = new KalanDB(CadenaConexion);

            var pantallas = KalanDB.aspnetpantallas
                .Where(p => p.submodulo_id == submoduloId && p.Activo == true)
                .OrderBy(p => p.Pantalla)
                .Select(p => new MostrarPantalla
                {
                    Id = p.Id,
                    Pantalla = p.Pantalla,
                    DireccionURL = p.DireccionURL,
                    Activo = p.Activo
                })
                .ToList();

            if (pantallas.Count == 0)
            {
                Console.WriteLine("No hay pantallas disponibles.");
            }
            else
            {
                Console.WriteLine("Pantallas disponibles: " + pantallas.Count);
                foreach (var listaPantallas in pantallas)
                {
                    Console.WriteLine($"ID: {listaPantallas.Id}, Nombre: {listaPantallas.Pantalla}, DireccionURL: {listaPantallas.DireccionURL}, Activo: {listaPantallas.Activo}");
                }
            }


            return pantallas;
        }

        public CargarPantalla(string cadenaConexion)

        {
            CadenaConexion = cadenaConexion;
            DateTime fechaInicial = DateTime.Now;
            DateTime fechaFinal = DateTime.Now;
        }
        public class MostrarPantalla
        {
            public string Id { get; set; }
            public string submodulo_id { get; set; }
            public string Pantalla { get; set; }
            public bool Activo { get; set; }
            public string DireccionURL { get; set; }
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
