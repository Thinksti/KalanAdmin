//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using Shared.Kalan.Contextos;

//namespace KalanBlazor.BL.Permisos.AltaPermiso
//{
//    public class CargarModulo
//    {

//        #region Logica para los Modulos
//        public List<MostrarModulo> MostrarModulos()
//        {
//            var KalanDB = new KalanDB(CadenaConexion);
//            var mostrarModulos = KalanDB.aspnetmodulos
//                .Where(r => r.Activo == true)
//                .OrderBy(r => r.Modulo)
//                .Select(r => new MostrarModulo
//                {
//                    Id = r.Id,
//                    Modulo = r.Modulo,
//                    Activo = r.Activo
//                }).ToList();

//            if (mostrarModulos.Count == 0)
//            {
//                Console.WriteLine("No hay perfiles disponibles.");
//            }
//            else
//            {
//                //Console.WriteLine("Perfiles disponibles: " + mostrarModulos.Count);
//                //foreach (var modulo in mostrarModulos)
//                //{
//                //    Console.WriteLine($"ID: {modulo.Id}, Nombre: {modulo.Modulo}, Activo: {modulo.Activo}");
//                //}
//            }
//            return mostrarModulos;
//        }


//        public CargarModulo(string cadenaConexion)

//        {
//            CadenaConexion = cadenaConexion;
//            DateTime fechaInicial = DateTime.Now;
//            DateTime fechaFinal = DateTime.Now;
//        }

//        public class MostrarModulo
//        {
//            public string Id { get; set; }
//            public string Modulo { get; set; }
//            public bool Activo { get; set; }
//            public string UsuarioCreacion { get; set; } = null!;
//            public DateTime FechaCreacion { get; set; }
//            public string? UsuarioModifica { get; set; }
//            public DateTime? FechaModifica { get; set; }
//        }

//        #endregion


//        /// <summary>
//        /// Cadena de conexión a la base de datos.
//        /// </summary>
//        public string CadenaConexion { get; set; }
//    }
//}
