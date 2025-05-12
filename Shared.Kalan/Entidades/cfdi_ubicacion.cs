using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_ubicacion
{
    public int Ubicacion_Id { get; set; }

    public string? TipoUbicacion { get; set; }

    public string? RFCRemitenteDestinatario { get; set; }

    public string? NombreRemitenteDestinatario { get; set; }

    public string? FechaHoraSalidaLlegada { get; set; }

    public decimal? DistanciaRecorrida { get; set; }

    public int? Ubicaciones_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? IDUbicacion { get; set; }

    public string? NumRegIdTrib { get; set; }

    public string? ResidenciaFiscal { get; set; }
}
