//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace KalanBlazor.BL.Permisos.AltaPermiso
//{
//    public class CargarSubmodulo
//    {


//        #region Mostrar los Submodulos dependiendo el Id de un Modulo

//        public List<MostrarSubModulo> MostrarSubmodulosPorModulo(string moduloId)
//        {
//            Console.WriteLine($"[LOG BACKEND] Actualizando Modulo ID: Id={moduloId}");
//            var KalanDB = new KalanDB(CadenaConexion);

//            var submodulos = KalanDB.aspnetsubmodulos
//                .Where(s => s.modulo_id == moduloId && s.Activo == true)
//                .OrderBy(s => s.SubModulo)
//                .Select(s => new MostrarSubModulo
//                {
//                    Id = s.Id,
//                    SubModulo = s.SubModulo,
//                    Activo = s.Activo
//                })
//                .ToList();

//            if (submodulos.Count == 0)
//            {
//                Console.WriteLine("No hay SubModulos disponibles.");
//            }
//            else
//            {
//                Console.WriteLine("SubModulos disponibles: " + submodulos.Count);
//                //foreach (var sbmodulo in submodulos)
//                //{
//                //    Console.WriteLine($"ID: {sbmodulo.Id}, Nombre: {sbmodulo.SubModulo}, Activo: {sbmodulo.Activo}");
//                //}
//            }


//            return submodulos;
//        }




//        public class MostrarSubModulo
//        {
//            public string Id { get; set; }
//            public string modulo_id { get; set; }
//            public string SubModulo { get; set; }
//            public bool Activo { get; set; }
//            public string UsuarioCreacion { get; set; } = null!;
//            public DateTime FechaCreacion { get; set; }
//            public string? UsuarioModifica { get; set; }
//            public DateTime? FechaModifica { get; set; }
//        }


//        /// <summary>
//        /// Cadena de conexión a la base de datos.
//        /// </summary>
//        public string CadenaConexion { get; set; }

//        #endregion
//    }
//}
