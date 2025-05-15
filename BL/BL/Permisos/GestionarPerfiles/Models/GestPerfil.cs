using Amazon.Runtime.Internal.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared.Kalan.Contextos;

namespace KalanBlazor.BL.Permisos.GestionarPerfiles.Models
{
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
}
