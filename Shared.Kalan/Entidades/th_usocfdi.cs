using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_usocfdi
{
    public string Id { get; set; } = null!;

    public string UsoCFDi { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public string? c_UsoCFDI_Descripción_activo_usuario { get; set; }

    public string? Id_UsoCFDi_Activo_UsuarioCreacion_ { get; set; }

    public virtual ICollection<th_clientes> th_clientes { get; set; } = new List<th_clientes>();

    public virtual ICollection<th_proveedores> th_proveedores { get; set; } = new List<th_proveedores>();
}
