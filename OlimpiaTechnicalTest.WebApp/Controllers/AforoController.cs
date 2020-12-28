using Microsoft.AspNetCore.Mvc;
using OlimpiaTechnicalTest.WebApp.Model;
using OlimpiaTechnicalTest.WebApp.Model.Entities;
using System;
using System.Linq;

namespace OlimpiaTechnicalTest.WebApp.Controllers
{
    public class AforoController : ControllerBase
    {
        private readonly AppDbContext _db;

        public AforoController(AppDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public Estadio GetEstadioInfo()
        {
            var result = (from o in _db.Estadios.ToList()
                          where o.Nombre == "Estadio de AC Milan"
                          select o).First();
            return result;
        }
        [HttpGet]
        public Aficionado GetAficionado(string NroIdentificacion)
        {
            var result = (from o in _db.Aficionados.ToList()
                          where o.NroIdentificacion == NroIdentificacion
                          select o).First();
            return result;
        }
        [HttpGet, ActionName("CanEnter")]
        public bool CanEnterAficionado()
        {
            var result = (from o in _db.Estadios.ToList()
                          where o.Nombre == "Estadio de AC Milan"
                          select o).First();
            var OcupacionMaxima = (result.PorcentajeOcupacionMaximo * result.CapacidadMaxima) / 100;

            return !(result.OcupacionActual++ > OcupacionMaxima);
        }
        [HttpPost]
        public bool AddAficionado([FromBody] Aficionado aficionado)
        {
            _db.Add<Aficionado>(aficionado);
            _db.SaveChanges();

            var estadio = (from o in _db.Estadios.ToList()
                           where o.Nombre == "Estadio de AC Milan"
                           select o).First();

            estadio.OcupacionActual++;

            _db.EstadoAficionados.Add(new EstadoAficionado()
            {
                Aficionado = aficionado,
                AficionadoId = aficionado.Id,
                Estadio = estadio,
                EstadioId = estadio.Id,
                Entrada = DateTime.Now
            });

            _db.Update(estadio);

            _db.SaveChanges();
            return true;
        }
        [HttpPut, ActionName("Out")]
        public bool OutAficionado([FromBody] string aficionadoNroDocumento)
        {
            
            var aficionados = (from o in _db.Aficionados.ToList()
                           where o.NroIdentificacion == aficionadoNroDocumento
                           select o);

            foreach (var aficionado in aficionados)
            {
                var estadoAficionados = (from o in _db.EstadoAficionados.ToList()
                                         where o.AficionadoId == aficionado.Id
                                         select o);

                foreach (var estadioAficionado in estadoAficionados)
                {
                    estadioAficionado.Salida = DateTime.Now;

                    var estadio = (from o in _db.Estadios
                                   where o.Id == estadioAficionado.EstadioId
                                   select o).First();

                    estadio.OcupacionActual--;

                    _db.Update<Estadio>(estadio);
                    _db.Update<EstadoAficionado>(estadioAficionado);
                }
            }
            _db.SaveChanges();

            return true;
        }
    }
}
