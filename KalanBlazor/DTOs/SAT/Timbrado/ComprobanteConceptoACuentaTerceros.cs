namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteConceptoACuentaTerceros
{
	private string rfcACuentaTercerosField;

	private string nombreACuentaTercerosField;

	private string regimenFiscalACuentaTercerosField;

	private string domicilioFiscalACuentaTercerosField;

	public string RfcACuentaTerceros
	{
		get
		{
			return rfcACuentaTercerosField;
		}
		set
		{
			rfcACuentaTercerosField = value;
		}
	}

	public string NombreACuentaTerceros
	{
		get
		{
			return nombreACuentaTercerosField;
		}
		set
		{
			nombreACuentaTercerosField = value;
		}
	}

	public string RegimenFiscalACuentaTerceros
	{
		get
		{
			return regimenFiscalACuentaTercerosField;
		}
		set
		{
			regimenFiscalACuentaTercerosField = value;
		}
	}

	public string DomicilioFiscalACuentaTerceros
	{
		get
		{
			return domicilioFiscalACuentaTercerosField;
		}
		set
		{
			domicilioFiscalACuentaTercerosField = value;
		}
	}
}
