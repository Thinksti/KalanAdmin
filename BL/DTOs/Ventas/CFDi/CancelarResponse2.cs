namespace KalanBlazor.DTOs.Ventas.CFDi
{
    public class CancelarResponse2
    {
        private int codeField;

        private string messageField;

        private string idField;

        private string detailField;
        public List<AcuseDatos> AcuseDatos { get; set; }

        public string XML { get; set; }

        public int Code
        {
            get
            {
                return codeField;
            }
            set
            {
                codeField = value;
            }
        }

        public string Message
        {
            get
            {
                return messageField;
            }
            set
            {
                messageField = value;
            }
        }

        public string Id
        {
            get
            {
                return idField;
            }
            set
            {
                idField = value;
            }
        }

        public string Detail
        {
            get
            {
                return detailField;
            }
            set
            {
                detailField = value;
            }
        }
    }
}
