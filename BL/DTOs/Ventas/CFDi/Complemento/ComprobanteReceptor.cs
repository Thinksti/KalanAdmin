using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BL.DTOs.Ventas.CFDi.Complemento
{
    public class ComprobanteReceptor
    {
        private string rfcField;

        private string nombreField;

        private string domicilioFiscalReceptorField;

        private string residenciaFiscalField;

        private string numRegIdTribField;

        private string regimenFiscalReceptorField;

        private string usoCFDIField;

        [XmlAttribute]
        public string Rfc
        {
            get
            {
                return rfcField;
            }
            set
            {
                rfcField = value;
            }
        }

        [XmlAttribute]
        public string Nombre
        {
            get
            {
                return nombreField;
            }
            set
            {
                nombreField = value;
            }
        }

        [XmlAttribute]
        public string DomicilioFiscalReceptor
        {
            get
            {
                return domicilioFiscalReceptorField;
            }
            set
            {
                domicilioFiscalReceptorField = value;
            }
        }

        [XmlIgnore]
        public string ResidenciaFiscal
        {
            get
            {
                return residenciaFiscalField;
            }
            set
            {
                residenciaFiscalField = value;
            }
        }

        [XmlIgnore]
        public string NumRegIdTrib
        {
            get
            {
                return numRegIdTribField;
            }
            set
            {
                numRegIdTribField = value;
            }
        }

        [XmlAttribute]
        public string RegimenFiscalReceptor
        {
            get
            {
                return regimenFiscalReceptorField;
            }
            set
            {
                regimenFiscalReceptorField = value;
            }
        }

        [XmlAttribute]
        public string UsoCFDI
        {
            get
            {
                return usoCFDIField;
            }
            set
            {
                usoCFDIField = value;
            }
        }
    }
}