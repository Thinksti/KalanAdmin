using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_clientes
{
    public string Id { get; set; } = null!;

    public string NombreCorto { get; set; } = null!;

    public string RazonSocial { get; set; } = null!;

    public string RFC { get; set; } = null!;

    public string? CodigoPostal { get; set; }

    public string? Direccion { get; set; }

    public string regimenfiscal_Id { get; set; } = null!;

    public string usocfdi_Id { get; set; } = null!;

    public string? planimpuestos_id { get; set; }

    public string? cuentacontable_id { get; set; }

    public bool Activo { get; set; }

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public string? ResidenciaFiscal { get; set; }

    public string? NumRegIdTrib { get; set; }

    public string? Municipio { get; set; }

    public string? Estado { get; set; }

    public virtual th_plan_impuestos? planimpuestos { get; set; }

    public virtual th_regimenfiscal regimenfiscal { get; set; } = null!;

    public virtual ICollection<th_cuentascobrar> th_cuentascobrar { get; set; } = new List<th_cuentascobrar>();

    public virtual ICollection<th_cuentascobraraplicaciones> th_cuentascobraraplicaciones { get; set; } = new List<th_cuentascobraraplicaciones>();

    public virtual ICollection<th_ingresos> th_ingresos { get; set; } = new List<th_ingresos>();

    public virtual ICollection<th_venta_factura> th_venta_factura { get; set; } = new List<th_venta_factura>();

    public virtual th_usocfdi usocfdi { get; set; } = null!;
}
