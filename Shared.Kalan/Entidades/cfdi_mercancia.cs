using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_mercancia
{
    public decimal? BienesTransp { get; set; }

    public string? Descripcion { get; set; }

    public decimal? Cantidad { get; set; }

    public string? ClaveUnidad { get; set; }

    public string? Unidad { get; set; }

    public string? MaterialPeligroso { get; set; }

    public decimal? PesoEnKg { get; set; }

    public decimal? ValorMercancia { get; set; }

    public string? Moneda { get; set; }

    public int? Mercancias_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public int? Mercancia_Id { get; set; }

    public decimal? FraccionArancelaria { get; set; }

    public decimal? CveMaterialPeligroso { get; set; }

    public string? Embalaje { get; set; }

    public string? DescripEmbalaje { get; set; }

    public string? Dimensiones { get; set; }

    public decimal? TipoMateria { get; set; }

    public string? DescripcionMateria { get; set; }

    public string? UnidadAduana { get; set; }

    public string? ValorUnitarioAduana { get; set; }

    public string? ValorDolares { get; set; }
}
