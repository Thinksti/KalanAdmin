using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_compensacionsaldosafavor
{
    public decimal? Año { get; set; }

    public decimal? RemanenteSalFav { get; set; }

    public decimal? SaldoAFavor { get; set; }

    public int? OtroPago_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
