using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_encabezado
{
    public decimal? Almacenaje { get; set; }

    public decimal? BultosPiezas { get; set; }

    public string? Cajero { get; set; }

    public string? FechaIngreso { get; set; }

    public string? FechaSalidaMercancia { get; set; }

    public string? Folio { get; set; }

    public string? GuiaHouse { get; set; }

    public decimal? GuiaMaster { get; set; }

    public string? Nombre { get; set; }

    public string? Observaciones { get; set; }

    public string? Operacion { get; set; }

    public decimal? Patente { get; set; }

    public string? Pedimento { get; set; }

    public decimal? PesoKG { get; set; }

    public string? RFC { get; set; }

    public string? Salida { get; set; }

    public string? Serie { get; set; }

    public decimal? TipoCambio { get; set; }

    public decimal? TotalDias { get; set; }

    public decimal? ValorMerc { get; set; }

    public string? Volante { get; set; }

    public string? RegIngreso { get; set; }

    public int? talmaAddenda_Id { get; set; }

    public Guid? pkUUID { get; set; }
}
