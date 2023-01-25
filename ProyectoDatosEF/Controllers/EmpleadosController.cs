using Microsoft.AspNetCore.Mvc;
using ProyectoDatosEF.Models;
using ProyectoDatosEF.Repositories;

namespace ProyectoDatosEF.Controllers
{
    public class EmpleadosController : Controller
    {
        private RepositoryEmpleados repo;

        public EmpleadosController(RepositoryEmpleados repo)
        {
            this.repo = repo;
        }
        public IActionResult Index()
        {
            List<Empleados> emp = this.repo.GetEmpleados();
            List<string> lista = this.repo.GetFuncionesemp();
            ViewData["LISTA"] = lista;
            return View(emp);
        }
        [HttpPost]
        public IActionResult Index(string oficio, int incremento)
        {
            oficio = "DEVELOPER";
            this.repo.UpdateEmpleado(oficio, incremento);
            List<Empleados> emp = this.repo.GetEmpleados();
            List<string> lista = this.repo.GetFuncionesemp();
            ViewData["LISTA"] = lista;
            return View(emp);
        }
    }
}
