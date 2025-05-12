using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_concepto
{
    public int? Concepto_Id { get; set; }

    public string? ClaveProdServ { get; set; }

    public string? NoIdentificacion { get; set; }

    public decimal? Cantidad { get; set; }

    public string? ClaveUnidad { get; set; }

    public string? Descripcion { get; set; }

    public decimal? ValorUnitario { get; set; }

    public decimal? Importe { get; set; }

    public decimal? Descuento { get; set; }

    public int? Conceptos_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? Unidad { get; set; }

    public decimal? ObjetoImp { get; set; }
}
