using System.Xml.Serialization;

namespace KalanBlazor.DTOs.Ventas.CFDi.Comercio
{
    public class Domicilio
    {
        [XmlAttribute]
        public string Calle { get; set; }
        [XmlAttribute]
        public string NumeroExterior { get; set; }
        [XmlAttribute]
        public string Localidad { get; set; }
        [XmlAttribute]
        public string Estado { get; set; }
        [XmlAttribute]
        public string Pais { get; set; }
        [XmlAttribute]
        public string CodigoPostal { get; set; }
        [XmlAttribute]
        public string Municipio { get; set; }

    }
}
