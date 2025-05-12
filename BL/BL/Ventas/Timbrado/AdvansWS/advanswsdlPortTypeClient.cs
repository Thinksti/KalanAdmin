using System;
using System.CodeDom.Compiler;
using System.Diagnostics;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Threading.Tasks;
using System.Xml;

namespace KalanBlazor.BL.Ventas.Timbrado.AdvansWS;

[DebuggerStepThrough]
[GeneratedCode("Microsoft.Tools.ServiceModel.Svcutil", "2.0.3")]
public class advanswsdlPortTypeClient : ClientBase<advanswsdlPortType>, advanswsdlPortType
{
    public enum EndpointConfiguration
    {
        advanswsdlPort
    }

    public advanswsdlPortTypeClient()
        : base(GetDefaultBinding(), GetDefaultEndpointAddress())
    {
        Endpoint.Name = EndpointConfiguration.advanswsdlPort.ToString();
    }

    public advanswsdlPortTypeClient(EndpointConfiguration endpointConfiguration)
        : base(GetBindingForEndpoint(endpointConfiguration), GetEndpointAddress(endpointConfiguration))
    {
        Endpoint.Name = endpointConfiguration.ToString();
    }

    public advanswsdlPortTypeClient(EndpointConfiguration endpointConfiguration, string remoteAddress)
        : base(GetBindingForEndpoint(endpointConfiguration), new EndpointAddress(remoteAddress))
    {
        Endpoint.Name = endpointConfiguration.ToString();
    }

    public advanswsdlPortTypeClient(EndpointConfiguration endpointConfiguration, EndpointAddress remoteAddress)
        : base(GetBindingForEndpoint(endpointConfiguration), remoteAddress)
    {
        Endpoint.Name = endpointConfiguration.ToString();
    }

    public advanswsdlPortTypeClient(Binding binding, EndpointAddress remoteAddress)
        : base(binding, remoteAddress)
    {
    }

    public Task<RespuestaTimbre> timbrarAsync(string credential, string cfdi)
    {
        return Channel.timbrarAsync(credential, cfdi);
    }

    public Task<RespuestaValidacion> validarAsync(string credential, string cfdi)
    {
        return Channel.validarAsync(credential, cfdi);
    }

    public Task<RespuestaTimbre> timbrarRetencionAsync(string credential, string xml)
    {
        return Channel.timbrarRetencionAsync(credential, xml);
    }

    public Task<RespuestaTimbre2> timbrar2Async(string credential, string cfdi)
    {
        return Channel.timbrar2Async(credential, cfdi);
    }

    public Task<RespuestaTimbre2> timbrarRetencion2Async(string credential, string xml)
    {
        return Channel.timbrarRetencion2Async(credential, xml);
    }

    public Task<RespuestaTimbre> timbrar3Async(string credential, string cfdi)
    {
        return Channel.timbrar3Async(credential, cfdi);
    }

    public Task<RespuestaCancelacion> cancelarAsync(string credential, string rfc_emisor, string uuid, string motivo, string folio_sustitucion, string key, string cer)
    {
        return Channel.cancelarAsync(credential, rfc_emisor, uuid, motivo, folio_sustitucion, key, cer);
    }

    public Task<RespuestaCancelacion> cancelarRetencionAsync(string credential, string rfc_emisor, string uuid, string motivo, string folio_sustitucion, string key, string cer)
    {
        return Channel.cancelarRetencionAsync(credential, rfc_emisor, uuid, motivo, folio_sustitucion, key, cer);
    }

    public Task<RespuestaCancelacion> cancelarPFXSyncAsync(string credential, string rfc_emisor, string uuid, string motivo, string folio_sustitucion, string pfx, string pfx_password)
    {
        return Channel.cancelarPFXSyncAsync(credential, rfc_emisor, uuid, motivo, folio_sustitucion, pfx, pfx_password);
    }

    public Task<RespuestaConsulta> consultarAsync(string credential, string uuid)
    {
        return Channel.consultarAsync(credential, uuid);
    }

    public Task<RespuestaConsulta> consultar_cfdiAsync(string credential, string uuid)
    {
        return Channel.consultar_cfdiAsync(credential, uuid);
    }

    public Task<RespuestaConsultaHora> consultar_horaAsync()
    {
        return Channel.consultar_horaAsync();
    }

    public Task<RespuestaValidarCertificado> validar_certificadoAsync(string credential, string cer)
    {
        return Channel.validar_certificadoAsync(credential, cer);
    }

    public Task<RespuestaValidarCertificado> confirmacionAsync(string credential, string emisor_rfc, string receptor_rfc, string email)
    {
        return Channel.confirmacionAsync(credential, emisor_rfc, receptor_rfc, email);
    }

    public new virtual Task OpenAsync()
    {
        return Task.Factory.FromAsync(((ICommunicationObject)this).BeginOpen(null, null), ((ICommunicationObject)this).EndOpen);
    }

    public new virtual Task CloseAsync()
    {
        return Task.Factory.FromAsync(((ICommunicationObject)this).BeginClose(null, null), ((ICommunicationObject)this).EndClose);
    }

    private static Binding GetBindingForEndpoint(EndpointConfiguration endpointConfiguration)
    {
        if (endpointConfiguration == EndpointConfiguration.advanswsdlPort)
        {
            return new BasicHttpBinding
            {
                MaxBufferSize = int.MaxValue,
                ReaderQuotas = XmlDictionaryReaderQuotas.Max,
                MaxReceivedMessageSize = 2147483647L,
                AllowCookies = true,
                Security =
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            };
        }
        throw new InvalidOperationException($"No se pudo encontrar un punto de conexión con el nombre \"{endpointConfiguration}\".");
    }

    private static EndpointAddress GetEndpointAddress(EndpointConfiguration endpointConfiguration)
    {
        if (endpointConfiguration == EndpointConfiguration.advanswsdlPort)
        {
            return new EndpointAddress("https://ws40.advans.mx/ws/awscfdi.php");
        }
        throw new InvalidOperationException($"No se pudo encontrar un punto de conexión con el nombre \"{endpointConfiguration}\".");
    }

    private static Binding GetDefaultBinding()
    {
        return GetBindingForEndpoint(EndpointConfiguration.advanswsdlPort);
    }

    private static EndpointAddress GetDefaultEndpointAddress()
    {
        return GetEndpointAddress(EndpointConfiguration.advanswsdlPort);
    }
}
