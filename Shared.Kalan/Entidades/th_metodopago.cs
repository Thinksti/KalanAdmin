using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_metodopago
{
    public string Id { get; set; } = null!;

    public string MetodoPago { get; set; } = null!;

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual ICollection<th_cuentascobrar> th_cuentascobrar { get; set; } = new List<th_cuentascobrar>();

    public virtual ICollection<th_cuentaspagar> th_cuentaspagar { get; set; } = new List<th_cuentaspagar>();

    public virtual ICollection<th_venta_factura> th_venta_factura { get; set; } = new List<th_venta_factura>();
}
