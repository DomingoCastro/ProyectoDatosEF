using Microsoft.EntityFrameworkCore;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Data
{
    public class HospitalContext :DbContext
    {
        //NECESITAMOS UN CONSTRUCTOR OBLIGATORIO PARA PODER RECIBIR LA CADENA DE CONEXION
        public HospitalContext(DbContextOptions<HospitalContext> options) : base(options) { }

        // DEBEMOS MAPEAR CADA CLASE MODEL DE LA BASE DE DATOS CON UN OBJETO
        // DbSet. CADA TABLA DE LA BASE DE DATOS SERA UN DbSet CON UN MODEL.
        //NOSOTROS HAREMOS LA CONSULTAS A DICHO DbSet
        public DbSet<Hospital> Hospitales { get; set; }
        public DbSet<Doctor> Doctores { get; set; }
        public DbSet<Plantilla> plant { get; set; }
        public DbSet<Empleados> Empleados { get; set;}
    }
}
