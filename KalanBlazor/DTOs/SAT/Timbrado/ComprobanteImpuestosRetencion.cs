using System.Xml.Serialization;

namespace KalanBlazor.DTOs.SAT.Timbrado;

public class ComprobanteImpuestosRetencion
{


    private string impuestoField;

    private decimal importeField;


    [XmlAttribute]
    public string Impuesto
    {
        get
        {
            return impuestoField;
        }
        set
        {
            impuestoField = value;
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
}
