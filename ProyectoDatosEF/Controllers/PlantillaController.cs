using Microsoft.AspNetCore.Mvc;
using ProyectoDatosEF.Models;
using ProyectoDatosEF.Repositories;

namespace ProyectoDatosEF.Controllers
{
    public class PlantillaController : Controller
    {
        private RepositoryPlantilla repo;
        public PlantillaController(RepositoryPlantilla repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Plantilla> plant = this.repo.GetPlantilla();
            return View(plant);
        }
        public IActionResult PlantillaHospital(int idhospital)
        {
            List<Plantilla> plant = this.repo.FindPlantillaHospital(idhospital);
            return View(plant);
        }
        public IActionResult Details(int id)
        {
            Plantilla empleado = this.repo.FindEmpleado(id);
            return View(empleado);
        }
 
        public IActionResult PlantillaFuncion ()
        {
            List<Plantilla> plant = this.repo.GetPlantilla();
            List<string> funciones = this.repo.GetFunciones();
            ViewData["FUNCIONES"] = funciones;
            return View(plant);
        }
        [HttpPost]
        public IActionResult PlantillaFuncion(string funcion)
        {
            List<Plantilla> plant = this.repo.GetPlantillaByFuncion(funcion);
            List<string> funciones = this.repo.GetFunciones();
            ViewData["FUNCIONES"] = funciones;
            return View (plant);
        }
    }
}
