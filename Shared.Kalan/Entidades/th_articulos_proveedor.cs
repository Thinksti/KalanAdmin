using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_articulos_proveedor
{
    public string Id { get; set; } = null!;

    public string articulo_Id { get; set; } = null!;

    public string proveedor_Id { get; set; } = null!;

    public decimal CostoActual { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual th_articulos articulo { get; set; } = null!;

    public virtual th_proveedores proveedor { get; set; } = null!;
}
