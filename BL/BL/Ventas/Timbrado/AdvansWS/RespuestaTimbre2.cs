using System.CodeDom.Compiler;
using System.Diagnostics;
using System.Xml.Serialization;

namespace KalanBlazor.BL.Ventas.Timbrado.AdvansWS;

[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
[DebuggerStepThrough]
[SoapType(Namespace = "urn:advanswsdl")]
public class RespuestaTimbre2
{
    private string codeField;

    private string subCodeField;

    private string messageField;

    private string cFDIField;

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

    public string CFDI
    {
        get
        {
            return cFDIField;
        }
        set
        {
            cFDIField = value;
        }
    }
}
