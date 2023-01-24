using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryHospital
    {
        private HospitalContext context;

        public RepositoryHospital(HospitalContext context)
        {
            this.context = context;
        }

        //CREAMOS NUESTROS METODOS PARA RECUPERAR DATOS
        public List<Hospital> GetHospitales()
        {
            var consulta = from datos in this.context.Hospitales
                           select datos;
            return consulta.ToList();
        }

        //METODO PARA DEVOLVER UN SOLO HOSPITAL
        public Hospital FindHospital(int id)
        {
            var consulta = from datos in this.context.Hospitales
                           where datos.IdHospital== id
                           select datos;
            // COMO SOLO DEVUELVE UN HOSPITAL PODEMOS UTILIZAR EL METODO .First() o .FirstOrDefault()
            // First daria fallo en caso de no enonctraro y FirstOrDefault daria un numero 0 en caso de no encontrarlo
            return consulta.FirstOrDefault();
        }
    }
}
