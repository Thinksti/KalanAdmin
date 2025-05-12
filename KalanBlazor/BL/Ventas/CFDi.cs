using CancearAdvansWS;
using DocumentFormat.OpenXml.Office2010.Excel;
using KalanBlazor.BL.Ventas.Timbrado.WCFExtension;
using KalanBlazor.DTOs.SAT.Timbrado;
using KalanBlazor.DTOs.Ventas.CFDi;

//using KalanBlazor.DTOs.Ventas.CFDi;
using KalanBlazor.DTOs.Ventas.CFDi.Comercio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Reporting.NETCore;
using Net.Codecrete.QrCodeGenerator;
using RestSharp;
using Shared.Kalan.Entidades;
using Shared.MySQL.Extension.Extensiones;
using Shared.Utilerias.Excel;
using Svg;
using System;
using System.Data;
using System.Drawing;
using System.IO.Compression;
using System.Net;
using System.Reflection;
using System.Runtime.ConstrainedExecution;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Schema;
using System.Xml.Serialization;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace KalanBlazor.BL.Ventas
{
    public class CFDi
    {
        public CFDi(string rutaCadenaOriginal, byte[] certificado, byte[] keyFile, string password, string connectionString, Excel excel)
        {
            RutaCadenaOriginal = rutaCadenaOriginal;
            Certificado = certificado;
            KeyFile = keyFile;
            Password = password;
            ConnectionString = connectionString;
            Excel = excel;
        }
        private DTOs.Ventas.CFDi.DatosFiscales DatosFiscal { get; set; }
        public string RutaCadenaOriginal { get; }
        public byte[] Certificado { get; }
        public byte[] KeyFile { get; }
        public string Password { get; }
        public string ConnectionString { get; }
        public Excel Excel { get; }

        public void CertificateData(byte[] pCerFile, out string certificate, out string certificateNumber, out string fechaExpiracion)
        {
            X509Certificate2 cert = new X509Certificate2(pCerFile);
            byte[] strcert = cert.GetRawCertData();
            certificate = Convert.ToBase64String(strcert);
            strcert = cert.GetSerialNumber();
            certificateNumber = Reverse(Encoding.UTF8.GetString(strcert));
            fechaExpiracion = cert.GetExpirationDateString();
        }
        public static string Reverse(string original)
        {
            string reverse = "";
            for (int i = original.Length - 1; i >= 0; i--)
            {
                reverse += original.Substring(i, 1);
            }
            return reverse;
        }
        private string SerieGet(string Documento)
        {
            for (int i = 0; i < Documento.Length; i++)
            {
                if (char.IsLetter(Documento.Substring(i, 1),0))
                {
                    return Documento.Substring(0, i+1);
                }
            }
            return "";
        }
        public string ExtraValor(string XMLString, string Valor)
        {

            try
            {

                foreach (XElement item in XDocument.Parse(XMLString).Nodes())
                {
                    XAttribute tag3 = item.XPathSelectElement("//*[local-name() = '" + item.Name.LocalName + "']").Attribute(Valor);
                    if (tag3 != null)
                    {
                        return tag3.Value;
                    }
                    if (item.Nodes().Count() > 0)
                    {
                        foreach (XElement hijo in item.Nodes())
                        {
                            XAttribute tag = hijo.XPathSelectElement("//*[local-name() = '" + hijo.Name.LocalName + "']").Attribute(Valor);
                            if (tag != null)
                            {
                                return tag.Value;
                            }
                        }
                    }
                    else
                    {
                        XAttribute tag2 = item.XPathSelectElement("//*[local-name() = '" + item.Name.LocalName + "']").Attribute(Valor);
                        if (tag2 != null)
                        {
                            return tag2.Value;
                        }
                    }
                }


            }
            catch (Exception ex)
            {

            }


            foreach (XElement item in ((XElement)XDocument.Parse(XMLString).FirstNode).Nodes())
            {
                if (item.Nodes().Count() > 0)
                {
                    foreach (XElement hijo in item.Nodes())
                    {
                        XAttribute tag = hijo.XPathSelectElement("//*[local-name() = '" + hijo.Name.LocalName + "']").Attribute(Valor);
                        if (tag != null)
                        {
                            return tag.Value;
                        }
                    }
                }
                else
                {
                    XAttribute tag2 = item.XPathSelectElement("//*[local-name() = '" + item.Name.LocalName + "']").Attribute(Valor);
                    if (tag2 != null)
                    {
                        return tag2.Value;
                    }
                }
            }
            return "";
        }
        public string ExtraValor(string XMLString, string TableName, string Valor)
        {
            foreach (XElement item in ((XElement)XDocument.Parse(XMLString).FirstNode).Nodes())
            {
                if (item.Nodes().Count() > 0)
                {
                    foreach (XElement hijo in item.Nodes())
                    {
                        if (hijo.Name.LocalName.ToUpper() == TableName.ToUpper())
                        {
                            XAttribute tag = hijo.XPathSelectElement("//*[local-name() = '" + hijo.Name.LocalName + "']").Attribute(Valor);
                            if (tag != null)
                            {
                                return tag.Value;
                            }
                        }
                    }
                }
                else if (item.Name.LocalName.ToUpper() == TableName.ToUpper())
                {
                    XAttribute tag2 = item.XPathSelectElement("//*[local-name() = '" + item.Name.LocalName + "']").Attribute(Valor);
                    if (tag2 != null)
                    {
                        return tag2.Value;
                    }
                }
            }
            return "";
        }
        public string ConvertirMontoATexto(decimal monto, string moneda)
        {
            // Dividir el monto en parte entera y parte decimal
            long parteEntera = (long)monto;
            int parteDecimal = (int)((monto - parteEntera) * 100);

            // Convertir parte entera a texto
            string textoParteEntera = ConvertirNumeroATexto(parteEntera);

            // Crear el texto del monto
            StringBuilder resultado = new StringBuilder();
            resultado.Append(textoParteEntera);
            resultado.Append(" con ");
            resultado.Append(parteDecimal.ToString("00"));
            resultado.Append("/100 ");
            resultado.Append(moneda);

            return resultado.ToString();
        }

        private string ConvertirNumeroATexto(long numero)
        {
            if (numero == 0)
                return "cero";

            string[] unidades = { "", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve" };
            string[] decenas = { "", "diez", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa" };
            string[] centenas = { "", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos" };

            StringBuilder textoNumero = new StringBuilder();

            if (numero >= 1000000)
            {
                long millones = numero / 1000000;
                numero %= 1000000;
                textoNumero.Append(ConvertirNumeroATexto(millones));
                textoNumero.Append(millones == 1 ? " millón " : " millones ");
            }

            if (numero >= 1000)
            {
                long miles = numero / 1000;
                numero %= 1000;
                if (miles == 1)
                {
                    textoNumero.Append("mil ");
                }
                else
                {
                    textoNumero.Append(ConvertirNumeroATexto(miles));
                    textoNumero.Append(" mil ");
                }
            }

            if (numero >= 100)
            {
                long centena = numero / 100;
                numero %= 100;
                textoNumero.Append(centenas[centena]);
                if (numero > 0)
                    textoNumero.Append(" ");
            }

            if (numero >= 20)
            {
                long decena = numero / 10;
                numero %= 10;
                textoNumero.Append(decenas[decena]);
                if (numero > 0)
                    textoNumero.Append(" y ");
            }
            else if (numero >= 10)
            {
                switch (numero)
                {
                    case 10: textoNumero.Append("diez"); break;
                    case 11: textoNumero.Append("once"); break;
                    case 12: textoNumero.Append("doce"); break;
                    case 13: textoNumero.Append("trece"); break;
                    case 14: textoNumero.Append("catorce"); break;
                    case 15: textoNumero.Append("quince"); break;
                    case 16: textoNumero.Append("dieciséis"); break;
                    case 17: textoNumero.Append("diecisiete"); break;
                    case 18: textoNumero.Append("dieciocho"); break;
                    case 19: textoNumero.Append("diecinueve"); break;
                }
                numero = 0;
            }

            if (numero > 0)
            {
                textoNumero.Append(unidades[numero]);
            }

            return textoNumero.ToString().Trim();
        }


        public string RemoveTagFromXml(string xmlString, string tagToRemove)
        { // Crear una instancia de XmlDocument y cargar el XML desde la cadena
          XmlDocument xmlDoc = new XmlDocument(); 
            xmlDoc.LoadXml(xmlString); 
            // Encontrar el nodo que se va a eliminar
            XmlNode nodeToRemove = xmlDoc.SelectSingleNode($"//{tagToRemove}"); 
            if (nodeToRemove != null) 
            { 
                // Remover el nodo
                xmlDoc.DocumentElement.RemoveChild(nodeToRemove); 
            } 
            // Convertir el XmlDocument a string y devolver el resultado
            return xmlDoc.OuterXml;
        }
        private byte[] CrearZip(byte[] xmlBytes, byte[] pdfBytes, string factura)
        {
            using (MemoryStream zipStream = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(zipStream, ZipArchiveMode.Create, true))
                { 
                    // Agregar el primer archivo al ZIP
                    ZipArchiveEntry file1Entry = archive.CreateEntry($"{factura}.xml"); 
                    using (BinaryWriter writer = new BinaryWriter(file1Entry.Open())) 
                    { 
                        writer.Write(xmlBytes); 
                    } 
                    // Agregar el segundo archivo al ZIP
                    ZipArchiveEntry file2Entry = archive.CreateEntry($"{factura}.pdf"); 
                    using (BinaryWriter writer = new BinaryWriter(file2Entry.Open())) 
                    { 
                        writer.Write(pdfBytes); 
                    } 
                } 
                return zipStream.ToArray(); 
            } 
        }
        public async Task<DTOs.Ventas.CFDi.RespuestaZIP> GenerarZip2(string XMLString, string Observaciones, string Factura, string Moneda, string Sucursal, string Orden)
        {
            DTOs.Ventas.CFDi.RespuestaZIP respuesta = new DTOs.Ventas.CFDi.RespuestaZIP();
            var bytesXML = System.Text.Encoding.UTF8.GetBytes(XMLString);
            respuesta.XML = bytesXML;
            if (string.IsNullOrEmpty(Observaciones))
            {
                Observaciones = "";
            }
            var bytesPDF = ImprimirCFDi(XMLString, Sucursal, Orden, Observaciones, Moneda);
            respuesta.PDF = bytesPDF;
            var bytesZip = CrearZip(bytesXML, bytesPDF, Factura);
            respuesta.ZIP = bytesZip;
            return respuesta;
        }
        public async Task<byte[]> GenerarZip(string XMLString, string Observaciones, string Factura, string Moneda, string Sucursal, string Orden)
        {
            var bytesXML = System.Text.Encoding.UTF8.GetBytes(XMLString);
            if (string.IsNullOrEmpty(Observaciones))
            {
                Observaciones = "";
            }
            var bytesPDF = ImprimirCFDi(XMLString,Sucursal,Orden, Observaciones, Moneda);
            var bytesZip = CrearZip(bytesXML, bytesPDF, Factura);
            return bytesZip;
        }
        private byte[] ImprimirCFDi(string XMLString, string Sucursal, string Orden, string Observaciones, string Moneda)
        {
            XMLString = RemoveTagFromXml(XMLString, "cfdi//Addenda");
            string sellosat = ExtraValor(XMLString, "TimbreFiscalDigital", "SelloSAT");
            var strTotal = ExtraValor(XMLString,  "Total");
            decimal total = Convert.ToDecimal(strTotal);
            sellosat = sellosat.Substring(sellosat.Length - 8);
            string svg = QrCode.EncodeText($"http://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id={ExtraValor(XMLString, "TimbreFiscalDigital", "UUID")}&re={ExtraValor(XMLString, "Emisor", "Rfc")}&rr={ExtraValor(XMLString, "Receptor", "Rfc")}&fe={sellosat}", QrCode.Ecc.Medium).ToSvgString(0);
            Encoding.UTF8.GetBytes(svg);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(svg);
            Bitmap Image = new Bitmap(SvgDocument.Open(xmlDocument).Draw());
            byte[] imagen = (byte[])new ImageConverter().ConvertTo(Image, typeof(byte[]));
            DataTable tablaExtras = new DataTable();
            tablaExtras.Columns.Add("Imagen", imagen.GetType());
            tablaExtras.Columns.Add("CantidadLetra", typeof(string));
            tablaExtras.Columns.Add("Observaciones", typeof(string));
            tablaExtras.Columns.Add("Notas", typeof(string));
            tablaExtras.Columns.Add("Sucursal", typeof(string));
            tablaExtras.Columns.Add("Orden", typeof(string));
            tablaExtras.Rows.Add(imagen, ConvertirMontoATexto(total, Moneda), Observaciones, Observaciones, Sucursal, Orden);
            DataSet DsXML = new DataSet();
            using (StringReader xmlReader = new StringReader(XMLString))
            {
                DsXML.ReadXml(xmlReader);
            }
            DataSet DsXML2 = new DataSet();
            foreach (DataTable item in DsXML.Tables)
            {
                if(DsXML2.Tables.Contains(item.TableName) == false)
                {
                    DsXML2.Tables.Add(item.Copy());
                }
            }
            DsXML = DsXML2;
            using var contexto = new Shared.Kalan.Contextos.KalanDB(ConnectionString);


            foreach (DataRow rw9 in DsXML.Tables["Comprobante"].Rows)
            {
                if (Convert.ToString(rw9["TipoDeComprobante"]) == "I")
                {
                    rw9["TipoDeComprobante"] = "Ingreso";
                }
                else if (Convert.ToString(rw9["TipoDeComprobante"]) == "E")
                {
                    rw9["TipoDeComprobante"] = "Egreso";
                }
            }
            foreach (DataRow rw4 in DsXML.Tables["Comprobante"].Rows)
            {
                foreach (th_formapago item8 in contexto.th_formapago.Where((th_formapago i) => i.Id.ToUpper().Trim() == Convert.ToString(rw4["FormaPago"]).ToUpper().Trim()))
                {
                    rw4["FormaPago"] = item8.Id.Trim() + "-" + item8.FormaPago.Trim();
                }
            }
            foreach (DataRow rw11 in DsXML.Tables["Comprobante"].Rows)
            {
                if (Convert.ToString(rw11["Exportacion"]) == "01")
                {
                    rw11["Exportacion"] = "01 No Aplica";
                }
            }
            foreach (DataRow rw3 in DsXML.Tables["Comprobante"].Rows)
            {
                foreach (th_metodopago item10 in contexto.th_metodopago.Where((th_metodopago i) => i.Id.ToUpper().Trim() == Convert.ToString(rw3["MetodoPago"]).ToUpper().Trim()))
                {
                    rw3["MetodoPago"] = item10.Id.Trim() + "-" + item10.MetodoPago.Trim();
                }
            }
            foreach (DataRow rw2 in DsXML.Tables["Receptor"].Rows)
            {
                foreach (th_regimenfiscal item11 in contexto.th_regimenfiscal.Where((th_regimenfiscal i) => i.Id == Convert.ToString(rw2["RegimenFiscalReceptor"])))
                {
                    rw2["RegimenFiscalReceptor"] = item11.Regimen.Trim();
                }
            }
            foreach (DataRow rw in DsXML.Tables["Receptor"].Rows)
            {
                foreach (th_usocfdi item12 in contexto.th_usocfdi.Where((th_usocfdi i) => i.Id == Convert.ToString(rw["UsoCFDI"])))
                {
                    rw["UsoCFDI"] = item12.UsoCFDi.Trim();
                }
            }
            var t_dt = DsXML.Tables["Traslado"];
            DataTable sortedTable = new();
            if (t_dt != null)
            {
                DataView view = new DataView(t_dt);
                view.Sort = "Traslados_Id ASC";
                sortedTable = view.ToTable();
            }
            

            List<ReportDataSource> DataSources = new List<ReportDataSource>();
            DataSources.Add(new ReportDataSource("Timbre", DsXML.Tables["TimbreFiscalDigital"]));
            DataSources.Add(new ReportDataSource("Comprobante", DsXML.Tables["Comprobante"]));
            DataSources.Add(new ReportDataSource("Receptor", DsXML.Tables["Receptor"]));
            DataSources.Add(new ReportDataSource("Emisor", DsXML.Tables["Emisor"]));
            DataSources.Add(new ReportDataSource("Concepto", DsXML.Tables["Concepto"]));
            DataSources.Add(new ReportDataSource("Traslado", sortedTable));
            DataSources.Add(new ReportDataSource("Extras", tablaExtras));
            LocalReport Reporte = new LocalReport();
            FileInfo DllInfo = new FileInfo(Assembly.GetEntryAssembly().Location);
            var rutardlc = Path.Combine(DllInfo.Directory.FullName, "Reportes\\Factura.rdlc");
            Reporte.LoadReportDefinition(new MemoryStream(File.ReadAllBytes(rutardlc)));
            foreach (ReportDataSource item in DataSources)
            {
                if (item.Value != null)
                {
                    Reporte.DataSources.Add(item);
                }
            } 
            var PDFBytes = Reporte.Render("PDF");
            return PDFBytes;
        }
        private DataTable ClonarDatatable(DataTable dt)
        {
            DataTable DTConceptos = new DataTable();
            foreach (DataColumn col in dt.Columns)
            {
                DTConceptos.Columns.Add(col.ColumnName, col.DataType);
            }
            foreach (DataRow row in dt.Rows)
            {
                DTConceptos.Rows.Add(row.ItemArray);
            }
            return DTConceptos;
        }
        private string FolioGet(string Documento)
        {
            for (int i = 0; i < Documento.Length; i++)
            {
                if (char.IsLetter(Documento.Substring(i, 1), 0))
                {
                    return Documento.Substring(i + 1, Documento.Length - 1);
                }
            }
            return "";
        }
        public async Task<DTOs.Ventas.CFDi.RespuestaTimbrado> TimbrarMentiritas2(string XMLString)
        {
            string uuid = Guid.NewGuid().ToString().ToUpper();
            if (XMLString.Contains("<cfdi:Complemento>"))
            {
                string timbre = $"\r\n<tfd:TimbreFiscalDigital xmlns:tfd=\"http://www.sat.gob.mx/TimbreFiscalDigital\" RfcProvCertif=\"TDM010101000\" Version=\"1.1\" UUID=\"{uuid}\" FechaTimbrado=\"{DateTime.Now.ToString("yyyy-MM-dd")}T{DateTime.Now.ToString("HH:mm:ss")}\" SelloCFD=\"XceaOhgyrObs5FP5HadMWoFTumBa1UZAYgwfDsRgGQAddyElVFpKxllwef6EqVYOaDE4fDO4MKyjW7fEk2hM9d9OAGTDF0a8wlsVz5kS//F/MehW8Jc7F5NLKT1cl2Ai5e9RLcdMs9U0evGqw7i2iIHtwLG3V26IZRP1hj+dz9LUkpR3cPkFRavj1lnokEiebjrTXTwaGksjDNao5IMe7SzBN6QapfmqVH9kIxwZYEEbmGZFKwQlUBOoCfe0uvZAoLG11e6ow5F6627B33Xxv31lt8I0P6pOX+8zaa+AMnR+rIV4sYSw0gpkX+0iAcbeQa8ZmosM0hnyHhadLlKNKQ==\" NoCertificadoSAT=\"00000000000000000000\" SelloSAT=\"VUel4awRKGrtA/eCmA1h903SfmVFKEnF40MEmX8HvXCk/2DeIk7z9A+7JKb8SVbYXUJ6Zt93lB9we2Szwcma/mH+2RuF4UQ2oiD+LMDxP0gHIyN3kugy0FYKoil5awMNNksJ/lVpsB9ZsN+04wlQInMMu6EIqMGsd7MeNzlyzhzwoFDlt6L73LM1jiBYxJ3rSg80k+b3ZGtcCaW5AeQm56/VgKxu756MTgGIUt2um1xqSncM7nZBX+/f7Cq2QzZvUC1q2GSH952QvHgp+9Ky0mRWiRaGimOw2jocKJ9P3jKFRzhDyfZqAbGNwQdMaxQJNYa23lkulZbxd/QNIEaoMQ==\" xsi:schemaLocation=\"http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd\"/>\r\n</cfdi:Complemento>";
                XMLString = XMLString.Replace("</cfdi:Complemento>", timbre);
                   return new DTOs.Ventas.CFDi.RespuestaTimbrado { Exitoso = true, XML = XMLString, UUID = uuid }; ;
            }
            else
            {
                string timbre = $"<cfdi:Complemento>\r\n<tfd:TimbreFiscalDigital xmlns:tfd=\"http://www.sat.gob.mx/TimbreFiscalDigital\" RfcProvCertif=\"TDM010101000\" Version=\"1.1\" UUID=\"{uuid}\" FechaTimbrado=\"{DateTime.Now.ToString("yyyy-MM-dd")}T{DateTime.Now.ToString("HH:mm:ss")}\" SelloCFD=\"XceaOhgyrObs5FP5HadMWoFTumBa1UZAYgwfDsRgGQAddyElVFpKxllwef6EqVYOaDE4fDO4MKyjW7fEk2hM9d9OAGTDF0a8wlsVz5kS//F/MehW8Jc7F5NLKT1cl2Ai5e9RLcdMs9U0evGqw7i2iIHtwLG3V26IZRP1hj+dz9LUkpR3cPkFRavj1lnokEiebjrTXTwaGksjDNao5IMe7SzBN6QapfmqVH9kIxwZYEEbmGZFKwQlUBOoCfe0uvZAoLG11e6ow5F6627B33Xxv31lt8I0P6pOX+8zaa+AMnR+rIV4sYSw0gpkX+0iAcbeQa8ZmosM0hnyHhadLlKNKQ==\" NoCertificadoSAT=\"00000000000000000000\" SelloSAT=\"VUel4awRKGrtA/eCmA1h903SfmVFKEnF40MEmX8HvXCk/2DeIk7z9A+7JKb8SVbYXUJ6Zt93lB9we2Szwcma/mH+2RuF4UQ2oiD+LMDxP0gHIyN3kugy0FYKoil5awMNNksJ/lVpsB9ZsN+04wlQInMMu6EIqMGsd7MeNzlyzhzwoFDlt6L73LM1jiBYxJ3rSg80k+b3ZGtcCaW5AeQm56/VgKxu756MTgGIUt2um1xqSncM7nZBX+/f7Cq2QzZvUC1q2GSH952QvHgp+9Ky0mRWiRaGimOw2jocKJ9P3jKFRzhDyfZqAbGNwQdMaxQJNYa23lkulZbxd/QNIEaoMQ==\" xsi:schemaLocation=\"http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd\"/>\r\n</cfdi:Complemento></cfdi:Comprobante>";
                XMLString = XMLString.Replace("</cfdi:Comprobante>", timbre);
                return new DTOs.Ventas.CFDi.RespuestaTimbrado { Exitoso = true, XML = XMLString, UUID = uuid };
            }
        }
        public async Task<string> TimbrarMentiritas(string XMLString)
        {
            string uuid = Guid.NewGuid().ToString().ToUpper();
            if (XMLString.Contains("<cfdi:Complemento>"))
            {
                string timbre = $"\r\n<tfd:TimbreFiscalDigital xmlns:tfd=\"http://www.sat.gob.mx/TimbreFiscalDigital\" RfcProvCertif=\"TDM010101000\" Version=\"1.1\" UUID=\"{uuid}\" FechaTimbrado=\"{DateTime.Now.ToString("yyyy-MM-dd")}T{DateTime.Now.ToString("HH:mm:ss")}\" SelloCFD=\"XceaOhgyrObs5FP5HadMWoFTumBa1UZAYgwfDsRgGQAddyElVFpKxllwef6EqVYOaDE4fDO4MKyjW7fEk2hM9d9OAGTDF0a8wlsVz5kS//F/MehW8Jc7F5NLKT1cl2Ai5e9RLcdMs9U0evGqw7i2iIHtwLG3V26IZRP1hj+dz9LUkpR3cPkFRavj1lnokEiebjrTXTwaGksjDNao5IMe7SzBN6QapfmqVH9kIxwZYEEbmGZFKwQlUBOoCfe0uvZAoLG11e6ow5F6627B33Xxv31lt8I0P6pOX+8zaa+AMnR+rIV4sYSw0gpkX+0iAcbeQa8ZmosM0hnyHhadLlKNKQ==\" NoCertificadoSAT=\"00000000000000000000\" SelloSAT=\"VUel4awRKGrtA/eCmA1h903SfmVFKEnF40MEmX8HvXCk/2DeIk7z9A+7JKb8SVbYXUJ6Zt93lB9we2Szwcma/mH+2RuF4UQ2oiD+LMDxP0gHIyN3kugy0FYKoil5awMNNksJ/lVpsB9ZsN+04wlQInMMu6EIqMGsd7MeNzlyzhzwoFDlt6L73LM1jiBYxJ3rSg80k+b3ZGtcCaW5AeQm56/VgKxu756MTgGIUt2um1xqSncM7nZBX+/f7Cq2QzZvUC1q2GSH952QvHgp+9Ky0mRWiRaGimOw2jocKJ9P3jKFRzhDyfZqAbGNwQdMaxQJNYa23lkulZbxd/QNIEaoMQ==\" xsi:schemaLocation=\"http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd\"/>\r\n</cfdi:Complemento>";
                XMLString = XMLString.Replace("</cfdi:Complemento>", timbre);
                return XMLString;
            }
            else
            {
                string timbre = $"<cfdi:Complemento>\r\n<tfd:TimbreFiscalDigital xmlns:tfd=\"http://www.sat.gob.mx/TimbreFiscalDigital\" RfcProvCertif=\"TDM010101000\" Version=\"1.1\" UUID=\"{uuid}\" FechaTimbrado=\"{DateTime.Now.ToString("yyyy-MM-dd")}T{DateTime.Now.ToString("HH:mm:ss")}\" SelloCFD=\"XceaOhgyrObs5FP5HadMWoFTumBa1UZAYgwfDsRgGQAddyElVFpKxllwef6EqVYOaDE4fDO4MKyjW7fEk2hM9d9OAGTDF0a8wlsVz5kS//F/MehW8Jc7F5NLKT1cl2Ai5e9RLcdMs9U0evGqw7i2iIHtwLG3V26IZRP1hj+dz9LUkpR3cPkFRavj1lnokEiebjrTXTwaGksjDNao5IMe7SzBN6QapfmqVH9kIxwZYEEbmGZFKwQlUBOoCfe0uvZAoLG11e6ow5F6627B33Xxv31lt8I0P6pOX+8zaa+AMnR+rIV4sYSw0gpkX+0iAcbeQa8ZmosM0hnyHhadLlKNKQ==\" NoCertificadoSAT=\"00000000000000000000\" SelloSAT=\"VUel4awRKGrtA/eCmA1h903SfmVFKEnF40MEmX8HvXCk/2DeIk7z9A+7JKb8SVbYXUJ6Zt93lB9we2Szwcma/mH+2RuF4UQ2oiD+LMDxP0gHIyN3kugy0FYKoil5awMNNksJ/lVpsB9ZsN+04wlQInMMu6EIqMGsd7MeNzlyzhzwoFDlt6L73LM1jiBYxJ3rSg80k+b3ZGtcCaW5AeQm56/VgKxu756MTgGIUt2um1xqSncM7nZBX+/f7Cq2QzZvUC1q2GSH952QvHgp+9Ky0mRWiRaGimOw2jocKJ9P3jKFRzhDyfZqAbGNwQdMaxQJNYa23lkulZbxd/QNIEaoMQ==\" xsi:schemaLocation=\"http://www.sat.gob.mx/TimbreFiscalDigital http://www.sat.gob.mx/sitio_internet/cfd/TimbreFiscalDigital/TimbreFiscalDigitalv11.xsd\"/>\r\n</cfdi:Complemento></cfdi:Comprobante>";
                XMLString = XMLString.Replace("</cfdi:Comprobante>", timbre);
                return XMLString;
            }
        }
        public async Task<DTOs.Ventas.CFDi.RespuestaTimbrado> Timbrar2(string XML)
        {
            ////XML = XML.Replace("xmlns:cce20=\"http://www.sat.gob.mx/ComercioExterior20\" xmlns:xsi=\"http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior20/ComercioExterior20.xsd\"", "");
            //XML = File.ReadAllText("C:\\Users\\cmend\\Downloads\\F-000000001\\F-000000001.xml");
            //string uuid2 = ExtraValor(XML, "TimbreFiscalDigital", "UUID");
            //return new DTOs.Ventas.CFDi.RespuestaTimbrado { Exitoso = true, XML = XML, UUID = uuid2 };


            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "BasicHttpBinding",
                Security = new BasicHttpSecurity
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            };
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Producción
            EndpointAddress remoteAddress = new EndpointAddress("https://ws40.advans.mx/ws/awscfdi.php");
            var password = "f013da64fd597b61a1c6caaeca6e0225";
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //QAS
            //EndpointAddress remoteAddress = new EndpointAddress("https://dev.advans.mx/ws/awscfdi.php");
            //var password = "9cb154322ff5856981dcd51603ea3d76";
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            AdvansTimbrado.advanswsdlPortTypeClient advanswsdlPortTypeClient = new AdvansTimbrado.advanswsdlPortTypeClient(binding, remoteAddress);
            advanswsdlPortTypeClient.Endpoint.Name = "BasicHttpBinding_advanswsdlPortType";
            try
            {
                AdvansTimbrado.RespuestaTimbre2 respuestaTimbre = await advanswsdlPortTypeClient.timbrar2Async(password, XML);
                if (respuestaTimbre == null || string.IsNullOrWhiteSpace(respuestaTimbre.Code) || (!(respuestaTimbre.Code.Trim() == "200") && string.IsNullOrWhiteSpace(respuestaTimbre.CFDI)))
                {
                    return new DTOs.Ventas.CFDi.RespuestaTimbrado {  Error =  respuestaTimbre.Message, Exitoso = false };
                }
                else
                {
                    string uuid = ExtraValor(respuestaTimbre.CFDI, "TimbreFiscalDigital", "UUID");
                    return new DTOs.Ventas.CFDi.RespuestaTimbrado { Exitoso = true, XML = respuestaTimbre.CFDI, UUID = uuid };
                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
        public string ImprimirAcuse(List<AcuseDatos> datos,string Documento, string carpetaPDF)
        {
            using var contexto = new Shared.Kalan.Contextos.KalanDB(ConnectionString);
            FileInfo DllInfo2 = new FileInfo(Assembly.GetEntryAssembly().Location);
            var rutaReporte = Path.Combine(DllInfo2.Directory.FullName, "Reportes\\Acuse.rdlc");
            foreach (var item in datos)
            {
                if (item.Estatus == "Solicitud recibida")
                {
                    item.Estatus = "Solicitud de cancelación recibida";
                }
                switch (item.Motivo)
                {
                    case "01":
                        item.Motivo = "01 - Comprobantes emitidos con errores con relación.";
                        break;
                    case "02":
                        item.Motivo = "02 - Comprobantes emitidos con errores sin relación.";
                        break;
                    case "03":
                        item.Motivo = "03 - No se llevó a cabo la operación.";
                        break;
                    case "04":
                        item.Motivo = "04 - Operación nominativa relacionada en una factura global.";
                        break;
                    default:
                        break;
                }
            }
            DataTable dt_Datos = contexto.ToDataTable(datos);
            var DataSources = new List<ReportDataSource>();
            DataSources.Add(new ReportDataSource("Datos", dt_Datos));
            LocalReport Reporte = new LocalReport();
            Reporte.LoadReportDefinition(new MemoryStream(File.ReadAllBytes(rutaReporte)));
            foreach (ReportDataSource source in DataSources)
            {
                if (source.Value != null)
                {
                    Reporte.DataSources.Add(source);
                }
            }
            var PDFBytes = Reporte.Render("PDF"); 
            var ruta = Path.Combine(carpetaPDF, $"{Documento}.pdf");
            File.WriteAllBytes(ruta, PDFBytes);
            return ruta;
        }
        private string ExportToPEM(X509Certificate cert)
        {
            System.Text.StringBuilder stringBuilder = new System.Text.StringBuilder();
            stringBuilder.AppendLine("-----BEGIN CERTIFICATE-----");
            stringBuilder.AppendLine(Convert.ToBase64String(cert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks));
            stringBuilder.AppendLine("-----END CERTIFICATE-----");
            return stringBuilder.ToString();
        }
        public async Task<DTOs.Ventas.CFDi.CancelarResponse2> CancelarSAT(string Documento, string Motivo)
        {
            using var contexto = new Shared.Kalan.Contextos.KalanDB(ConnectionString);
            var sellos = contexto.th_facturacion_sellos.FirstOrDefault();
            string password = sellos.Sello_Password;
            var factura = contexto.th_venta_factura.Where(i => i.UUID == Documento).Include(x=>x.cliente).FirstOrDefault();
            Chilkat.PrivateKey privateKey = new Chilkat.PrivateKey();
            X509Certificate x509 = new X509Certificate(sellos.Sello_Cer);
            privateKey.LoadPvk(sellos.Sello_Key, password);
            Chilkat.Cert cert = new Chilkat.Cert();
            cert.LoadFromBinary(sellos.Sello_Cer);
            cert.ExportPublicKey().GetOpenSslPem();
            string PublicKey = ExportToPEM(x509);
            string PrivateKey = privateKey.GetPkcs8Pem();
            var respuestaSAT = await SendPostCancelRequestAdvans(Documento, PrivateKey, PublicKey, factura.UUID, factura.cliente.RFC, (double)factura.Total, Motivo, string.Empty);
            var rutaAcuse= ImprimirAcuse(respuestaSAT.AcuseDatos, Documento, factura.RutaPDF.Replace(factura.Factura + ".pdf", ""));
            factura.RutaAcuse = rutaAcuse;
            factura.Activo = false;

            var existingEntityF = contexto.Set<th_venta_factura>().Find(factura.Id);
            if (existingEntityF != null)
            {
                contexto.Entry(existingEntityF).CurrentValues.SetValues(factura);
            }
            else
            {
                contexto.Attach(factura);
            }
            contexto.SaveChanges();
             
            var cuenta = contexto.th_cuentascobrar.Where(i => i.Id == factura.Id).FirstOrDefault();
            cuenta.Activo = false;
            contexto.th_cuentascobrar.Update(cuenta);
            await contexto.SaveChangesAsync();
            return respuestaSAT;
        }
        private async Task<DTOs.Ventas.CFDi.CancelarResponse2> SendPostCancelRequestAdvans(string Documento, string PrivateKeyPem, string PublicKeyPem, string Uuid, string RFCReceptor, double Total, string Motivo, string FolioSustitucion)
        {
 
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Producción
            string Url = "https://ws40.advans.mx/cfdi-cancelacion/soap";
            var ApiKey = "f013da64fd597b61a1c6caaeca6e0225";
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //QAS
            //string Url = "https://dev.advans.mx/cfdi-cancelacion/soap";
            //var ApiKey = "9cb154322ff5856981dcd51603ea3d76";
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////

            if (FolioSustitucion == null)
            {
                FolioSustitucion = "";
            }
            RestClient client = new RestClient();
            RestRequest request = new RestRequest(Url + "?wsdl", Method.Post);
            request.AddOrUpdateHeader("Content-Type", "text/xml; charset=utf-8");
            request.AddOrUpdateHeader("SOAPAction", "urn:advans-cfdi-cancelacion#Cancelar");
            request.AddOrUpdateHeader("Authorization", ApiKey);
            string body = "<?xml version=\"1.0\" encoding=\"utf-8\"?>\n<SOAP-ENV:Envelope SOAP-ENV:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:SOAP-ENV=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:SOAP-ENC=\"http://schemas.xmlsoap.org/soap/encoding/\" xmlns:tns=\"urn:advans-cfdi-cancelacion\">\n    <SOAP-ENV:Body>\n        <tns:Cancelar>\n            <CancelarRequest>\n                <PrivateKeyPem xsi:type=\"xsd:string\">" + PrivateKeyPem + "</PrivateKeyPem>\n                <PublicKeyPem xsi:type=\"xsd:string\">" + PublicKeyPem + "</PublicKeyPem>\n                <Uuid>" + Uuid + "</Uuid>\n                    <RfcReceptor>" + RFCReceptor + "</RfcReceptor>\n" + $"                    <Total>{Total}</Total>" + "\n                    <Motivo>" + Motivo + "</Motivo>\n                    <FolioSustitucion>" + FolioSustitucion + "</FolioSustitucion>\n                </CancelarRequest>\n            </tns:Cancelar>\n        </SOAP-ENV:Body>\n    </SOAP-ENV:Envelope>";
            request.AddParameter("text/xml", body, ParameterType.RequestBody);
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            RestResponse response = client.Execute(request);
            var cancelar = new CancearAdvansWS.CancelarRequest();
            cancelar.PrivateKeyPem = PrivateKeyPem;
            cancelar.PublicKeyPem = PublicKeyPem;
            cancelar.Uuid = Uuid;
            cancelar.RfcReceptor = RFCReceptor;
            cancelar.Total = Total;
            cancelar.Motivo = Motivo;
            cancelar.FolioSustitucion = FolioSustitucion;
            if (response.Content != null)
            {
                if (response.Content != "")
                {
                    XmlDocument xmlDocument = new XmlDocument();
                    xmlDocument.LoadXml(response.Content);
                    int code = 0;
                    string Detail = "";
                    string Message = "";
                    _ = xmlDocument.ChildNodes;
                    foreach (XmlNode item in xmlDocument.ChildNodes)
                    {
                        if (item.ChildNodes.Count <= 0)
                        {
                            continue;
                        }
                        foreach (XmlNode item2 in item.ChildNodes)
                        {
                            if (item2.ChildNodes.Count <= 0)
                            {
                                continue;
                            }
                            foreach (XmlNode item3 in item2.ChildNodes)
                            {
                                if (item3.ChildNodes.Count <= 0)
                                {
                                    continue;
                                }
                                foreach (XmlNode item4 in item3.ChildNodes)
                                {
                                    if (item4.ChildNodes.Count > 0 && response.Content.Contains("CancelarResponse"))
                                    {
                                        foreach (XmlNode childNode in item4.ChildNodes)
                                        {
                                            string valor = childNode.InnerText;
                                            switch (childNode.Name)
                                            {
                                                case "Code":
                                                    code = Convert.ToInt32(valor);
                                                    break;
                                                case "Message":
                                                    Message = valor;
                                                    break;
                                                case "Detail":
                                                    Detail = valor;
                                                    break;
                                                case "CancelarResponse":
                                                    Detail = valor;
                                                    break;
                                                case "faultcode":
                                                    code = 101;
                                                    break;
                                                case "faultstring":
                                                    Message = valor;
                                                    break;
                                                case "detail":
                                                    Detail = valor;
                                                    break;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        string valor2 = item4.InnerText;
                                        switch (item4.Name)
                                        {
                                            case "faultcode":
                                                code = 101;
                                                break;
                                            case "faultstring":
                                                Message = valor2;
                                                break;
                                            case "detail":
                                                Detail = valor2;
                                                break;
                                            case "CancelarResponse":
                                                Detail = valor2;
                                                break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    var consulta = new CancearAdvansWS.ConsultarEstadoRequest { Id = Uuid };
                    try
                    {
                        var ws_Cliente = WCF.Cliente(Url, ApiKey);
                        CancearAdvansWS.ConsultarEstadoResponse acuse = ws_Cliente.ConsultarEstado(consulta);
                        XmlDocument xmlAcuse = new XmlDocument();
                        xmlAcuse.LoadXml(acuse.AcuseSAT);
                        DateTime Fecha = DateTime.Now;
                        string FolioFiscal = Uuid;
                        string Estatus = Message;
                        string CFDiRemplaza = FolioSustitucion;
                        string SelloSAT = "";
                        _ = xmlAcuse.ChildNodes;
                        foreach (XmlNode item in xmlAcuse.ChildNodes)
                        {
                            if (item.ChildNodes.Count <= 0)
                            {
                                continue;
                            }
                            foreach (XmlNode item2 in item.ChildNodes)
                            {
                                if (item2.ChildNodes.Count <= 0)
                                {
                                    continue;
                                }
                                foreach (XmlNode item3 in item2.ChildNodes)
                                {
                                    if (item3.ChildNodes.Count <= 0)
                                    {
                                        continue;
                                    }
                                    foreach (XmlNode item4 in item3.ChildNodes)
                                    {
                                        if (item4.ParentNode.Name == "SignatureValue")
                                        {
                                            SelloSAT = item4.ParentNode.InnerText;
                                        }
                                    }
                                }
                            }
                        }
                        if (SelloSAT != "")
                        {
                            DTOs.Ventas.CFDi.AcuseDatos acuseDatos = new DTOs.Ventas.CFDi.AcuseDatos
                            {
                                FechaSolicitud = Fecha,
                                RFCEmisor = "KCM210429N64",
                                FolioFiscal = FolioFiscal,
                                Estatus = Estatus,
                                Motivo = Motivo,
                                CFDiRemplaza = CFDiRemplaza,
                                Folio = Documento,
                                SelloSAT = SelloSAT
                            };
                            var datos = new List<DTOs.Ventas.CFDi.AcuseDatos>();
                            datos.Add(acuseDatos);
                             
                            return new DTOs.Ventas.CFDi.CancelarResponse2
                            {
                                Code = code,
                                Detail = Detail,
                                Message = Message,
                                XML = response.Content,
                                AcuseDatos = datos
                            };
                        }
                    }
                    catch (Exception ex)
                    {

                    }
                    return new DTOs.Ventas.CFDi.CancelarResponse2
                    {
                        Code = code,
                        Detail = Detail,
                        Message = Message,
                        XML = response.Content
                    };
                }
            }
            if (response != null)
            {
                if (response.IsSuccessful == false)
                {
                    return new DTOs.Ventas.CFDi.CancelarResponse2
                    {
                        Code = 100,
                        Detail = response.StatusCode.ToString(),
                        Message = response.StatusDescription.ToString()
                    };
                }
            }
            return new DTOs.Ventas.CFDi.CancelarResponse2
            {
                Code = 100,
                Detail = response.Content,
                Message = response.Content
            };
        }

        public async Task<string> Timbrar(string XML)
        {
            //XML = XML.Replace("xmlns:cce20=\"http://www.sat.gob.mx/ComercioExterior20\" xmlns:xsi=\"http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior20/ComercioExterior20.xsd\"", "");
     
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls13;
            BasicHttpBinding binding = new BasicHttpBinding
            {
                Name = "BasicHttpBinding",
                Security = new BasicHttpSecurity
                {
                    Mode = BasicHttpSecurityMode.Transport
                }
            };
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //Producción
            EndpointAddress remoteAddress = new EndpointAddress("https://ws40.advans.mx/ws/awscfdi.php");
            var password = "f013da64fd597b61a1c6caaeca6e0225";
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //QAS
            //EndpointAddress remoteAddress = new EndpointAddress("https://dev.advans.mx/ws/awscfdi.php");
            //var password = "9cb154322ff5856981dcd51603ea3d76";
            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            AdvansTimbrado.advanswsdlPortTypeClient advanswsdlPortTypeClient = new AdvansTimbrado.advanswsdlPortTypeClient(binding, remoteAddress);
            advanswsdlPortTypeClient.Endpoint.Name = "BasicHttpBinding_advanswsdlPortType";
            try
            {
                AdvansTimbrado.RespuestaTimbre2 respuestaTimbre = await advanswsdlPortTypeClient.timbrar2Async(password, XML);
                if (respuestaTimbre == null || string.IsNullOrWhiteSpace(respuestaTimbre.Code) || (!(respuestaTimbre.Code.Trim() == "200") && string.IsNullOrWhiteSpace(respuestaTimbre.CFDI)))
                {
                    return respuestaTimbre.Message;
                }
                else
                {
                    return respuestaTimbre.CFDI;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }
        public string TrimZeros(decimal number)
        { // Convertir el número a cadena sin ceros innecesarios
          return number.ToString("0.#####", System.Globalization.CultureInfo.InvariantCulture).TrimStart('0');
        }
        public string GenerarXML(string Documento)
        {
            using var contexto = new Shared.Kalan.Contextos.KalanDB(ConnectionString);

            var factura = contexto.th_venta_factura
                .Where(x => x.Factura == Documento)
                .Include(x => x.metodopago)
                .Include(x => x.moneda)
                .Include(x => x.tipocambio)
                .Include(x=>x.cliente).ThenInclude(x => x.usocfdi)
                .Include(x => x.cliente).ThenInclude(x => x.regimenfiscal)
                .Include(x => x.th_venta_factura_detalle).ThenInclude(x=>x.articulo)
                .ToList();

            var tComprobante = factura
                .Select(x=>
                new DTOs.Ventas.CFDi.Comprobante
                {
                    Version = "4.0",
                    Serie = SerieGet(Documento).Replace("-",""),
                    Folio = FolioGet(Documento).Replace("-", ""),
                    Fecha = x.Fecha,
                    Certificado="",
                    Descuento = 0,
                    Exportacion = "01",
                    FormaPago = x.formapago_Id,
                    LugarExpedicion = "64769",
                    MetodoPago = x.metodopago_Id,
                    Moneda = x.moneda.NombreCorto,
                    SubTotal = x.SubTotal, 
                    TipoCambio = x.tipocambio.TipoCambio,
                    TipoDeComprobante = "I",
                    Total = x.Total
                })
                .ToList();
            var trelacion = new List<DTOs.Ventas.CFDi.Relacionado>();
            var tEmisor = new List<DTOs.Ventas.CFDi.Emisor> { new DTOs.Ventas.CFDi.Emisor { Nombre= "KALAN CORP MNA",  RegimenFiscal= "601", Rfc= "KCM210429N64" } };
            var tReceptor = new List<DTOs.Ventas.CFDi.Receptor> { new DTOs.Ventas.CFDi.Receptor { Nombre = factura.First().cliente.RazonSocial, Rfc = factura.First().cliente.RFC, UsoCFDI = factura.First().cliente.usocfdi.Id, DomicilioFiscalReceptor= factura.First().cliente.CodigoPostal, RegimenFiscalReceptor = factura.First().cliente.regimenfiscal.Id } };
            if(string.IsNullOrEmpty(factura.First().cliente.NumRegIdTrib) == false)
            {
                tReceptor.First().NumRegIdTrib = factura.First().cliente.NumRegIdTrib;
            }
            if (string.IsNullOrEmpty(factura.First().cliente.ResidenciaFiscal) == false)
            {
                tReceptor.First().ResidenciaFiscal = factura.First().cliente.ResidenciaFiscal;
            }
            foreach (var item in tReceptor)
            {
                if(item.Rfc == "XEXX010101000")
                {
                    item.DomicilioFiscalReceptor = tComprobante.First().LugarExpedicion;
                }
                else
                {
                    item.ResidenciaFiscal = "";
                    item.NumRegIdTrib = "";
                }

            }
            var tconceptos = (from d in factura.SelectMany(x => x.th_venta_factura_detalle)
                             join a in contexto.th_articulos on d.articulo_Id equals a.Id
                             join m in contexto.th_articulos_unidad on a.unidad_Id equals m.Id
                             select
                new DTOs.Ventas.CFDi.Concepto
                {
                    Cantidad = d.Cantidad,
                    ClaveProdServ = a.catalogoproductosat_Id,
                    ClaveUnidad = m.ClaveSAT,
                    Descripcion = a.Descripcion,
                    Importe = d.SubTotal,
                    NoIdentificacion = a.NombreCorto ,
                    ObjetoImp = d.planimpuestos==null?"01":"02",
                    Unidad = m.NombreCorto,
                    ValorUnitario = d.Unitario, 
                    Id = d.Partida
                    
                })
                .ToList();
            var ttraslados = new List<DTOs.Ventas.CFDi.ImpuestosTraslados>();
            var tretenidos = new List<DTOs.Ventas.CFDi.ImpuestosRetenidos>();
            foreach (var d in tconceptos)
            {
                
                if (d.ObjetoImp == "02")
                {
                    var _Impuestos = from a in contexto.th_articulos
                                    join p in contexto.th_plan_impuestos on a.ImpPlanVenta_id equals p.Id
                                    join det in contexto.th_plan_impuestos_detalle on p.Id equals det.plan_impuestos_id
                                    join imp in contexto.th_impuestos on det.impuestos_id equals imp.Id
                                    where a.NombreCorto == d.NoIdentificacion
                                    select imp; 
                    foreach (var item in _Impuestos)
                    {
                        if (item.Porcentaje < 0)
                        {
                            tretenidos.Add(new DTOs.Ventas.CFDi.ImpuestosRetenidos
                            {
                                Importe = Math.Round((d.Importe * (decimal)(item.Porcentaje / 100)), 2),
                                Impuesto = item.IdSAT,
                                TipoFactor = "Tasa",
                                TasaOCuota = (item.Porcentaje / 100).ToString("N6"),
                                Base = Math.Round(d.Importe, 2),
                                Id = d.Id
                            });
                        }
                        else
                        {
                            ttraslados.Add(new DTOs.Ventas.CFDi.ImpuestosTraslados
                            {
                                Importe = Math.Round((d.Importe * (decimal)(item.Porcentaje / 100)), 2),
                                Impuesto = item.IdSAT,
                                TipoFactor = "Tasa",
                                TasaOCuota = (item.Porcentaje / 100).ToString("N6"),
                                Base = Math.Round(d.Importe, 2),
                                Id = d.Id
                            });
                        }
                    }
                } 
            }
            CertificateData(Certificado, out string certificado, out string numeroDeCertificado, out string _);
            this.DatosFiscal = new DTOs.Ventas.CFDi.DatosFiscales
            {
                Certificado = certificado,
                NoCertificado = numeroDeCertificado,
                RegimenFiscal = "601"
            };
            var ds = new DataSet();
            var complemento = contexto.th_venta_factura_comercio
      .Where(x => x.factura_Id == factura.First().Id)
      .ToList()
      .FirstOrDefault();
            if (complemento != null)
            {
                foreach (var item in tComprobante)
                {
                    item.Exportacion = "02";
                }
            }
            ds.Tables.Add(Excel.ToDataTable(tComprobante));
            ds.Tables.Add(Excel.ToDataTable(trelacion));
            ds.Tables.Add(Excel.ToDataTable(tEmisor));
            ds.Tables.Add(Excel.ToDataTable(tReceptor));
            ds.Tables.Add(Excel.ToDataTable(tconceptos));
            ds.Tables.Add(Excel.ToDataTable(ttraslados)); 
            ds.Tables.Add(Excel.ToDataTable(tretenidos));
            var impuestos = new List<DTOs.Ventas.CFDi.Impuestos>();
            if(ttraslados.Any() || tretenidos.Any())
            {
                var timpuestoD = new DTOs.Ventas.CFDi.Impuestos();
                if (ttraslados.Any())
                {
                    timpuestoD.TotalImpuestosTrasladados = Math.Round(ttraslados.Sum(x => x.Importe),2);
                }
                if (tretenidos.Any())
                {
                    timpuestoD.TotalImpuestosRetenidos = Math.Round(tretenidos.Sum(x => x.Importe), 2);
                }
                impuestos.Add(timpuestoD);
            }
             
            ds.Tables.Add(Excel.ToDataTable(impuestos));
            var Comprobante = DataSetToComprobante(ds);
            var ce = false;
            if (complemento != null)
            {
                ce = true;
                foreach (var item in tComprobante)
                {
                    item.Exportacion = "02";
                }
                DTOs.Ventas.CFDi.Comercio.ComercioExterior comercio = new DTOs.Ventas.CFDi.Comercio.ComercioExterior
                {
                    CertificadoOrigen = complemento.CertificadoOrigen.ToString(),
                    ClaveDePedimento = complemento.ClaveDePedimento,
                    Incoterm = complemento.Incoterm,
                    TipoCambioUSD = complemento.TipoCambioUSD,
                    TotalUSD = Math.Round(complemento.TotalUSD,2),                    
                    Version = complemento.Version,
                };
                var ceEmisor = contexto.th_venta_factura_comercio_emisor
                    .FirstOrDefault(x => x.factura_Id == factura.First().Id);
                var ceReceptor = contexto.th_venta_factura_comercio_receptor
                    .FirstOrDefault(x => x.factura_Id == factura.First().Id);
                var ceMercancias = contexto.th_venta_factura_comercio_mercancias
                    .Where(x => x.factura_Id == factura.First().Id)
                    .ToList();
                comercio.Emisor =  new DTOs.Ventas.CFDi.Comercio.Emisor
                {
                    Domicilio = new Domicilio{
                    Calle = ceEmisor.Calle,
                    CodigoPostal = ceEmisor.CodigoPostal,
                    Estado = ceEmisor.Estado,
                    Localidad = ceEmisor.Localidad,
                    NumeroExterior = ceEmisor.NumeroExterior,
                    Pais = ceEmisor.Pais
                    }
                }  ;
                comercio.Receptor = new DTOs.Ventas.CFDi.Comercio.Receptor
                {
                    NumRegIdTrib = ceReceptor.NumRegIdTrib,
                    Domicilio = new Domicilio
                    {
                        Calle = ceReceptor.Calle,
                        CodigoPostal = ceReceptor.CodigoPostal,
                        Estado = ceReceptor.Estado,
                        Municipio = ceReceptor.Municipio,
                        Pais = ceReceptor.Pais
                    }
                };
                comercio.Mercancias = ceMercancias.Select(x => new DTOs.Ventas.CFDi.Comercio.Mercancia
                {
                    CantidadAduana = x.CantidadAduana,
                    NoIdentificacion = x.NoIdentificacion,
                    FraccionArancelaria = x.FraccionArancelaria,
                    UnidadAduana = x.UnidadAduana,
                    ValorDolares = x.ValorDolares,
                    ValorUnitarioAduana = x.ValorUnitarioAduana
                }).ToList();
                var cexml = GenerarXMLCFDIComercio(comercio);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(cexml); 
                List<XmlElement> elements = new List<XmlElement>();
                elements.Add(xmlDoc.DocumentElement);
                Comprobante.Complemento = new ComprobanteComplemento { Any = elements };
            }
            string cadenaoriginal = CadenaOriginal(Comprobante,ce);
            string sello = Sellado(cadenaoriginal);
            Comprobante.Sello = sello;
            var XMLString = GenerarXMLCFDI<DTOs.SAT.Timbrado.Comprobante>(Comprobante, ce);
            XMLString = XMLString.Replace("<cfdi:Retenciones />", "");
            XMLString = XMLString.Replace("<cce20:ComercioExterior xmlns:cce20=\"http://www.sat.gob.mx/ComercioExterior20\" xmlns:xsi=\"http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior20/ComercioExterior20.xsd\"", "<cce20:ComercioExterior ");
            //XMLString = XMLString.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n", "");
            //XMLString = "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" + "\n" + XMLString;
            //XMLString = XMLString.Replace("xmlns:cce20=\"http://www.sat.gob.mx/ComercioExterior20\"", "");
            //XMLString = XMLString.Replace("http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/ComercioExterior20 http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior20/ComercioExterior20.xsd", "");
            //XMLString = XMLString.Replace("xsi:schemaLocation=\"http://www.sat.gob.mx/cfd/4 \"", "xmlns:cfdi=\"http://www.sat.gob.mx/cfd/4\"");
            //XMLString = XMLString.Replace("xmlns:cfdi=\"http://www.sat.gob.mx/cfd/4\"", "");
            //XMLString = XMLString.Replace("TotalImpuestosRetenidos=\"\"", "");
            //XmlDocument xmlDocAdd = new XmlDocument();
            //XmlDocument xmlDocOri = new XmlDocument();
            //DataSet dataset = new DataSet();
            //DataSet dataset2 = new DataSet();
            //dataset2.DataSetName = "cfdi";
            //using (StringReader xmlReader = new StringReader(XMLString))
            //{
            //    dataset.ReadXml(xmlReader);
            //}
            //foreach (DataTable table in dataset.Tables)
            //{
            //    var tabla = new DataTable();
            //    if (dataset2.Tables.Contains(table.TableName))
            //    {
            //        while (dataset2.Tables.Contains(table.TableName))
            //        {
            //            table.TableName = table.TableName + "_1";
            //        }
            //        tabla.TableName = table.TableName;
            //    }
            //    else
            //    {
            //        tabla.TableName = table.TableName;
            //    }

            //    foreach (DataColumn column in table.Columns)
            //    {
            //        tabla.Columns.Add(column.ColumnName,column.DataType);
            //    }
            //    foreach (DataRow rw in table.Rows)
            //    {
            //        tabla.Rows.Add(rw.ItemArray);
            //    }
            //    dataset2.Tables.Add(tabla);
            //}
            //xmlDocAdd.LoadXml(dataset2.GetXml());
            //xmlDocOri.LoadXml(XMLString);
            //var addenda = GenerateAddenda5(xmlDocOri, xmlDocAdd, RutaCadenaOriginal.Replace("cadenaoriginal_4_0.xslt", "fx_2010_g.xsd"));
            //var xmlAddenda = addenda.OuterXml;
            //xmlAddenda = xmlAddenda.Replace("<Addenda>", "<cfdi:Addenda>");
            //xmlAddenda = xmlAddenda.Replace("</Addenda>", "</cfdi:Addenda>");
            //return xmlAddenda;
            return XMLString;
        }
        public bool EsXmlValido(string xmlString)
        {
            try
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.LoadXml(xmlString);
                return true;
            }
            catch (XmlException)
            {
                return false;
            }
        }
        public string AddendarXML(string XMLString)
        {
            XmlDocument xmlDocAdd = new XmlDocument();
            XmlDocument xmlDocOri = new XmlDocument();
            DataSet dataset = new DataSet();
            DataSet dataset2 = new DataSet();
            dataset2.DataSetName = "cfdi";
            using (StringReader xmlReader = new StringReader(XMLString))
            {
                dataset.ReadXml(xmlReader);
            }
            foreach (DataTable table in dataset.Tables)
            {
                var tabla = new DataTable();
                if (dataset2.Tables.Contains(table.TableName))
                {
                    while (dataset2.Tables.Contains(table.TableName))
                    {
                        table.TableName = table.TableName + "_1";
                    }
                    tabla.TableName = table.TableName;
                }
                else
                {
                    tabla.TableName = table.TableName;
                }

                foreach (DataColumn column in table.Columns)
                {
                    tabla.Columns.Add(column.ColumnName, column.DataType);
                }
                foreach (DataRow rw in table.Rows)
                {
                    tabla.Rows.Add(rw.ItemArray);
                }
                dataset2.Tables.Add(tabla);
            }
            xmlDocAdd.LoadXml(dataset2.GetXml());
            xmlDocOri.LoadXml(XMLString);
            var addenda = GenerateAddenda5(xmlDocOri, xmlDocAdd, RutaCadenaOriginal.Replace("cadenaoriginal_4_0.xslt", "fx_2010_g.xsd"));
            var xmlAddenda = addenda.OuterXml;
            xmlAddenda = xmlAddenda.Replace("<Addenda>", "<cfdi:Addenda>");
            xmlAddenda = xmlAddenda.Replace("</Addenda>", "</cfdi:Addenda>");
            return xmlAddenda;

        }
        public   XmlDocument GenerateAddenda6(XmlDocument inputDoc, string xsdPath)
        {
            // Crear un esquema XML a partir del archivo .xsd
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, xsdPath);

            // Validar el documento XML existente contra el esquema
            inputDoc.Schemas.Add(schemas);
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación: {e.Message}");
            });

            // Crear un nuevo elemento addenda
            XmlElement addendaElement = inputDoc.CreateElement("Addenda");

            // Crear el nuevo elemento principal <ag:AgileMX> con namespace
            XmlElement agileMXElement = inputDoc.CreateElement("ag", "AgileMX", "http://www.example.com/ag");

            // Función recursiva para agregar namespace a todos los nodos hijos
            void AddNamespaceToChildren(XmlNode parentNode, XmlDocument doc)
            {
                foreach (XmlNode node in parentNode.ChildNodes)
                {
                    // Crear un nuevo elemento con el namespace 'ag:'
                    XmlElement newElement = doc.CreateElement("ag", node.LocalName, "http://www.example.com/ag");
                    newElement.InnerXml = node.InnerXml; // Copiar el contenido interno del nodo original

                    // Si el nodo tiene hijos, aplicar recursivamente
                    if (node.HasChildNodes)
                    {
                        AddNamespaceToChildren(node, doc);
                    }

                    parentNode.ReplaceChild(newElement, node);
                }
            }

            // Aplicar la función recursiva a los nodos del documento original
            AddNamespaceToChildren(inputDoc.DocumentElement, inputDoc);

            // Agregar el elemento <ag:AgileMX> dentro de <Addenda>
            addendaElement.AppendChild(agileMXElement);

            // Agregar el elemento <Addenda> al documento XML original
            inputDoc.DocumentElement.AppendChild(addendaElement);

            // Validar nuevamente para asegurarse de que la addenda cumple con el esquema
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación después de agregar addenda: {e.Message}");
            });

            return inputDoc;
        }
 

        public XmlDocument GenerateAddenda5(XmlDocument inputDoc, XmlDocument inputDocAddenda, string xsdPath)
        {
            // Crear un esquema XML a partir del archivo .xsd
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, xsdPath);

            // Validar el documento XML existente contra el esquema
            inputDoc.Schemas.Add(schemas);
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación: {e.Message}");
            });

            // Crear un nuevo elemento addenda
            XmlElement addendaElement = inputDoc.CreateElement("Addenda");
            
            // Crear el nuevo elemento principal <ag:AgileMX> con namespace
            XmlElement agileMXElement = inputDoc.CreateElement("ag", "AgileMX", "http://www.example.com/ag"); // Cambia el URI del namespace según corresponda

            // Recorrer los nodos del documento original y agregarlos a <ag:AgileMX>
            foreach (XmlNode node in inputDocAddenda.DocumentElement.ChildNodes)
            {
                // Crear un nuevo elemento con el namespace 'ag:'
                XmlElement importedNode = inputDoc.CreateElement("ag", node.LocalName, "http://www.example.com/ag");
                importedNode.InnerXml = node.InnerXml; // Copiar el contenido interno del nodo original

                agileMXElement.AppendChild(importedNode);
            }

            // Agregar el elemento <ag:AgileMX> dentro de <Addenda>
            addendaElement.AppendChild(agileMXElement);

            // Agregar el elemento <Addenda> al documento XML original
            inputDoc.DocumentElement.AppendChild(addendaElement);

            // Validar nuevamente para asegurarse de que la addenda cumple con el esquema
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación después de agregar addenda: {e.Message}");
            });

            return inputDoc;
        }
 

        public XmlDocument GenerateAddenda4(XmlDocument inputDoc, string xsdPath)
        {
            // Crear un esquema XML a partir del archivo .xsd
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, xsdPath);

            // Validar el documento XML existente contra el esquema
            inputDoc.Schemas.Add(schemas);
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación: {e.Message}");
            });

            // Crear un nuevo elemento addenda
            XmlElement addendaElement = inputDoc.CreateElement("Addenda");

            // Crear el nuevo elemento <ag:AgileMX> dentro de <Addenda>
            XmlElement agileMXElement = inputDoc.CreateElement("ag", "AgileMX", null);

            // Recorrer los nodos del documento original y agregarlos a <ag:AgileMX>
            foreach (XmlNode node in inputDoc.DocumentElement.ChildNodes)
            {
                XmlNode importedNode = inputDoc.ImportNode(node, true);
                agileMXElement.AppendChild(importedNode);
            }

            // Agregar el elemento <ag:AgileMX> dentro de <Addenda>
            addendaElement.AppendChild(agileMXElement);

            // Agregar el elemento <Addenda> al documento XML original
            inputDoc.DocumentElement.AppendChild(addendaElement);

            // Validar nuevamente para asegurarse de que la addenda cumple con el esquema
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación después de agregar addenda: {e.Message}");
            });

            return inputDoc;
        }
 

        public static XmlDocument GenerateAddenda3(XmlDocument inputDoc, string xsdPath)
        {
            // Crear un esquema XML a partir del archivo .xsd
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, xsdPath);

            // Validar el documento XML existente contra el esquema
            inputDoc.Schemas.Add(schemas);
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación: {e.Message}");
            });

            // Crear un nuevo elemento addenda
            XmlElement addendaElement = inputDoc.CreateElement("Addenda");

            // Recorrer los nodos del documento original y agregarlos a la addenda
            foreach (XmlNode node in inputDoc.DocumentElement.ChildNodes)
            {
                XmlNode importedNode = inputDoc.ImportNode(node, true);
                addendaElement.AppendChild(importedNode);
            }

            // Agregar el elemento addenda al documento XML original
            inputDoc.DocumentElement.AppendChild(addendaElement);

            // Crear el nuevo elemento principal <ag:AgileMX>
            XmlElement agileMXElement = inputDoc.CreateElement("ag", "AgileMX", null);

            // Agregar el elemento <ag:AgileMX> al documento XML original
            inputDoc.DocumentElement.AppendChild(agileMXElement);

            // Validar nuevamente para asegurarse de que la addenda cumple con el esquema
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación después de agregar addenda: {e.Message}");
            });

            return inputDoc;
        }
 

        public static XmlDocument GenerateAddenda2(XmlDocument inputDoc, string xsdPath)
        {
            // Crear un esquema XML a partir del archivo .xsd
            XmlSchemaSet schemas = new XmlSchemaSet();
            schemas.Add(null, xsdPath);

            // Validar el documento XML existente contra el esquema
            inputDoc.Schemas.Add(schemas);
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación: {e.Message}");
            });

            // Crear el nuevo elemento principal <ag:AgileMX>
            XmlElement agileMXElement = inputDoc.CreateElement("ag", "AgileMX", null);

            // Crear un nuevo elemento addenda dentro de <ag:AgileMX>
            XmlElement addendaElement = inputDoc.CreateElement("Addenda");

            // Recorrer los nodos del documento original y agregarlos a la addenda
            foreach (XmlNode node in inputDoc.DocumentElement.ChildNodes)
            {
                XmlNode importedNode = inputDoc.ImportNode(node, true);
                addendaElement.AppendChild(importedNode);
            }

            // Agregar el elemento addenda dentro de <ag:AgileMX>
            agileMXElement.AppendChild(addendaElement);

            // Agregar el elemento <ag:AgileMX> al documento XML original
            inputDoc.DocumentElement.AppendChild(agileMXElement);

            // Validar nuevamente para asegurarse de que la addenda cumple con el esquema
            inputDoc.Validate((sender, e) =>
            {
                throw new Exception($"Error de validación después de agregar addenda: {e.Message}");
            });

            return inputDoc;
        }
 
        public static XmlDocument GenerateAddenda(XmlDocument inputDoc, string xsdPath)
        {

            XmlSchemaSet schemas = new XmlSchemaSet(); schemas.Add(null, xsdPath);

            inputDoc.Schemas.Add(schemas);
            inputDoc.Validate((sender, e) => { throw new Exception($"Error de validación: {e.Message}"); });

            XmlElement addendaElement = inputDoc.CreateElement("Addenda");

            XmlElement customNode = inputDoc.CreateElement("CustomNode");
            customNode.InnerText = "Valor personalizado";
            addendaElement.AppendChild(customNode);

            inputDoc.DocumentElement.AppendChild(addendaElement);

            inputDoc.Validate((sender, e) => { throw new Exception($"Error de validación después de agregar addenda: {e.Message}"); }); return inputDoc;
        }
        private string Sellado(string cadenaoriginal)
        {
            return Sellar(cadenaoriginal, KeyFile, Password);
        }
        public string Sellar(string cadenaoriginal, byte[] BytesKey, string Password)
        {
            try
            {
                return DigitalSignature.SignStringSHA256(BytesKey, Password, cadenaoriginal);
            }
            catch (Exception)
            {
                return null;
            }
        }
        private string GenerarCadenaOriginal(XmlDocument xmlDocument, string rutaCadenaOriginal)
        {
            string resultado = null;
            using StringWriter stringWriter = new StringWriter();
            using XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter);
            XslCompiledTransform xslCompiledTransform = new XslCompiledTransform();
            xslCompiledTransform.Load(rutaCadenaOriginal, new XsltSettings(enableDocumentFunction: true, enableScript: true), new XmlUrlResolver());
            xslCompiledTransform.Transform(xmlDocument, null, xmlTextWriter);
            return stringWriter.ToString();
        }
        private string CadenaOriginal(DTOs.SAT.Timbrado.Comprobante Comprobante, bool CE)
        {
            XmlDocument xmlDocumentSeal = new XmlDocument();
            xmlDocumentSeal.LoadXml(GenerarXMLCFDI<DTOs.SAT.Timbrado.Comprobante>(Comprobante,CE));
            return GenerarCadenaOriginal(xmlDocumentSeal, RutaCadenaOriginal).Replace("&amp;", "&");
        }
        private string GenerarXMLCFDI<T>(DTOs.SAT.Timbrado.Comprobante comprobante, bool CE)
        {
            string resultado = null;
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("cfdi", "http://www.sat.gob.mx/cfd/4");
            xmlSerializerNamespaces.Add("xsi", "http://www.w3.org/2001/XMLSchema-instance");
            comprobante.XsiSchemaLocation = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd";
            if (CE)
            {
                xmlSerializerNamespaces.Add("cce20", "http://www.sat.gob.mx/ComercioExterior20");
                comprobante.XsiSchemaLocation = "http://www.sat.gob.mx/cfd/4 http://www.sat.gob.mx/sitio_internet/cfd/4/cfdv40.xsd http://www.sat.gob.mx/ComercioExterior20 http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior20/ComercioExterior20.xsd";
            }
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            using (Utf8StringWriter stringWriter = new Utf8StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
                {
                    xmlSerializer.Serialize(xmlWriter, comprobante, xmlSerializerNamespaces);
                }
                resultado = stringWriter.ToString().Trim();
            }
            resultado = resultado.Replace("<cfdi:CfdiRelacionados />\r\n", "");
            return resultado.Replace("<cfdi:Complemento />\r\n", "");
        }
        private string GenerarXMLCFDIComercio(ComercioExterior comprobante)
        {
            string resultado = null;
            XmlSerializerNamespaces xmlSerializerNamespaces = new XmlSerializerNamespaces();
            xmlSerializerNamespaces.Add("cce20", "http://www.sat.gob.mx/ComercioExterior20");
            xmlSerializerNamespaces.Add("xsi", "http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior20/ComercioExterior20.xsd");
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(ComercioExterior));
            XmlWriterSettings xmlWriterSettings = new XmlWriterSettings();
            xmlWriterSettings.Indent = true;
            using (Utf8StringWriter stringWriter = new Utf8StringWriter())
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(stringWriter, xmlWriterSettings))
                {
                    xmlSerializer.Serialize(xmlWriter, comprobante, xmlSerializerNamespaces);
                }
                resultado = stringWriter.ToString().Trim();
            }
            resultado = resultado.Replace("<ComercioExterior", "<cce20:ComercioExterior");
            resultado = resultado.Replace("</ComercioExterior>", "</cce20:ComercioExterior>");
            resultado = resultado.Replace("<Emisor", "<cce20:Emisor");
            resultado = resultado.Replace("</Emisor>", "</cce20:Emisor>");
            resultado = resultado.Replace("<Receptor", "<cce20:Receptor");
            resultado = resultado.Replace("</Receptor>", "</cce20:Receptor>");
            resultado = resultado.Replace("<Domicilio", "<cce20:Domicilio");
            resultado = resultado.Replace("<Mercancias", "<cce20:Mercancias");
            resultado = resultado.Replace("</Mercancias>", "</cce20:Mercancias>");
            resultado = resultado.Replace("<Mercancia", "<cce20:Mercancia");
            //resultado = resultado.Replace("xmlns:cce20=\"http://www.sat.gob.mx/ComercioExterior20\" xmlns:xsi=\"http://www.sat.gob.mx/sitio_internet/cfd/ComercioExterior20/ComercioExterior20.xsd\" ", "");
            resultado = resultado.Replace("<?xml version=\"1.0\" encoding=\"utf-8\"?>\r\n", "");
            //<?xml version="1.0" encoding="utf-8"?>
            return resultado ;
        }
        public DTOs.SAT.Timbrado.Comprobante DataSetToComprobante(DataSet datos)
        {
            DTOs.SAT.Timbrado.Comprobante comprobante = new DTOs.SAT.Timbrado.Comprobante();
            foreach (DataRow rw2 in datos.Tables[0].Rows)
            {
                comprobante.Version = rw2["Version"].ToString().Trim();
                comprobante.Serie = rw2["Serie"].ToString().Trim();
                comprobante.Folio = rw2["Folio"].ToString().Trim();
                comprobante.Fecha = Convert.ToDateTime(rw2["Fecha"]);
                comprobante.FormaPago = rw2["FormaPago"].ToString().Trim();
                comprobante.SubTotal = decimal.Round(Convert.ToDecimal(rw2["SubTotal"]), 2, MidpointRounding.AwayFromZero);
                if (Convert.ToString(rw2["Descuento"]) != "")
                {
                    comprobante.Descuento = Convert.ToString(rw2["Descuento"]);
                }
                comprobante.Moneda = rw2["Moneda"].ToString().Trim();
                if (comprobante.Moneda != "MXN")
                {
                    comprobante.TipoCambio = Convert.ToString(rw2["TipoCambio"]);
                }
                comprobante.Total = decimal.Round(Convert.ToDecimal(rw2["Total"]), 2, MidpointRounding.AwayFromZero);
                comprobante.Exportacion = rw2["Exportacion"].ToString().Trim();
                comprobante.TipoDeComprobante = rw2["TipoDeComprobante"].ToString().Trim();
                comprobante.MetodoPago = rw2["MetodoPago"].ToString().Trim();
                comprobante.LugarExpedicion = rw2["LugarExpedicion"].ToString().Trim();
                comprobante.Certificado = DatosFiscal.Certificado;
                comprobante.NoCertificado = DatosFiscal.NoCertificado;
            }
            foreach (DataRow rw4 in datos.Tables[1].Rows)
            {
                if (comprobante.CfdiRelacionados == null)
                {
                    comprobante.CfdiRelacionados = new ComprobanteCfdiRelacionados();
                }
                comprobante.CfdiRelacionados.TipoRelacion = rw4["TipoRelacion"].ToString().Trim();
                ComprobanteCfdiRelacionadosCfdiRelacionado cfdiRelacionado = new ComprobanteCfdiRelacionadosCfdiRelacionado();
                cfdiRelacionado.UUID = rw4["UUID"].ToString().Trim();
                comprobante.CfdiRelacionados.CfdiRelacionado.Add(cfdiRelacionado);
            }
            ComprobanteEmisor emisor = new ComprobanteEmisor();
            foreach (DataRow rw6 in datos.Tables[2].Rows)
            {
                emisor.Rfc = rw6["Rfc"].ToString().Trim();
                emisor.Nombre = rw6["Nombre"].ToString().Trim();
                emisor.RegimenFiscal = rw6["RegimenFiscal"].ToString().Trim();
                comprobante.Emisor = emisor;
            }
            ComprobanteReceptor receptor = new ComprobanteReceptor();
            foreach (DataRow rw5 in datos.Tables[3].Rows)
            {
                receptor.Rfc = rw5["Rfc"].ToString().Trim();
                receptor.Nombre = rw5["Nombre"].ToString().Trim();
                receptor.DomicilioFiscalReceptor = rw5["DomicilioFiscalReceptor"].ToString().Trim();
                receptor.RegimenFiscalReceptor = rw5["RegimenFiscalReceptor"].ToString().Trim();
                receptor.UsoCFDI = rw5["UsoCFDI"].ToString().Trim();
                if (rw5["ResidenciaFiscal"] != DBNull.Value && rw5["ResidenciaFiscal"] != null)
                {
                    receptor.ResidenciaFiscal = rw5["ResidenciaFiscal"].ToString();
                }
                if (rw5["NumRegIdTrib"] != DBNull.Value && rw5["NumRegIdTrib"] != null)
                {
                    receptor.NumRegIdTrib = rw5["NumRegIdTrib"].ToString();
                }
                comprobante.Receptor = receptor;
            }
            new List<ComprobanteConcepto>();
            DataTable dt_Conceptos = datos.Tables[4];
            DataTable dt_impuesto = datos.Tables[5];
            DataTable dt_impuestoRet = datos.Tables[6];
            foreach (DataRow _impuesto in dt_impuestoRet.Rows)
            {
                dt_impuesto.Rows.Add(_impuesto.ItemArray);
            }
            foreach (DataRow _concepto in dt_Conceptos.Rows)
            {
                if (comprobante.Conceptos == null)
                {
                    comprobante.Conceptos = new List<ComprobanteConcepto>();
                }
                ComprobanteConcepto concepto = new ComprobanteConcepto();
                concepto.Cantidad = Convert.ToDecimal(_concepto["Cantidad"]);
                concepto.NoIdentificacion = Convert.ToString(_concepto["NoIdentificacion"]).Trim();
                concepto.ClaveProdServ = Convert.ToString(_concepto["ClaveProdServ"]).Trim();
                concepto.ClaveUnidad = Convert.ToString(_concepto["ClaveUnidad"]).Trim();
                concepto.Descripcion = Convert.ToString(_concepto["Descripcion"]).Trim();
                if (Convert.ToString(_concepto["Descuento"]) != "")
                {
                    concepto.Descuento = Convert.ToString(_concepto["Descuento"]);
                }
                concepto.Importe = decimal.Round(Convert.ToDecimal(_concepto["Importe"]), 6, MidpointRounding.AwayFromZero);
                concepto.ObjetoImp = Convert.ToString(_concepto["ObjetoImp"]).Trim();
                concepto.ValorUnitario = decimal.Round(Convert.ToDecimal(_concepto["ValorUnitario"]), 6, MidpointRounding.AwayFromZero);
                concepto.Unidad = Convert.ToString(_concepto["Unidad"]).Trim();
                foreach (DataRow _impuesto in dt_impuesto.Rows)
                {
                    if (Convert.ToInt32(_concepto["Id"]) == Convert.ToInt32(_impuesto["id"]))
                    {
                        if (concepto.Impuestos == null)
                        {
                            concepto.Impuestos = new ComprobanteConceptoImpuestos();
                        }
                        if (concepto.Impuestos.Traslados == null)
                        {
                            concepto.Impuestos.Traslados = new List<ComprobanteConceptoImpuestosTraslado>();
                        }
                        if (concepto.Impuestos.Retenciones == null)
                        {
                            concepto.Impuestos.Retenciones = new List<ComprobanteConceptoImpuestosRetencion>();
                        }
                        if (Convert.ToDecimal(_impuesto["TasaOCuota"]) < 0)
                        {
                            ComprobanteConceptoImpuestosRetencion retencion2 = new ComprobanteConceptoImpuestosRetencion();
                            retencion2.Base = decimal.Round(Convert.ToDecimal(_impuesto["Base"]), 6, MidpointRounding.AwayFromZero);
                            retencion2.Importe = Math.Abs(decimal.Round(Convert.ToDecimal(_impuesto["Importe"]), 6, MidpointRounding.AwayFromZero));
                            retencion2.Impuesto = Convert.ToString(_impuesto["Impuesto"]);
                            retencion2.TipoFactor = Convert.ToString(_impuesto["TipoFactor"]).Trim();
                            retencion2.TasaOCuota = Math.Abs(decimal.Round(Convert.ToDecimal(_impuesto["TasaOCuota"]), 6, MidpointRounding.AwayFromZero));
                            concepto.Impuestos.Retenciones.Add(retencion2);
                        }
                        else
                        {
                            ComprobanteConceptoImpuestosTraslado traslado2 = new ComprobanteConceptoImpuestosTraslado();
                            traslado2.Base = decimal.Round(Convert.ToDecimal(_impuesto["Base"]), 6, MidpointRounding.AwayFromZero);
                            traslado2.Importe = decimal.Round(Convert.ToDecimal(_impuesto["Importe"]), 6, MidpointRounding.AwayFromZero);
                            traslado2.Impuesto = Convert.ToString(_impuesto["Impuesto"]);
                            traslado2.TipoFactor = Convert.ToString(_impuesto["TipoFactor"]).Trim();
                            traslado2.TasaOCuota = decimal.Round(Convert.ToDecimal(_impuesto["TasaOCuota"]), 6, MidpointRounding.AwayFromZero);
                            concepto.Impuestos.Traslados.Add(traslado2);
                        }
                    }
                }
                comprobante.Conceptos.Add(concepto);
            }
            List<ComprobanteConceptoImpuestosTraslado> traslado1 = null;
            List<ComprobanteConceptoImpuestosRetencion> retencion1 = null;
            foreach (var concepto in comprobante.Conceptos)
            {
                if (concepto.Impuestos != null)
                {
                    if (concepto.Impuestos.Traslados != null)
                    {
                        if (concepto.Impuestos.Traslados.Any())
                        {
                            if (traslado1 == null)
                            {
                                traslado1 = new List<ComprobanteConceptoImpuestosTraslado>();
                            }
                            traslado1.AddRange(concepto.Impuestos.Traslados);
                        }
                    }
                    if (concepto.Impuestos.Retenciones != null)
                    {
                        if (concepto.Impuestos.Retenciones.Any())
                        {
                            if (retencion1 == null)
                            {
                                retencion1 = new List<ComprobanteConceptoImpuestosRetencion>();
                            }
                            retencion1.AddRange(concepto.Impuestos.Retenciones);
                        }
                    }                        
                }
            }
            if (traslado1 != null || retencion1 != null)
            {
                comprobante.Impuestos = new ComprobanteImpuestos();
                if (traslado1 != null)
                {
                    comprobante.Impuestos.TotalImpuestosTrasladados = Convert.ToString(traslado1.Sum(x=>x.Importe));
                    var impuestos_traslados = traslado1.Select(x => new { x.Impuesto, x.TipoFactor, x.TasaOCuota }).Distinct();
                    foreach (var impuesto in impuestos_traslados)
                    {
                        if (comprobante.Impuestos.Traslados == null)
                        {
                            comprobante.Impuestos.Traslados = new List<ComprobanteImpuestosTraslado>();
                        }
                        ComprobanteImpuestosTraslado traslado = new ComprobanteImpuestosTraslado();
                        traslado.Impuesto = impuesto.Impuesto;
                        traslado.TipoFactor = impuesto.TipoFactor;
                        traslado.TasaOCuota = impuesto.TasaOCuota;
                        traslado.Base = traslado1.Where(x => x.Impuesto == traslado.Impuesto && x.TasaOCuota == impuesto.TasaOCuota && x.TipoFactor == impuesto.TipoFactor).Sum(x => x.Base);
                        traslado.Importe = traslado1.Where(x => x.Impuesto == traslado.Impuesto && x.TasaOCuota == impuesto.TasaOCuota && x.TipoFactor == impuesto.TipoFactor).Sum(x => x.Importe);
                        comprobante.Impuestos.Traslados.Add(traslado);
                    }
                }
                if (retencion1 != null)
                {
                    comprobante.Impuestos.TotalImpuestosRetenidos = Convert.ToString(retencion1.Sum(x => x.Importe));
                    var impuestos_retenciones = retencion1.Select(x => new { x.Impuesto, x.TipoFactor, x.TasaOCuota }).Distinct();
                    foreach (var impuesto in impuestos_retenciones)
                    {
                        if (comprobante.Impuestos.Retenciones == null)
                        {
                            comprobante.Impuestos.Retenciones = new List<ComprobanteImpuestosRetencion>();
                        }
                        ComprobanteImpuestosRetencion retencion = new ComprobanteImpuestosRetencion();
                        retencion.Impuesto = impuesto.Impuesto;
                        //retencion.TipoFactor = impuesto.TipoFactor;
                        //retencion.TasaOCuota = impuesto.TasaOCuota;
                        //retencion.Base = retencion1.Where(x => x.Impuesto == retencion.Impuesto && x.TasaOCuota == impuesto.TasaOCuota && x.TipoFactor == impuesto.TipoFactor).Sum(x => x.Base);
                        retencion.Importe = retencion1.Where(x => x.Impuesto == retencion.Impuesto && x.TasaOCuota == impuesto.TasaOCuota && x.TipoFactor == impuesto.TipoFactor).Sum(x => x.Importe);
                        comprobante.Impuestos.Retenciones.Add(retencion);
                    }
                }
        

            //foreach (DataRow rw in datos.Tables[7].Rows)
            //{
            //    comprobante.Impuestos = new ComprobanteImpuestos();
            //    comprobante.Impuestos.TotalImpuestosTrasladados = Convert.ToString(rw["TotalImpuestosTrasladados"]);
            //    comprobante.Impuestos.TotalImpuestosRetenidos = Convert.ToString(rw["TotalImpuestosRetenidos"]);
            //    foreach (DataRow rwi in datos.Tables[5].Rows)
            //    {
            //        if (comprobante.Impuestos.Traslados == null)
            //        {
            //            comprobante.Impuestos.Traslados = new List<ComprobanteImpuestosTraslado>();
            //        }
            //        ComprobanteImpuestosTraslado traslado = new ComprobanteImpuestosTraslado();
            //        traslado.Base = Convert.ToDecimal(rwi["Base"]);
            //        traslado.Importe = Convert.ToDecimal(rwi["Importe"]);
            //        traslado.Impuesto = Convert.ToString(rwi["Impuesto"]).Trim();
            //        traslado.TipoFactor = Convert.ToString(rwi["TipoFactor"]).Trim();
            //        traslado.TasaOCuota = Convert.ToDecimal(rwi["TasaOCuota"]);
            //        if(comprobante.Impuestos.Traslados.Where(x=>x.Impuesto == traslado.Impuesto).Any())
            //        {
            //            foreach (var itemImpuesto in comprobante.Impuestos.Traslados.Where(x => x.Impuesto == traslado.Impuesto))
            //            {
            //                itemImpuesto.Base += traslado.Base;
            //                itemImpuesto.Importe += traslado.Importe;
            //            }
            //        }
            //        else
            //        {
            //            comprobante.Impuestos.Traslados.Add(traslado);
            //        }
                    
            //    }
                //foreach (DataRow rwi in datos.Tables[6].Rows)
                //{
                //    if (comprobante.Impuestos.Retenciones == null)
                //    {
                //        comprobante.Impuestos.Retenciones = new List<ComprobanteImpuestosRetencion>();
                //        ComprobanteImpuestosRetencion retencion = new ComprobanteImpuestosRetencion();
                //        retencion.Importe = Convert.ToDecimal(rwi["Importe"]);
                //        retencion.Impuesto = Convert.ToString(rwi["Impuesto"]).Trim();
                //        comprobante.Impuestos.Retenciones.Add(retencion);
                //    }
                //}
            }
            return comprobante;
        }
    }
}
