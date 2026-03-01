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

        //public async Task<IActionResult> TrainSeatByBogie(SearchTrain searchTrain)
        //{
        //    var train = await _trainRepository.TrainSeatByBogie(searchTrain);
        //    return Json(train);
        //}


        [HttpPost]
        public async Task<IActionResult> SearchTrain(SearchTrain searchTrain)
        {
            
            var result = await _trainRepository.SearchTrain(searchTrain);
            var allTrains = result.Trains.ToList();
            var allBogies = result.Bogies.ToList();
            var allSeats = result.Seats.ToList();
            foreach (var seat in allSeats)
            {
                Console.WriteLine($"seat.bogieID: '{seat.bogieID}'");
            }

            // ✅ BogieID print koro
            foreach (var bogie in allBogies)
            {
                Console.WriteLine($"bogie.bogieID: '{bogie.bogieID}'");
            }

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
            var testBogie = viewModel.Trains.FirstOrDefault()?.Bogies.FirstOrDefault();
            Console.WriteLine($"BogieID: {testBogie?.bogieID} | Seats Count: {testBogie?.Seats.Count}");


            return View("SearchTrainDetails", viewModel);
        }

    }
}
