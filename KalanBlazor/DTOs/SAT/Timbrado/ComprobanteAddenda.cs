using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteAddenda
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

	public ComprobanteAddenda()
	{
		anyField = new List<XmlElement>();
	}
}
