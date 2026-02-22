using Microsoft.AspNetCore.Mvc;

namespace Layout.Controllers
{
    public class UserController:Controller
    {
        public async Task<IActionResult> SearchTrain()
        {
            return View();
        }
    }
}
