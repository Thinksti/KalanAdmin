using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_parte
{
    public int Parte_Id { get; set; }

    public decimal? Cantidad { get; set; }

    public string? ClaveProdServ { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Importe { get; set; }

    public string? NoIdentificacion { get; set; }

    public string? Unidad { get; set; }

    public decimal? ValorUnitario { get; set; }

    public int? Concepto_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public int? PorCuentadeTerceros_Id { get; set; }
}
