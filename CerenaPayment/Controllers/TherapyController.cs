using Microsoft.AspNetCore.Mvc;

namespace CerenaPayment.Controllers
{
    public class TherapyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
