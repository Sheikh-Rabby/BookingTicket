using Layout.Data;
using Microsoft.AspNetCore.Mvc;

namespace Layout.Controllers
{
    public class TrainSetupController : Controller
    {
        private readonly IDataRepository _DataRepository;

        public TrainSetupController(IDataRepository DataRepository)
        {
            _DataRepository = DataRepository;
        }

        public async Task<IActionResult> AddTrain()
        {
            var trains = await _DataRepository.TrainList();
            return View(trains);
        }
    }
}
