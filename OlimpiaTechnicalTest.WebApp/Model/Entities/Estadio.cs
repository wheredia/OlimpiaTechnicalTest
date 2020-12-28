using System.Collections.Generic;

namespace OlimpiaTechnicalTest.WebApp.Model.Entities
{
    public class Estadio
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int CapacidadMaxima { get; set; }
        public int PorcentajeOcupacionMaximo { get; set; }
        public int OcupacionActual { get; set; }
        public ICollection<Acceso> Accesos { get; set; }
    }
}
