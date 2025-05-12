using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_proveedores
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

    public virtual th_plan_impuestos? planimpuestos { get; set; }

    public virtual th_regimenfiscal regimenfiscal { get; set; } = null!;

    public virtual ICollection<th_articulos_proveedor> th_articulos_proveedor { get; set; } = new List<th_articulos_proveedor>();

    public virtual ICollection<th_cuentaspagar> th_cuentaspagar { get; set; } = new List<th_cuentaspagar>();

    public virtual ICollection<th_cuentaspagaraplicaciones> th_cuentaspagaraplicaciones { get; set; } = new List<th_cuentaspagaraplicaciones>();

    public virtual ICollection<th_egresos> th_egresos { get; set; } = new List<th_egresos>();

    public virtual th_usocfdi usocfdi { get; set; } = null!;
}
