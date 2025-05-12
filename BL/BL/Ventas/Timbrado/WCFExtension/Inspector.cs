using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KalanBlazor.BL.Ventas.Timbrado.WCFExtension
{
    public class Inspector : IClientMessageInspector
    {
        public Inspector(string auth)
        {
            Auth = auth;
        }

        public string Auth { get; }
        private string RemoveAccents(string text)
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();

            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }

            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            // Inspeccionar y posiblemente alterar el mensaje de respuesta aquí
            //string overrideXML = $"{reply}";
            //overrideXML = RemoveAccents(overrideXML);
            //overrideXML = overrideXML.Replace("utf-16", "utf-8");
            //// Create the reader
            //XmlReader envelopeReader = XmlReader.Create(new StringReader(overrideXML));

            //// Create the message using the reader
            //System.ServiceModel.Channels.Message replacedMessage = System.ServiceModel.Channels.Message.CreateMessage(envelopeReader, int.MaxValue, reply.Version);
            //replacedMessage.Headers.CopyHeadersFrom(reply.Headers);
            //replacedMessage.Properties.CopyProperties(reply.Properties);
            //reply = replacedMessage;
            //Console.WriteLine($"Reply: {reply}");
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            object httpRequestMessageObject;
            HttpRequestMessageProperty httpRequestMessage;
            if (request.Properties.TryGetValue(HttpRequestMessageProperty.Name, out httpRequestMessageObject))
            {
                httpRequestMessage = httpRequestMessageObject as HttpRequestMessageProperty;
                if (string.IsNullOrEmpty(httpRequestMessage.Headers["Authorization"]))
                {
                    httpRequestMessage.Headers["Authorization"] = Auth;
                }
            }
            else
            {
                httpRequestMessage = new HttpRequestMessageProperty();
                httpRequestMessage.Headers.Add("Authorization", Auth);
                request.Properties.Add(HttpRequestMessageProperty.Name, httpRequestMessage);
            }
            return null;
        }
    }
}
