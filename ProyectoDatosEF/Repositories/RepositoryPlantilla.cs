using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryPlantilla
    {
        private HospitalContext context;
        public RepositoryPlantilla(HospitalContext context)
        {
            this.context = context;
        }
        public List<Plantilla> GetPlantilla()
        {
            var consulta = from datos in this.context.plant
                           select datos;
            return consulta.ToList();
        }
        public List<Plantilla> FindPlantillaHospital(int idhospital)
        {
            var consulta = from datos in context.plant
                           where datos.HospitalCod == idhospital
                           select datos;
            return consulta.ToList();
        }
        public Plantilla FindEmpleado(int id)
        {
            var consulta = from datos in context.plant
                           where datos.EmpleadoCod == id
                           select datos;
            return consulta.FirstOrDefault();
        }
        public List<Plantilla> GetPlantillaByFuncion(string funcion)
        {
            var consulta = from datos in this.context.plant
                           where datos.Funcion == funcion
                           select datos;
            return consulta.ToList();
        }
        public List<string> GetFunciones()
        {
            var consulta = (from datos in this.context.plant
                            select datos.Funcion).Distinct();
            return consulta.ToList();
        }
    }
}
