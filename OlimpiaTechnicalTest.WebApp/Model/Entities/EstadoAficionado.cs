using System;

namespace OlimpiaTechnicalTest.WebApp.Model.Entities
{
    public class EstadoAficionado
    {
        public int Id { get; set; }
        public int EstadioId { get; set; }
        public int AficionadoId { get; set; }
        public Estadio Estadio { get; set; }
        public Aficionado Aficionado { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime? Salida { get; set; }
    }
}
