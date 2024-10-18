using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers
{
    public class SellerssController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
