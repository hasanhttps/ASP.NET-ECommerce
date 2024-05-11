using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_ECommerce.Controllers;

public class AdminController : Controller {
    public IActionResult Dashboard() {
        return View();
    }
}
