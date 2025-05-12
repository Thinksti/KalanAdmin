using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_venta_factura_comercio_mercancias
{
    public string factura_Id { get; set; } = null!;

    public int Partida { get; set; }

    public string NoIdentificacion { get; set; } = null!;

    public string FraccionArancelaria { get; set; } = null!;

    public decimal CantidadAduana { get; set; }

    public string UnidadAduana { get; set; } = null!;

    public decimal ValorUnitarioAduana { get; set; }

    public decimal ValorDolares { get; set; }
}
