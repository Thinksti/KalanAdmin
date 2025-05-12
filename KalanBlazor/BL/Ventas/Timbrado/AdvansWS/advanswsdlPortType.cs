using System.CodeDom.Compiler;
using System.ServiceModel;
using System.Threading.Tasks;

namespace KalanBlazor.BL.Ventas.Timbrado.AdvansWS;

[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
[ServiceContract(Namespace = "urn:advanswsdl", ConfigurationName = "AdvansWS.advanswsdlPortType")]
public interface advanswsdlPortType
{
    [OperationContract(Action = "urn:advanswsdl#timbrar", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaTimbre> timbrarAsync(string credential, string cfdi);

    [OperationContract(Action = "urn:advanswsdl#validar", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaValidacion> validarAsync(string credential, string cfdi);

    [OperationContract(Action = "urn:advanswsdl#timbrarRetencion", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaTimbre> timbrarRetencionAsync(string credential, string xml);

    [OperationContract(Action = "urn:advanswsdl#timbrar", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaTimbre2> timbrar2Async(string credential, string cfdi);

    [OperationContract(Action = "urn:advanswsdl#timbrarRetencion2", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaTimbre2> timbrarRetencion2Async(string credential, string xml);

    [OperationContract(Action = "urn:advanswsdl#timbrar", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaTimbre> timbrar3Async(string credential, string cfdi);

    [OperationContract(Action = "urn:advanswsdl#cancelar", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaCancelacion> cancelarAsync(string credential, string rfc_emisor, string uuid, string motivo, string folio_sustitucion, string key, string cer);

    [OperationContract(Action = "urn:advanswsdl#cancelarRetencion", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaCancelacion> cancelarRetencionAsync(string credential, string rfc_emisor, string uuid, string motivo, string folio_sustitucion, string key, string cer);

    [OperationContract(Action = "urn:advanswsdl#cancelarPFXSync", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaCancelacion> cancelarPFXSyncAsync(string credential, string rfc_emisor, string uuid, string motivo, string folio_sustitucion, string pfx, string pfx_password);

    [OperationContract(Action = "urn:advanswsdl#consulta", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaConsulta> consultarAsync(string credential, string uuid);

    [OperationContract(Action = "urn:advanswsdl#consulta", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaConsulta> consultar_cfdiAsync(string credential, string uuid);

    [OperationContract(Action = "urn:advanswsdl#consultaHora", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaConsultaHora> consultar_horaAsync();

    [OperationContract(Action = "urn:advanswsdl#ValidarCertificado", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaValidarCertificado> validar_certificadoAsync(string credential, string cer);

    [OperationContract(Action = "urn:advanswsdl#ValidarCertificado", ReplyAction = "*")]
    [XmlSerializerFormat(Style = OperationFormatStyle.Rpc, SupportFaults = true, Use = OperationFormatUse.Encoded)]
    [return: MessageParameter(Name = "return")]
    Task<RespuestaValidarCertificado> confirmacionAsync(string credential, string emisor_rfc, string receptor_rfc, string email);
}
