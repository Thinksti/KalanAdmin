using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class cfdi_receptor_1
{
    public string? Antigüedad { get; set; }

    public decimal? Banco { get; set; }

    public string? ClaveEntFed { get; set; }

    public string? Curp { get; set; }

    public string? Departamento { get; set; }

    public string? FechaInicioRelLaboral { get; set; }

    public decimal? NumEmpleado { get; set; }

    public decimal? NumSeguridadSocial { get; set; }

    public decimal? PeriodicidadPago { get; set; }

    public string? Puesto { get; set; }

    public decimal? RiesgoPuesto { get; set; }

    public decimal? SalarioBaseCotApor { get; set; }

    public decimal? SalarioDiarioIntegrado { get; set; }

    public string? Sindicalizado { get; set; }

    public decimal? TipoContrato { get; set; }

    public decimal? TipoJornada { get; set; }

    public decimal? TipoRegimen { get; set; }

    public int? Nomina_Id { get; set; }

    public Guid? pkUUID { get; set; }

    public string? CuentaBancaria { get; set; }
}
