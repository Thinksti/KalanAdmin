using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

[XmlType(AnonymousType = true, Namespace = "http://www.sat.gob.mx/cfd/4", IncludeInSchema = true)]
[XmlRoot(Namespace = "http://www.sat.gob.mx/cfd/4", IsNullable = false)]
public class Comprobante
{
    private ComprobanteInformacionGlobal informacionGlobalField;

    private ComprobanteCfdiRelacionados cfdiRelacionadosField;

    private ComprobanteEmisor emisorField;

    private ComprobanteReceptor receptorField;

    private List<ComprobanteConcepto> conceptosField;

    private ComprobanteImpuestos impuestosField;

    private ComprobanteComplemento? complementoField;

    private ComprobanteAddenda addendaField;

    private string versionField;

    private string serieField;

    private string folioField;

    private DateTime fechaField;

    private string selloField;

    private string formaPagoField;

    private string noCertificadoField;

    private string certificadoField;

    private string condicionesDePagoField;

    private decimal subTotalField;

    private string descuentoField;

    private string monedaField;

    private string tipoCambioField;

    private decimal totalField;

    private string tipoDeComprobanteField;

    private string exportacionField;

    private string metodoPagoField;

    private string lugarExpedicionField;

    private string confirmacionField;

    [XmlAttribute(AttributeName = "schemaLocation", Namespace = "http://www.w3.org/2001/XMLSchema-instance")]
    public string XsiSchemaLocation { get; set; }

    [XmlIgnore]
    public ComprobanteInformacionGlobal InformacionGlobal
    {
        get
        {
            return informacionGlobalField;
        }
        set
        {
            informacionGlobalField = value;
        }
    }

    [XmlElement]
    public ComprobanteCfdiRelacionados CfdiRelacionados
    {
        get
        {
            return cfdiRelacionadosField;
        }
        set
        {
            cfdiRelacionadosField = value;
        }
    }

    [XmlElement]
    public ComprobanteEmisor Emisor
    {
        get
        {
            return emisorField;
        }
        set
        {
            emisorField = value;
        }
    }

    [XmlElement]
    public ComprobanteReceptor Receptor
    {
        get
        {
            return receptorField;
        }
        set
        {
            receptorField = value;
        }
    }

    [XmlArrayItem("Concepto", IsNullable = false)]
    public List<ComprobanteConcepto> Conceptos
    {
        get
        {
            return conceptosField;
        }
        set
        {
            conceptosField = value;
        }
    }

    public ComprobanteImpuestos Impuestos
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

    [XmlElement]
    public ComprobanteComplemento? Complemento
    {
        get
        {
            return complementoField;
        }
        set
        {
            complementoField = value;
        }
    }

    [XmlIgnore]
    public ComprobanteAddenda Addenda
    {
        get
        {
            return addendaField;
        }
        set
        {
            addendaField = value;
        }
    }

    [XmlAttribute]
    public string Version
    {
        get
        {
            return versionField;
        }
        set
        {
            versionField = value;
        }
    }

    [XmlAttribute]
    public string Serie
    {
        get
        {
            return serieField;
        }
        set
        {
            serieField = value;
        }
    }

    [XmlAttribute]
    public string Folio
    {
        get
        {
            return folioField;
        }
        set
        {
            folioField = value;
        }
    }

    [XmlAttribute]
    public DateTime Fecha
    {
        get
        {
            return fechaField;
        }
        set
        {
            fechaField = value;
        }
    }

    [XmlAttribute]
    public string Sello
    {
        get
        {
            return selloField;
        }
        set
        {
            selloField = value;
        }
    }

    [XmlAttribute]
    public string FormaPago
    {
        get
        {
            return formaPagoField;
        }
        set
        {
            formaPagoField = value;
        }
    }

    [XmlAttribute]
    public string NoCertificado
    {
        get
        {
            return noCertificadoField;
        }
        set
        {
            noCertificadoField = value;
        }
    }

    [XmlAttribute]
    public string Certificado
    {
        get
        {
            return certificadoField;
        }
        set
        {
            certificadoField = value;
        }
    }

    [XmlAttribute]
    public string CondicionesDePago
    {
        get
        {
            return condicionesDePagoField;
        }
        set
        {
            condicionesDePagoField = value;
        }
    }

    [XmlAttribute]
    public decimal SubTotal
    {
        get
        {
            return subTotalField;
        }
        set
        {
            subTotalField = value;
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
    public string Moneda
    {
        get
        {
            return monedaField;
        }
        set
        {
            monedaField = value;
        }
    }

    [XmlAttribute]
    public string TipoCambio
    {
        get
        {
            return tipoCambioField;
        }
        set
        {
            tipoCambioField = value;
        }
    }

    [XmlAttribute]
    public decimal Total
    {
        get
        {
            return totalField;
        }
        set
        {
            totalField = value;
        }
    }

    [XmlAttribute]
    public string TipoDeComprobante
    {
        get
        {
            return tipoDeComprobanteField;
        }
        set
        {
            tipoDeComprobanteField = value;
        }
    }

    [XmlAttribute]
    public string Exportacion
    {
        get
        {
            return exportacionField;
        }
        set
        {
            exportacionField = value;
        }
    }

    [XmlAttribute]
    public string MetodoPago
    {
        get
        {
            return metodoPagoField;
        }
        set
        {
            metodoPagoField = value;
        }
    }

    [XmlAttribute]
    public string LugarExpedicion
    {
        get
        {
            return lugarExpedicionField;
        }
        set
        {
            lugarExpedicionField = value;
        }
    }

    [XmlIgnore]
    public string Confirmacion
    {
        get
        {
            return confirmacionField;
        }
        set
        {
            confirmacionField = value;
        }
    }

    public Comprobante()
    {
        addendaField = new ComprobanteAddenda();
        complementoField = new ComprobanteComplemento();
        conceptosField = new List<ComprobanteConcepto>();
        receptorField = new ComprobanteReceptor();
        emisorField = new ComprobanteEmisor();
        versionField = "4.0";
    }
}
