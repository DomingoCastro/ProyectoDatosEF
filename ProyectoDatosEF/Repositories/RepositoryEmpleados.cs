using ProyectoDatosEF.Data;
using ProyectoDatosEF.Models;

namespace ProyectoDatosEF.Repositories
{
    public class RepositoryEmpleados
    {
        private HospitalContext context;

        public RepositoryEmpleados(HospitalContext context)
        {
            this.context = context;
        }
        //METODO PARA RECUPERAR TODA LA PLANTILLA
        public List<Empleados> GetEmpleados()
        {
            var consulta = from datos in this.context.Empleados
                           select datos;
            return consulta.ToList();
        }

        //Metodo para buscar los empleados por el idhospital
        public List<Empleados> FindEmpleados(string oficio)
        {
            var consulta = from datos in context.Empleados
                           where datos.Oficio == oficio
                           select datos;
            return consulta.ToList();
        }

        //Metodo para buscar un empleado por su id
        public Empleados FindEmpleado(int id)
        {
            var consulta = from datos in context.Empleados
                           where datos.empid == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        //METODO PARA RECUPERAR LAS FUNCIONES PARA UN SELECT
        public List<string> GetFuncionesemp()
        {
            var consulta = (from datos in this.context.Empleados
                            select datos.Oficio).Distinct();
            return consulta.ToList();
        }

        //METODO PARA MODIFICAR UN HOSPITAL
        public void UpdateEmpleado(string oficio, int incremento)
        {
            //DEBEMOS BUSCAR EL HOSPITAL A MODIFICAR
            List<Empleados> empleados = this.FindEmpleados(oficio);
            //MODIFCAMOS SUS PROPIEDADES(NUNCA SE DEBE MODIFICAR EL ID DE UN DATO)
            foreach (Empleados empleado in empleados)
            {
                empleado.Salario = empleado.Salario + incremento;
            }
            //EN UPDATE SIMPLEMENTE GUARDAMOS LOS DATOS EN BBDD
            this.context.SaveChanges();
        }








    }
}