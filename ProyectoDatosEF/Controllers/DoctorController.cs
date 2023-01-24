using Microsoft.AspNetCore.Mvc;
using ProyectoDatosEF.Models;
using ProyectoDatosEF.Repositories;

namespace ProyectoDatosEF.Controllers
{
    public class DoctorController : Controller
    {
        private RepositoryDoctor repo;

        public DoctorController(RepositoryDoctor repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Doctor> doctores = this.repo.GetDoctors();
            return View(doctores);
        }
        public IActionResult DoctoresHospital(int idhospital)
        {
            List<Doctor> doctores = this.repo.GetDoctoresHospital(idhospital);
            return View(doctores);
        }
    }
}
