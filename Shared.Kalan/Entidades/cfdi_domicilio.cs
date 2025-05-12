using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_domicilio
{
    public string? Calle { get; set; }

    public string? NumeroExterior { get; set; }

    public string? Colonia { get; set; }

    public string? Municipio { get; set; }

    public string? Estado { get; set; }

    public string? Pais { get; set; }

    public decimal? CodigoPostal { get; set; }

    public int? Ubicacion_Id { get; set; }

    public int? TiposFigura_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? Localidad { get; set; }

    public string? NumeroInterior { get; set; }

    public string? Referencia { get; set; }

    public int? Receptor_Id { get; set; }
}
