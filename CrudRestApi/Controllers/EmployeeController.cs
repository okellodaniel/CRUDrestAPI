using Microsoft.AspNetCore.Mvc;

namespace CrudRestApi.Controllers
{
    public class EmployeeController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}