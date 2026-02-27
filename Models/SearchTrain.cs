using Layout.Models;

namespace TrainBooking.Models
{
    public class SearchTrain
    {
        public string? from_station { get; set; }
        public string? to_station { get; set; }
        public DateTime? findDate { get; set; }
    }

    public class TrainDetailsDto
    {
    
        public string? id { get; set; }
        public string? trainId { get; set; }
        public decimal price { get; set; }
        public string? trainName { get; set; }
        
        public string? from_stationId { get; set; }
        public string? from_station { get; set; }
       
        public string? to_stationId { get; set; }
        public string? to_station { get; set; }

        public string? bogieID { get; set; }
        public string? bogieName { get; set; }
        public string? seatID { get; set; }
        public string? seatName { get; set; }



        public string? ClassID { get; set; }
        public string? ClassName { get; set; }
       
    }

    public class SearchTrainDetails
    {
        public List<TrainDetailsDto> TrainDetails { get; set; }
        public List<TrainDetailsDto> TrainBogie { get; set; }
        public List<TrainDetailsDto> TrainBogieSeat { get; set; }

    }
    public class TrainClassGroup
    {
        public string TrainName { get; set; }
        public string? from_station { get; set; }
        public string? to_station { get; set; }
        public List<string> Id { get; set; }
        public List<string> ClassName { get; set; }
        public List<decimal> Price { get; set; }
    }

    public class BogieGroup
    {
        public string TrainName { get; set; }
        public List<string> BogieId { get; set; }
        public List<string> BogieName { get; set; }
        public List<string> ClassId { get; set; }
    }

    public class SeatGroup
    {
        public string BogieID { get; set; }
        public List<string> SeatID { get; set; }
        public List<string> SeatName { get; set; }
        public List<string> BogieName { get; set; }
        public List<string> TrainName { get; set; }
        public List<string> ClassId { get; set; }
    }

    public class SearchTrainViewModel
    {
        public List<TrainClassGroup> TrainDetails { get; set; }
        public List<BogieGroup> TrainBogie { get; set; }
        public List<SeatGroup> TrainBogieSeat { get; set; }
       
    }

}
