using Microsoft.AspNetCore.Mvc;

namespace ClientApp.Controllers;

public class ValuesController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}