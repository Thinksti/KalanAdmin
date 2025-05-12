using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Kalan.Componentes
{
    public class ResponsiveColumnCalculator
    {
        public static (string colXl, string colLg, string colMd, string colSm) CalculateResponsiveColumns(int colXlValue)
        {
            // Validar que el valor de col-xl esté entre 1 y 12
            if (colXlValue < 1 || colXlValue > 12)
            {
                throw new ArgumentException("El valor de col-xl debe estar entre 1 y 12.");
            }

            // Calcular los valores para las otras clases
            int colLgValue = Math.Min(colXlValue + 1, 12); // col-lg = col-xl + 1 (máximo 12)
            int colMdValue = Math.Min(colXlValue + 3, 12); // col-md = col-xl + 3 (máximo 12)
            int colSmValue = 12; // col-sm siempre es 12 (ocupa todo el ancho en pantallas pequeñas)

            // Devolver las clases en formato Bootstrap
            return (
                colXl: $"col-xl-{colXlValue}",
                colLg: $"col-lg-{colLgValue}",
                colMd: $"col-md-{colMdValue}",
                colSm: $"col-sm-{colSmValue}"
            );
        }
    }
}
