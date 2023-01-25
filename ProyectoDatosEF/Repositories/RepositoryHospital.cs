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
        //METODO PARA INSERTAR HOSPITAL
        public void InsertHospital(int idhospital)
        {
            Hospital hospital = new Hospital();
            hospital.IdHospital = idhospital;
            hospital.Nombre = "NUEVO";
            hospital.Telefono = "NUEVO";
            hospital.Camas = 99;
            hospital.Direccion = "Calle nueva";
            // INsertamos el hospital en el context y su dbset
            this.context.Hospitales.Add(hospital);
            //Guardamos los cambios en la BBDD
            this.context.SaveChanges();

        }

        //METODO PARA ELIMINAR UN HOSPITAL

        public void DeleteHospital(int idhospital)
        {
            //DEBEMOS BUSCAR EL HOSPITAL A ELIMINAR
            Hospital hospital = this.FindHospital(idhospital);
            this.context.Hospitales.Remove(hospital);
            this.context.SaveChanges();
        }

        //METODO PARA MODIFICAR UN HOSPITAL
        public void UpdateHospital(int idhospital)
        {
            //DEBEMOS BUSCAR EL HOSPITAL A MODIFICAR
            Hospital hospital = this.FindHospital(idhospital);
            //MODIFCAMOS SUS PROPIEDADES(NUNCA SE DEBE MODIFICAR EL ID DE UN DATO)
            hospital.Direccion = "Calle Updated";
            hospital.Nombre = "UPDATED";
            hospital.Telefono = "555 18 39";
            hospital.Camas = 14;
            //EN UPDATE SIMPLEMENTE GUARDAMOS LOS DATOS EN BBDD
            this.context.SaveChanges();
        }
    }
}
