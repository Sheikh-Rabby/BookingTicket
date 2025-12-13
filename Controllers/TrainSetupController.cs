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

        [HttpPost]  
         public async Task<IActionResult> AddTrains(string trainName)
        {
            await _DataRepository.AddTrains(trainName);
            return RedirectToAction("AddTrain");
        }
        [HttpPost]
        public async Task<IActionResult> IsActive(string trainId)
        {
            await _DataRepository.IsActive(trainId);
            return Json(new { success = true });
        }

        [HttpGet]
        public async Task<IActionResult> AddStation()
        {
            var stations = await _DataRepository.StationList();
            return View(stations);
        }



    }
}
