using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;

namespace BL.DTOs.Ventas.CFDi.Complemento
{
    public class ComprobanteComplemento
    {
        private List<XmlElement> anyField;

        [XmlAnyElement]
        public List<XmlElement> Any
        {
            get
            {
                return anyField;
            }
            set
            {
                anyField = value;
            }
        }

        public ComprobanteComplemento()
        {
            anyField = new List<XmlElement>();
        }
    }
}