using System.Xml.Serialization;

namespace KalanBlazor.DTOs.Ventas.CFDi.Comercio
{
    public class Mercancia
    {
        [XmlAttribute]
        public string NoIdentificacion { get; set; }
        [XmlAttribute]
        public string FraccionArancelaria { get; set; }
        [XmlAttribute]
        public decimal CantidadAduana { get; set; }
        [XmlAttribute]
        public string UnidadAduana { get; set; }
        [XmlAttribute]
        public decimal ValorUnitarioAduana { get; set; }
        [XmlAttribute]
        public decimal ValorDolares { get; set; }
    }
}
