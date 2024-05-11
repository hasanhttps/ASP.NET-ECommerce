using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_ECommerce.MVC.ViewComponents;

public class AdminDashboardNeworderViewComponent:ViewComponent {
    public IViewComponentResult Invoke() {
        return View();
    }
}
