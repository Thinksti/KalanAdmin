using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteCfdiRelacionadosCfdiRelacionado
{
	private string uUIDField;

	[XmlAttribute]
	public string UUID
	{
		get
		{
			return uUIDField;
		}
		set
		{
			uUIDField = value;
		}
	}
}
