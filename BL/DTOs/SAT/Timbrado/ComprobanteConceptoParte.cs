using System.Collections.Generic;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteConceptoParte
{
	private List<ComprobanteConceptoParteInformacionAduanera> informacionAduaneraField;

	private string claveProdServField;

	private string noIdentificacionField;

	private decimal cantidadField;

	private string unidadField;

	private string descripcionField;

	private decimal valorUnitarioField;

	private decimal importeField;

	public List<ComprobanteConceptoParteInformacionAduanera> InformacionAduanera
	{
		get
		{
			return informacionAduaneraField;
		}
		set
		{
			informacionAduaneraField = value;
		}
	}

	public string ClaveProdServ
	{
		get
		{
			return claveProdServField;
		}
		set
		{
			claveProdServField = value;
		}
	}

	public string NoIdentificacion
	{
		get
		{
			return noIdentificacionField;
		}
		set
		{
			noIdentificacionField = value;
		}
	}

	public decimal Cantidad
	{
		get
		{
			return cantidadField;
		}
		set
		{
			cantidadField = value;
		}
	}

	public string Unidad
	{
		get
		{
			return unidadField;
		}
		set
		{
			unidadField = value;
		}
	}

	public string Descripcion
	{
		get
		{
			return descripcionField;
		}
		set
		{
			descripcionField = value;
		}
	}

	public decimal ValorUnitario
	{
		get
		{
			return valorUnitarioField;
		}
		set
		{
			valorUnitarioField = value;
		}
	}

	public decimal Importe
	{
		get
		{
			return importeField;
		}
		set
		{
			importeField = value;
		}
	}

	public ComprobanteConceptoParte()
	{
		informacionAduaneraField = new List<ComprobanteConceptoParteInformacionAduanera>();
	}
}
