using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteComplemento
{
	private List<XmlElement> anyField;

	[XmlAnyElement]
	public List<XmlElement> Any
	{
		get
		{
			return anyField;
		}
		set
		{
			anyField = value;
		}
	}

	public ComprobanteComplemento()
	{
		anyField = new List<XmlElement>();
	}
}
