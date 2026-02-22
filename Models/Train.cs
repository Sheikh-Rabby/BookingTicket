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
        public string? trainName { get; set; }

    }
    public class BogieSeat
    {
        public string? seatID { get; set; }
        public string? bogieName { get; set; }
        public string? seatName { get; set; }
        public bool? isActive { get; set; }

    }
    public class TrainOffDay
    {
       public string? offDayID { get; set; }
       public string? trainName { get; set; }
       public string? off_day { get; set; }
       public bool? isActive { get; set; }

    }
    public class TrainDetails
    {
        public string? ID { get; set; }
        private string? trainname;
        public string? trainName
        {
            get => trainname;
            set
            {
                if (string.IsNullOrEmpty(value))
                    throw new ArgumentException("train name cannot be emplty");
                trainname = value;
            }
            
        }
        public string? from_station { get; set; }
       public string? classId { get; set; }
        public string? to_station { get; set; }
        public decimal? price { get; set; }

    }

    public class TrainAllDetails
    {
        public IEnumerable<Train>? TrainList { get; set; }
        public IEnumerable<Station>? StationList { get; set; }
        public IEnumerable<TrainDetails>? TrainDetailsList { get; set; }
        public IEnumerable<Trainclass>? ClassList { get; set; }
    }

}
