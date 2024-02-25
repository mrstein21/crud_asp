using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class PlacesController : Controller
    {
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpGet]
        public IActionResult List()
        {
            return View();
        }
        [HttpGet]        
        public IActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet]
        public IActionResult Map()
        {
            return View();
        }
    }
}
