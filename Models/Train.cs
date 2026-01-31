namespace Layout.Models
{
    public class Train
    {
        public string? trainId { get; set; }
        public string? trainName { get; set; }
        public bool? isActive { get; set; }
      
    }
    public class Station
    {
        public string? stationId { get; set; }
        public string? stationName { get; set; }
        public bool? isActive { get; set; }

    }
    public class Trainclass
    {
        public string? ClassId { get; set; }
        public string? ClassName { get; set; }
        public bool? isActive { get; set; }

    }

    public class TrainBogie
    {
        public string? bogieID { get; set; }
        public string? trainID { get; set; }
        public string? bogieName { get; set; }
        public bool? isActive { get; set; }

    }
    public class BogieSeat
    {
        public string? seatID { get; set; }
        public string? seatName { get; set; }
        public bool? isActive { get; set; }

    }



}
