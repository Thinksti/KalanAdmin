namespace KalanBlazor.DTOs.Financiero
{
    public class ListadoConciliaciones
    {

        public string Chequera { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public decimal SaldoBanco { get; set; }

        public decimal Diferencia { get; set; }

        public bool Terminada { get; set; }

        public string Justificacion { get; set; }


        public string? Usuario { get; set; }

        public DateTime? Fecha { get; set; }
    }
}
