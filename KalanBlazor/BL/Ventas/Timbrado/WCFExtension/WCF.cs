using CancearAdvansWS;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace KalanBlazor.BL.Ventas.Timbrado.WCFExtension
{
    public class WCF
    {
        public static advanscfdicancelacionPortTypeClient Cliente(string Url, string APIKey)
        {
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "BasicHttpBinding",
                Security = new BasicHttpSecurity
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            };

            EndpointAddress remoteAddress = new EndpointAddress(new Uri(Url + "?wsdl"));
            var ws_Cliente = new advanscfdicancelacionPortTypeClient(binding, remoteAddress);
            ws_Cliente.Endpoint.Name = "BasicHttpBinding_advanscfdicancelacionPortTypeClient";
            ws_Cliente.Endpoint.EndpointBehaviors.Add(new Behavior(APIKey));
            return ws_Cliente;
        }
    }
}
