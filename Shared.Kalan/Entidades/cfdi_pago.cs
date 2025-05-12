using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_pago
{
    public int? Pago_Id { get; set; }

    public string? FechaPago { get; set; }

    public decimal? FormaDePagoP { get; set; }

    public string? MonedaP { get; set; }

    public decimal? Monto { get; set; }

    public int? Pagos_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? CtaBeneficiario { get; set; }

    public string? NumOperacion { get; set; }

    public string? RfcEmisorCtaBen { get; set; }

    public decimal? TipoCambioP { get; set; }

    public string? RfcEmisorCtaOrd { get; set; }

    public string? CtaOrdenante { get; set; }

    public string? NomBancoOrdExt { get; set; }

    public decimal? TipoCadPago { get; set; }

    public string? CadPago { get; set; }

    public string? CertPago { get; set; }

    public string? SelloPago { get; set; }
}
