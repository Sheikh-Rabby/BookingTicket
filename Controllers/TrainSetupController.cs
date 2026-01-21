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
        #region train
        //station start 
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
            await _DataRepository.UpdateTrainStatus(trainId);
            return Json(new { success = true });
        }
        //station end 
        #endregion train

        #region station
        [HttpGet]
        public async Task<IActionResult> AddStation()
        {
            var stations = await _DataRepository.StationList();
            return View(stations);
        }

        [HttpPost]
        public async Task<IActionResult> AddStations(string stationName)
        {
            await _DataRepository.AddStations(stationName);
            return RedirectToAction("AddStation");
        }

        [HttpPost]
        public async Task<IActionResult> StationIsActive(string stationId)
        {
            await _DataRepository.UpdateStationStatus(stationId);
            return Json(new { success = true });
        }
        #endregion station

        #region route
        public async Task<IActionResult>TrainRoute()
        {
            return View();
        }

        public async Task<IActionResult> RouteTrainList()
        {
            var trains = await _DataRepository.RouteTrainList();
            return Json(new { success=true, data = trains });
        }

        [HttpPost]
        public async Task<IActionResult> AddRoute(string trainId,string routeList)
        {
            await _DataRepository.AddRoute(trainId, routeList);
            return RedirectToAction("TrainRoute");
        }
        #endregion route

        #region Trainclass

        public async Task<IActionResult> TrainClass()
        {
            var trainclass = await _DataRepository.Classlist();
            return View(trainclass);
        }

        public async Task<IActionResult> AddTrainClass(string className)
        {
            await _DataRepository.AddTrainClass(className);
            return RedirectToAction("TrainClass");
        }

        [HttpPost]
        public async Task<IActionResult> ClassIsActive(string classID)
        {
            await _DataRepository.UpdateClassStatus(classID);
            return Json(new { success = true });
        }

        #endregion

        #region TrainBogie

        public async Task<IActionResult> TrainBogie()
        {
            var TrainBogie = await _DataRepository.BogieList();
            return View(TrainBogie);

        }
        public async Task<IActionResult> AddTrainBogie(string bogieName)
        {
            await _DataRepository.AddTrainBogie(bogieName);
            return RedirectToAction("TrainBogie");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBogieStatus(string bogieID)
        {
            await _DataRepository.UpdateBogieStatus(bogieID);
            return Json(new { success = true });
        }


        #endregion

        #region bogieSeat
        public async Task<IActionResult> BogieSeat()
        {

            var seatlist = await _DataRepository.SeatList();
            return View(seatlist);

        }

        public async Task<IActionResult> AddBogieSeat(string seatName)
        {
            await _DataRepository.AddBogieSeat(seatName);
            return RedirectToAction("BogieSeat");
        }

        
        public async Task<IActionResult> UpdateSeatStatus(string seatID)
        {
            await _DataRepository.UpdateSeatStatus(seatID);
            return Json(new { success = true });
        }

        #endregion

    }
}
