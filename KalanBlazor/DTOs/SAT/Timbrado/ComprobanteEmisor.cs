using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteEmisor
{
	private string rfcField;

	private string nombreField;

	private string regimenFiscalField;

	private string facAtrAdquirenteField;

	[XmlAttribute]
	public string Rfc
	{
		get
		{
			return rfcField;
		}
		set
		{
			rfcField = value;
		}
	}

	[XmlAttribute]
	public string Nombre
	{
		get
		{
			return nombreField;
		}
		set
		{
			nombreField = value;
		}
	}

	[XmlAttribute]
	public string RegimenFiscal
	{
		get
		{
			return regimenFiscalField;
		}
		set
		{
			regimenFiscalField = value;
		}
	}

	[XmlIgnore]
	public string FacAtrAdquirente
	{
		get
		{
			return facAtrAdquirenteField;
		}
		set
		{
			facAtrAdquirenteField = value;
		}
	}
}
