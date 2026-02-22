using Layout.Data;
using Layout.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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
           var result= await _DataRepository.AddTrains(trainName);

            if(!string.IsNullOrEmpty(result.MsgSuccess))
            {
                TempData["MsgSuccess"] = result.MsgSuccess;
            }
            else
            {
                TempData["MsgFail"] = result.MsgFail;
            }

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
           
            var result= await _DataRepository.AddStations(stationName);
            if (!string.IsNullOrEmpty(result.MsgSuccess))
            {
                TempData["MsgSuccess"] = result.MsgSuccess;
            }
            else
            {
                TempData["MsgFail"] = result.MsgFail;

            }




                
            
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
        public async Task<IActionResult> BogieForSeat()
        {
            var TrainBogie = await _DataRepository.BogieList();
            return Json(new {success=true, data = TrainBogie });

        }
        public async Task<IActionResult> AddTrainBogie(string bogieName,string trainID)
        {
            await _DataRepository.AddTrainBogie(bogieName, trainID);
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

        public async Task<IActionResult> AddBogieSeat( string bogieID, string seatName)
        {
            await _DataRepository.AddBogieSeat(bogieID, seatName);
            return RedirectToAction("BogieSeat");
        }

        
        public async Task<IActionResult> UpdateSeatStatus(string seatID)
        {
            await _DataRepository.UpdateSeatStatus(seatID);
            return Json(new { success = true });
        }

        #endregion

        public async Task<IActionResult> TrainAnimation()
        {
            return View();
        }

        public async Task<IActionResult> TrainOffDay()
        {
            var trains = await _DataRepository.TrainOffDay();
            return View(trains);
        }

        [HttpPost]
        public async Task<IActionResult> AddTrainOffDay(string trainId,string offDay)
        {
            await _DataRepository.AddTrainOffDay(trainId, offDay);
            return RedirectToAction("TrainOffDay");
        }

        public async Task<IActionResult> TrainDetails()
        {
            
            var trainList = await _DataRepository.RouteTrainList();
            var stations = await _DataRepository.StationList();
            var trainDetails = await _DataRepository.DetailsForTrain();
            var classList = await _DataRepository.Classlist();

            var model = new TrainAllDetails
            {
                TrainList = trainList,
                StationList = stations,
                TrainDetailsList = trainDetails,
                ClassList = classList
            };

            return View(model);

            
        }


        public async Task<IActionResult> AddTrainDetails(TrainDetails trainDetails)
        {
            await _DataRepository.AddTrainDetails(trainDetails);
            return RedirectToAction("TrainDetails");
        }

    }
}
