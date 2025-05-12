using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace KalanBlazor.BL.Ventas.Timbrado.AdvansWS;

[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
[DebuggerStepThrough]
[SoapType(Namespace = "urn:advanswsdl")]
public class RespuestaConsultaHora
{
    private string horaField;

    public string Hora
    {
        get
        {
            return horaField;
        }
        set
        {
            horaField = value;
        }
    }
}
