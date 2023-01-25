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

        //METODO PARA RECUPERAR TODA LA PLANTILLA
        public List<Plantilla> GetPlantilla()
        {
            var consulta = from datos in this.context.plant
                           select datos;
            return consulta.ToList();
        }

        //Metodo para buscar los empleados por el idhospital
        public List<Plantilla> FindPlantillaHospital(int idhospital)
        {
            var consulta = from datos in context.plant
                           where datos.HospitalCod == idhospital
                           select datos;
            return consulta.ToList();
        }

        //Metodo para buscar un empleado por su id
        public Plantilla FindEmpleado(int id)
        {
            var consulta = from datos in context.plant
                           where datos.EmpleadoCod == id
                           select datos;
            return consulta.FirstOrDefault();
        }
        //Metodo para buscar los empleados por su funcion
        public List<Plantilla> GetPlantillaByFuncion(string funcion)
        {
            var consulta = from datos in this.context.plant
                           where datos.Funcion == funcion
                           select datos;
            return consulta.ToList();
        }

        //METODO PARA RECUPERAR LAS FUNCIONES PARA UN SELECT
        public List<string> GetFunciones()
        {
            var consulta = (from datos in this.context.plant
                            select datos.Funcion).Distinct();
            return consulta.ToList();
        }
    }
}
