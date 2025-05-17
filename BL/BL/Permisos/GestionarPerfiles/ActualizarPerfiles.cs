using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contextos;
using KalanBlazor.BL.Permisos.GestionarPerfiles.Models;



namespace KalanBlazor.BL.Permisos.GestionarPerfiles
{
    public class ActualizarPerfiles
    {

        /// <summary>
        /// Método para obtener un perfil de usuario por su ID y actualizarlo mediante los valores que obtiene del frontend.
        /// </summary>
        public static class ActualizarPerfil
        {
            public static void Actualizar(string cadenaConexion, string Id, string nuevoNombre, bool Activo, string correoModifica)
            {

                Console.WriteLine($"[LOG BACKEND] Actualizando perfil: Id={Id}, Nombre={nuevoNombre}, Activo={Activo}");
                using var context = new KalanDB(cadenaConexion);

                // Buscar el rol existente
                var rolExistente = context.aspnetroles.FirstOrDefault(r => r.Id == Id);

                if (rolExistente != null)
                {
                    // Actualizar los campos
                    rolExistente.Name = nuevoNombre;
                    rolExistente.Activo = Activo; // Asignar el valor de Activo según sea necesario
                    rolExistente.UsuarioModifica = correoModifica;
                    rolExistente.FechaModifica = DateTime.Now;
                    //context.SaveChanges();
                    context.Entry(rolExistente).Property(r => r.Name).IsModified = true;
                    context.Entry(rolExistente).Property(r => r.Activo).IsModified = true;
                    context.Entry(rolExistente).Property(r => r.UsuarioModifica).IsModified = true;
                    context.Entry(rolExistente).Property(r => r.FechaModifica).IsModified = true;



                    int cambios = context.SaveChanges();
                    Console.WriteLine($"[LOG BACKEND] Registros modificados: {cambios}");
                }
                else
                {
                    // Puedes manejar el caso en el que no se encontró el rol
                    throw new Exception("Rol no encontrado.");
                }
            }
        }


        /// <summary>
        /// Constructor de la clase GestionPerfil.
        /// </summary>
        public ActualizarPerfiles(string cadenaConexion)

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
