using System;
using System.Collections.Generic;

namespace Shared.Kalan.Entidades;

public partial class th_contabilidad_trabajo
{
    public string Id { get; set; } = null!;

    public int Asiento { get; set; }

    public DateTime Fecha { get; set; }

    public int Año { get; set; }

    public int Mes { get; set; }

    public string Origen { get; set; } = null!;

    public int Tipo { get; set; }

    public string? DocumentoOriginal { get; set; }

    public bool Activo { get; set; }

    public string moneda_Id { get; set; } = null!;

    public string tipocambio_Id { get; set; } = null!;

    public string UsuarioCreacion { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public string? UsuarioModifica { get; set; }

    public DateTime? FechaModifica { get; set; }

    public virtual th_monedas moneda { get; set; } = null!;

    public virtual ICollection<th_contabilidad_trabajo_detalle> th_contabilidad_trabajo_detalle { get; set; } = new List<th_contabilidad_trabajo_detalle>();

    public virtual th_tiposcambio tipocambio { get; set; } = null!;
}
