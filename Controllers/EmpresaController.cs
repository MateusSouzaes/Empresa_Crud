using Microsoft.AspNetCore.Mvc;
using CRUD_Empresa.

namespace CRUD_Empresa.Controllers
{
    public class EmpresaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
