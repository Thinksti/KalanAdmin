using System.Xml.Serialization;

namespace KalanBlazor.DTOs.Ventas.CFDi.Comercio
{
    public class ComercioExterior
    {
        [XmlAttribute]
        public string Version { get; set; }
        [XmlAttribute]
        public string ClaveDePedimento { get; set; }
        [XmlAttribute]
        public string CertificadoOrigen { get; set; }
        [XmlAttribute]
        public string Incoterm { get; set; }
        [XmlAttribute]
        public decimal TipoCambioUSD { get; set; }
        [XmlAttribute]
        public decimal TotalUSD { get; set; }
       
        public Emisor Emisor { get; set; }
      
        public Receptor Receptor { get; set; }
       
        public List<Mercancia> Mercancias { get; set; }

    }
}
