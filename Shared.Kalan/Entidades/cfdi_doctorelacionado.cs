using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_doctorelacionado
{
    public string? IdDocumento { get; set; }

    public string? Serie { get; set; }

    public string? Folio { get; set; }

    public string? MonedaDR { get; set; }

    public string? MetodoDePagoDR { get; set; }

    public decimal? NumParcialidad { get; set; }

    public decimal? ImpSaldoAnt { get; set; }

    public decimal? ImpPagado { get; set; }

    public decimal? ImpSaldoInsoluto { get; set; }

    public int? Pago_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public int? DoctoRelacionado_Id { get; set; }

    public decimal? EquivalenciaDR { get; set; }

    public decimal? ObjetoImpDR { get; set; }

    public decimal? TipoCambioDR { get; set; }
}
