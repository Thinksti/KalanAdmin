using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_formapago
{
    public string Id { get; set; } = null!;

    public string FormaPago { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<th_egresos> th_egresos { get; set; } = new List<th_egresos>();

    public virtual ICollection<th_ingresos> th_ingresos { get; set; } = new List<th_ingresos>();
}
