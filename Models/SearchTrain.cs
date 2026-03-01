using Layout.Models;

namespace TrainBooking.Models
{
    public class SearchTrain
    {
        public string? from_station { get; set; }
        public string? to_station { get; set; }
        public DateTime? findDate { get; set; }
        public string? trainName { get; set; }
    }

    public class TrainDetailDto
    {
                public string id { get; set; }
                public string trainId { get; set; }
                public decimal price { get; set; }
                public string trainName { get; set; }
                public string from_station { get; set; }
                public string to_station { get; set; }
                public string classID { get; set; }
                public string className { get; set; }
    }

    public class BogieDto
    {
        public string bogieID { get; set; }
        public string trainId { get; set; }
        public string bogieName { get; set; }
        public string trainName { get; set; }
        public string classID { get; set; }
        public string className { get; set; }
        public string from_station { get; set; }
        public string to_station { get; set; }
    }


    public class SeatDto
    {
        public string seatID { get; set; }
        public string bogieID { get; set; }
        public string seatName { get; set; }
        public string trainId { get; set; }
        public string bogieName { get; set; }
        public string trainName { get; set; }
        public string from_station { get; set; }
        public string to_station { get; set; }
    }


    public class SearchTrainResult
    {
        public List<TrainDetailDto> Trains { get; set; } = new();
        public List<BogieDto> Bogies { get; set; } = new();
        public List<SeatDto> Seats { get; set; } = new();
    }


    public class TrainViewModel
    {
        public string trainId { get; set; }
        public string trainName { get; set; }
        public string from_station { get; set; }
        public string to_station { get; set; }
        public List<TrainClassViewModel> Classes { get; set; } = new();
        public List<BogieViewModel> Bogies { get; set; } = new();
    }

    public class TrainClassViewModel
    {
        public string classID { get; set; }
        public string className { get; set; }
        public decimal price { get; set; }
    }

    public class BogieViewModel
    {
        public string bogieID { get; set; }
        public string bogieName { get; set; }
        public string classID { get; set; }
        public string className { get; set; }
        public List<SeatViewModel> Seats { get; set; } = new();
    }

    public class SeatViewModel
    {
        public string seatID { get; set; }
        public string seatName { get; set; }
        public bool IsBooked { get; set; }
    }

    public class SearchTrainViewModel
    {
        public List<TrainViewModel> Trains { get; set; } = new();
    }


}
