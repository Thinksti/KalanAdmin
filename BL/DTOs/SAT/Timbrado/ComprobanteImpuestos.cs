using System.Collections.Generic;
using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteImpuestos
{
	private List<ComprobanteImpuestosRetencion> retencionesField;

	private List<ComprobanteImpuestosTraslado> trasladosField;

	private string? totalImpuestosRetenidosField;

	private string? totalImpuestosTrasladadosField;

    [XmlArrayItem("Retencion", IsNullable = false)]
    public List<ComprobanteImpuestosRetencion> Retenciones
	{
		get
		{
			return retencionesField;
		}
		set
		{
			retencionesField = value;
		}
	}

	[XmlArrayItem("Traslado", IsNullable = false)]
	public List<ComprobanteImpuestosTraslado> Traslados
	{
		get
		{
			return trasladosField;
		}
		set
		{
			trasladosField = value;
		}
	}

	[XmlAttribute]
	public string? TotalImpuestosRetenidos
	{
		get
		{
			if (totalImpuestosRetenidosField == "")
			{
				return null;
			}
			return totalImpuestosRetenidosField;
		}
		set
		{
			totalImpuestosRetenidosField = value;
		}
	}

	[XmlAttribute]
	public string? TotalImpuestosTrasladados
	{
		get
		{
			if (totalImpuestosTrasladadosField == "")
			{
				return null;
			}
			return totalImpuestosTrasladadosField;
		}
		set
		{
			totalImpuestosTrasladadosField = value;
		}
	}

	public ComprobanteImpuestos()
	{
		trasladosField = new List<ComprobanteImpuestosTraslado>();
		retencionesField = new List<ComprobanteImpuestosRetencion>();
	}
}
