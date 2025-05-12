using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_cartaporte
{
    public int CartaPorte_Id { get; set; }

    public string? Version { get; set; }

    public string? TranspInternac { get; set; }

    public decimal? TotalDistRec { get; set; }

    public int? Complemento_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? PaisOrigenDestino { get; set; }

    public string? EntradaSalidaMerc { get; set; }

    public decimal? ViaEntradaSalida { get; set; }

    public string? IdCCP { get; set; }

    public string? RegimenAduanero { get; set; }
}
