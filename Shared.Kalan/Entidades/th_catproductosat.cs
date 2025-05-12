using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_catproductosat
{
    public string Id { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<th_articulos> th_articulos { get; set; } = new List<th_articulos>();
}
