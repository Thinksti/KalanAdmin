using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_mercancias
{
    public int Mercancias_Id { get; set; }

    public decimal? PesoBrutoTotal { get; set; }

    public string? UnidadPeso { get; set; }

    public decimal? NumTotalMercancias { get; set; }

    public int? CartaPorte_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public decimal? PesoNetoTotal { get; set; }
}
