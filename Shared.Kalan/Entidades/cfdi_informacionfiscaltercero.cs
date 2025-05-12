using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_informacionfiscaltercero
{
    public string? calle { get; set; }

    public decimal? codigoPostal { get; set; }

    public string? colonia { get; set; }

    public string? estado { get; set; }

    public string? municipio { get; set; }

    public string? pais { get; set; }

    public int? PorCuentadeTerceros_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? localidad { get; set; }

    public string? noExterior { get; set; }

    public string? noInterior { get; set; }
}
