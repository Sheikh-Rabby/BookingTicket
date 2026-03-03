using Layout.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text.Json;
using TrainBooking.Data;
using TrainBooking.Models;

namespace Layout.Controllers
{
    public class UserController:Controller
    {

        private readonly ITrainRepository _trainRepository;

        public UserController(ITrainRepository trainRepository)
        {
            _trainRepository = trainRepository;
        }

        public async Task<IActionResult> SearchTrain()
        {
            return View();
        }

        public async Task<IActionResult> SearchTrainDetails()
        {
            return View();
        }

        public async Task<IActionResult> TrainSeatByBogie(string bogieId, string trainId)
        {
            var Seats = await _trainRepository.TrainSeatByBogie(bogieId, trainId);
            return Json(Seats);
        }
        public async Task<IActionResult> TrainBogieByClass(string classId, string trainId)
        {
            var bogies= await _trainRepository.TrainBogieByClass(classId, trainId);
            return Json(bogies);
        }




        [HttpPost]
        public async Task<IActionResult> SearchTrain(SearchTrain searchTrain)
        {
            
            var result = await _trainRepository.SearchTrain(searchTrain);
            TempData["ClassId"] = searchTrain.className;
            
            
            var viewModel = new SearchTrainViewModel
            {
                Trains = result.Trains
                    .GroupBy(t => t.trainId)
                    .Select(g => new TrainViewModel
                    {
                        trainId = g.Key,
                        trainName = g.First().trainName,
                        from_station = g.First().from_station,
                        to_station = g.First().to_station,


                        Classes = g.Select(x => new TrainClassViewModel
                        {
                            classID = x.classID,
                            className = x.className,
                            price = x.price
                        }).ToList(),


                        Bogies = result.Bogies
                            .Where(b => b.trainId == g.Key)
                            .GroupBy(b => b.bogieID)
                            .Select(bg => new BogieViewModel
                            {
                                bogieID = bg.Key,
                                bogieName = bg.First().bogieName,
                                classID = bg.First().classID,
                                className = bg.First().className,



                                Seats = result.Seats
                                    .Where(s => s.bogieID == bg.Key.Trim())
                                    .Select(s => new SeatViewModel
                                    {
                                       
                                        seatID = s.seatID,
                                        seatName = s.seatName
                                    }).ToList()
                                 
                            }).ToList()

                    }).ToList()
            };
            
            return View("SearchTrainDetails", viewModel);
        }

    }
}
