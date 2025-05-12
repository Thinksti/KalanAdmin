using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class aspnetrolreporte
{
    public string IdRol { get; set; } = null!;

    public string IdReporte { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual aspnetreportes IdReporteNavigation { get; set; } = null!;

    public virtual aspnetroles IdRolNavigation { get; set; } = null!;
}
