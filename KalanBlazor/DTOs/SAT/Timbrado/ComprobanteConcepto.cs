using System.Collections.Generic;
using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteConcepto
{
	private ComprobanteConceptoImpuestos impuestosField;

	private ComprobanteConceptoACuentaTerceros aCuentaTercerosField;

	private List<ComprobanteConceptoInformacionAduanera> informacionAduaneraField;

	private List<ComprobanteConceptoCuentaPredial> cuentaPredialField;

	private ComprobanteConceptoComplementoConcepto complementoConceptoField;

	private List<ComprobanteConceptoParte> parteField;

	private string claveProdServField;

	private string noIdentificacionField;

	private decimal cantidadField;

	private string claveUnidadField;

	private string unidadField;

	private string descripcionField;

	private decimal valorUnitarioField;

	private decimal importeField;

	private string descuentoField;

	private string objetoImpField;

	public ComprobanteConceptoImpuestos Impuestos
	{
		get
		{
			return impuestosField;
		}
		set
		{
			impuestosField = value;
		}
	}

	[XmlIgnore]
	public ComprobanteConceptoACuentaTerceros ACuentaTerceros
	{
		get
		{
			return aCuentaTercerosField;
		}
		set
		{
			aCuentaTercerosField = value;
		}
	}

	[XmlIgnore]
	public List<ComprobanteConceptoInformacionAduanera> InformacionAduanera
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

	[XmlIgnore]
	public List<ComprobanteConceptoCuentaPredial> CuentaPredial
	{
		get
		{
			return cuentaPredialField;
		}
		set
		{
			cuentaPredialField = value;
		}
	}

	[XmlIgnore]
	public ComprobanteConceptoComplementoConcepto ComplementoConcepto
	{
		get
		{
			return complementoConceptoField;
		}
		set
		{
			complementoConceptoField = value;
		}
	}

	[XmlIgnore]
	public List<ComprobanteConceptoParte> Parte
	{
		get
		{
			return parteField;
		}
		set
		{
			parteField = value;
		}
	}

	[XmlAttribute]
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

	[XmlAttribute]
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

	[XmlAttribute]
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

	[XmlAttribute]
	public string ClaveUnidad
	{
		get
		{
			return claveUnidadField;
		}
		set
		{
			claveUnidadField = value;
		}
	}

	[XmlAttribute]
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

	[XmlAttribute]
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

	[XmlAttribute]
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

	[XmlAttribute]
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

	[XmlAttribute]
	public string Descuento
	{
		get
		{
			return descuentoField;
		}
		set
		{
			descuentoField = value;
		}
	}

	[XmlAttribute]
	public string ObjetoImp
	{
		get
		{
			return objetoImpField;
		}
		set
		{
			objetoImpField = value;
		}
	}

	public ComprobanteConcepto()
	{
		parteField = new List<ComprobanteConceptoParte>();
		complementoConceptoField = new ComprobanteConceptoComplementoConcepto();
		cuentaPredialField = new List<ComprobanteConceptoCuentaPredial>();
		informacionAduaneraField = new List<ComprobanteConceptoInformacionAduanera>();
		aCuentaTercerosField = new ComprobanteConceptoACuentaTerceros();
	}
}
