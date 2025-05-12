using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Kalan.Componentes
{
    public class ItemMenu
    {
        public string URLItem { get; set; }
        public string NombreItem { get; set; }
        public string Icono { get; set; }
        public bool Activo { get; set; }
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
