using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_contabilidad_trabajo_detalle
{
    public string Id { get; set; } = null!;

    public string encabezado_Id { get; set; } = null!;

    public string cuenta_Id { get; set; } = null!;

    public string? TipoConcepto { get; set; }

    public decimal Debito { get; set; }

    public decimal Credito { get; set; }

    public decimal DebitoMF { get; set; }

    public decimal CreditoMF { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual th_contabilidad_cuenta cuenta { get; set; } = null!;

    public virtual th_contabilidad_trabajo encabezado { get; set; } = null!;
}
