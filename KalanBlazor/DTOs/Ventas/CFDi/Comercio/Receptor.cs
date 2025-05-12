using System.Xml.Serialization;

namespace KalanBlazor.DTOs.Ventas.CFDi.Comercio
{
    public class Receptor
    {
        [XmlAttribute]
        public string NumRegIdTrib { get; set; }
        public Domicilio Domicilio { get; set; }
    }
}
