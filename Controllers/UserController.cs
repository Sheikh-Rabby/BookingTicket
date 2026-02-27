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


        [HttpPost]
        public async Task<IActionResult> SearchTrain(SearchTrain searchTrain)
        {
            var trains = await _trainRepository.SearchTrain(searchTrain);
            var route=trains.TrainDetails.Select(t =>new TrainClassGroup 
            { 
                from_station= t.from_station,
                to_station= t.to_station 
            }).FirstOrDefault();

            var classGroup = trains.TrainDetails.GroupBy(t => t.trainName).Select(g => new TrainClassGroup
            {
                TrainName = g.Key,
                Id=g.Select(t=>t.id).ToList(),
                ClassName = g.Select(t => t.ClassName).ToList(),
                Price = g.Select(t => t.price).ToList(),
                from_station=g.First().from_station,
                to_station=g.First().to_station


            }).ToList();
           

            var bogiegroup = trains.TrainBogie.GroupBy(tb => tb.trainName).Select(g => new BogieGroup
            {
                TrainName=g.Key,
                BogieId=g.Select(tb=>tb.bogieID).ToList(),
                BogieName=g.Select(tb=>tb.bogieName).ToList(),
                ClassId = g.Select(tb => tb.ClassID).ToList()
            }).ToList();
            var TrainBogieSeat = trains.TrainBogieSeat.GroupBy(ts => ts.bogieID).Select(g => new SeatGroup
            {
                BogieID = g.Key,
                SeatID = g.Select(ts => ts.seatID).ToList(),
                SeatName = g.Select(ts => ts.seatName).ToList(),
                BogieName=g.Select(ts=>ts.bogieName).ToList(),
                ClassId = g.Select(ts => ts.ClassID).ToList()

            }).ToList();

            var model = new SearchTrainViewModel
            {
                TrainDetails = classGroup,
                TrainBogie = bogiegroup,
                TrainBogieSeat = TrainBogieSeat,
                //TrainDetails =route
            };


            return View("SearchTrainDetails", model);
        }
    }
}
