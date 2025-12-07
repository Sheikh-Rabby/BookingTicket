using Microsoft.AspNetCore.Mvc;

namespace Layout.Controllers
{
    public class TrainSetupController : Controller
    {
        private readonly ILogger<TrainSetupController> _logger;

        public TrainSetupController(ILogger<TrainSetupController>logger)
        {
            _logger = logger;
        }

        public IActionResult AddTrain()
        {
            return View();
        }
    }
}
