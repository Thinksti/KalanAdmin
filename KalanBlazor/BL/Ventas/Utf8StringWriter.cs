using System.Text;

namespace KalanBlazor.BL.Ventas
{
    public class Utf8StringWriter : StringWriter
    {
        public override Encoding Encoding => System.Text.Encoding.UTF8;
    }
}
