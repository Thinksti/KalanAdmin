using System.Collections.Generic;
using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteConceptoImpuestos
{
	private List<ComprobanteConceptoImpuestosTraslado> trasladosField;

	private List<ComprobanteConceptoImpuestosRetencion> retencionesField;

	[XmlArrayItem("Traslado", IsNullable = false)]
	public List<ComprobanteConceptoImpuestosTraslado> Traslados
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

    [XmlArrayItem("Retencion", IsNullable = false)]
    public List<ComprobanteConceptoImpuestosRetencion> Retenciones
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

	public ComprobanteConceptoImpuestos()
	{
		retencionesField = new List<ComprobanteConceptoImpuestosRetencion>();
		trasladosField = new List<ComprobanteConceptoImpuestosTraslado>();
	}
}
