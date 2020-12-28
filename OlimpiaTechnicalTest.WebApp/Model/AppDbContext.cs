using Microsoft.EntityFrameworkCore;
using OlimpiaTechnicalTest.WebApp.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OlimpiaTechnicalTest.WebApp.Model
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {   }
        public DbSet<Estadio> Estadios { get; set; }
        public DbSet<Acceso> Accesos { get; set; }
        public DbSet<Aficionado> Aficionados { get; set; }
        public DbSet<EstadoAficionado> EstadoAficionados { get; set; }
    }
}
