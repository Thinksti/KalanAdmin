using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace KalanBlazor.BL.Ventas.Timbrado.AdvansWS;

[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
[DebuggerStepThrough]
[SoapType(Namespace = "urn:advanswsdl")]
public class RespuestaValidarCertificado
{
    private string codeField;

    private string subCodeField;

    private string idField;

    private string messageField;

    public string Code
    {
        get
        {
            return codeField;
        }
        set
        {
            codeField = value;
        }
    }

    public string SubCode
    {
        get
        {
            return subCodeField;
        }
        set
        {
            subCodeField = value;
        }
    }

    public string ID
    {
        get
        {
            return idField;
        }
        set
        {
            idField = value;
        }
    }

    public string Message
    {
        get
        {
            return messageField;
        }
        set
        {
            messageField = value;
        }
    }
}
