using Microsoft.AspNetCore.Mvc;

namespace SimpleStoreWeb.Controllers
{
    public class AppController : Controller
    {
        public AppController() { }
        
        public IActionResult Index() => View();
    }
}
