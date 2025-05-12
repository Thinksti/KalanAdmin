using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_ingresos_complemento_detalle
{
    public string Id { get; set; } = null!;

    public string complemento_id { get; set; } = null!;

    public int Consecutivo { get; set; }

    public string factura_id { get; set; } = null!;

    public decimal MontoPago { get; set; }

    public decimal SaldoInsoluto { get; set; }

    public string aplicacion_id { get; set; } = null!;

    public string tipocambio_id { get; set; } = null!;

    public string moneda_id { get; set; } = null!;

    public virtual th_cuentaspagaraplicaciones aplicacion { get; set; } = null!;

    public virtual th_ingresos_complemento complemento { get; set; } = null!;

    public virtual th_venta_factura factura { get; set; } = null!;

    public virtual th_monedas moneda { get; set; } = null!;

    public virtual th_tiposcambio tipocambio { get; set; } = null!;
}
