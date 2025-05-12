using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteReceptor
{
	private string rfcField;

	private string nombreField;

	private string domicilioFiscalReceptorField;

	private string? residenciaFiscalField;

	private string? numRegIdTribField;

	private string regimenFiscalReceptorField;

	private string usoCFDIField;

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
	public string DomicilioFiscalReceptor
	{
		get
		{
			return domicilioFiscalReceptorField;
		}
		set
		{
			domicilioFiscalReceptorField = value;
		}
	}

	[XmlAttribute]
	public string? ResidenciaFiscal
	{
		get
		{
			if (string.IsNullOrEmpty(residenciaFiscalField))
			{
				return null;
			}
			return residenciaFiscalField;
		}
		set
		{
			residenciaFiscalField = value;
		}
	}

	[XmlAttribute]
	public string? NumRegIdTrib
	{
		get
		{
			if (string.IsNullOrEmpty(numRegIdTribField))
			{
				return null;
			}
			return numRegIdTribField;
		}
		set
		{
			numRegIdTribField = value;
		}
	}

	[XmlAttribute]
	public string RegimenFiscalReceptor
	{
		get
		{
			return regimenFiscalReceptorField;
		}
		set
		{
			regimenFiscalReceptorField = value;
		}
	}

	[XmlAttribute]
	public string UsoCFDI
	{
		get
		{
			return usoCFDIField;
		}
		set
		{
			usoCFDIField = value;
		}
	}
}
