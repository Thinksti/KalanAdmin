using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_receptor
{
    public string? Rfc { get; set; }

    public string? Nombre { get; set; }

    public string? UsoCFDI { get; set; }

    public int? Comprobante_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public decimal? DomicilioFiscalReceptor { get; set; }

    public string? RegimenFiscalReceptor { get; set; }

    public string? ResidenciaFiscal { get; set; }

    public string? NumRegIdTrib { get; set; }

    public string? Curp { get; set; }

    public string? NumSeguridadSocial { get; set; }

    public string? FechaInicioRelLaboral { get; set; }

    public string? Antigüedad { get; set; }

    public string? TipoContrato { get; set; }

    public string? Sindicalizado { get; set; }

    public string? TipoJornada { get; set; }

    public string? TipoRegimen { get; set; }

    public string? NumEmpleado { get; set; }

    public string? Departamento { get; set; }

    public string? Puesto { get; set; }

    public string? RiesgoPuesto { get; set; }

    public string? PeriodicidadPago { get; set; }

    public string? SalarioBaseCotApor { get; set; }

    public string? SalarioDiarioIntegrado { get; set; }

    public string? ClaveEntFed { get; set; }

    public int? Nomina_Id { get; set; }

    public int? Receptor_Id { get; set; }

    public int? ComercioExterior_Id { get; set; }
}
