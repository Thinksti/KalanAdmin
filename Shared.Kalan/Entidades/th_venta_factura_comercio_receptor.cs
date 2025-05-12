using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_venta_factura_comercio_receptor
{
    public string factura_Id { get; set; } = null!;

    public string? NumRegIdTrib { get; set; }

    public string Calle { get; set; } = null!;

    public string? Municipio { get; set; }

    public string? Estado { get; set; }

    public string? Pais { get; set; }

    public string? CodigoPostal { get; set; }
}
