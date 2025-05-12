using System.Collections.Generic;
using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteCfdiRelacionados
{
	private List<ComprobanteCfdiRelacionadosCfdiRelacionado> cfdiRelacionadoField;

	private string tipoRelacionField;

	[XmlElement("CfdiRelacionado")]
	public List<ComprobanteCfdiRelacionadosCfdiRelacionado> CfdiRelacionado
	{
		get
		{
			return cfdiRelacionadoField;
		}
		set
		{
			cfdiRelacionadoField = value;
		}
	}

	[XmlAttribute]
	public string TipoRelacion
	{
		get
		{
			return tipoRelacionField;
		}
		set
		{
			tipoRelacionField = value;
		}
	}

	public ComprobanteCfdiRelacionados()
	{
		cfdiRelacionadoField = new List<ComprobanteCfdiRelacionadosCfdiRelacionado>();
	}
}
