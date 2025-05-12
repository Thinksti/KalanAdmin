using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_conceptoaddenda
{
    public decimal? cantidad { get; set; }

    public decimal? importe { get; set; }

    public decimal? importeDescuento { get; set; }

    public decimal? noIdentificacion { get; set; }

    public decimal? porcenDescuento { get; set; }

    public decimal? valorUnitario { get; set; }

    public int? ConceptosAddenda_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
