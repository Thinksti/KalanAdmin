using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_condicionescredito
{
    public string Id { get; set; } = null!;

    public string Condicion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int Dias { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<th_venta_factura> th_venta_factura { get; set; } = new List<th_venta_factura>();
}
