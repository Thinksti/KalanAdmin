using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_venta_factura_comercio
{
    public string factura_Id { get; set; } = null!;

    public string Version { get; set; } = null!;

    public string ClaveDePedimento { get; set; } = null!;

    public int CertificadoOrigen { get; set; }

    public string Incoterm { get; set; } = null!;

    public decimal TotalUSD { get; set; }

    public decimal TipoCambioUSD { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }
}
