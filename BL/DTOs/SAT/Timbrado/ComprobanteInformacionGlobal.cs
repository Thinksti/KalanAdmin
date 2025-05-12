namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteInformacionGlobal
{
	private string periodicidadField;

	private string mesesField;

	private short añoField;

	public string Periodicidad
	{
		get
		{
			return periodicidadField;
		}
		set
		{
			periodicidadField = value;
		}
	}

	public string Meses
	{
		get
		{
			return mesesField;
		}
		set
		{
			mesesField = value;
		}
	}

	public short Año
	{
		get
		{
			return añoField;
		}
		set
		{
			añoField = value;
		}
	}
}
