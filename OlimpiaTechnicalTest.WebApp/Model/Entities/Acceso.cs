namespace OlimpiaTechnicalTest.WebApp.Model.Entities
{
    public class Acceso
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int EstadioId { get; set; }
        public Estadio Estadio { get; set; }
    }
}
