using Layout.Models;

namespace Layout.Data
{
    public interface IDataRepository
    {
        Task<IEnumerable<Train>> TrainList();
        Task<ResponseSms> AddTrains(string trainName);
        Task UpdateTrainStatus(string trainId);
        Task<IEnumerable<Station>> StationList();
        Task<ResponseSms> AddStations(string stationName);
        Task UpdateStationStatus(string stationId);
        Task<IEnumerable<Train>> RouteTrainList();
        Task AddRoute(string trainId, string routeList);
        Task<IEnumerable<Trainclass>> Classlist();
        Task AddTrainClass(string className);
        Task UpdateClassStatus(string classID);

        Task AddTrainBogie(string bogieName,string trainID);
        Task<IEnumerable<TrainBogie>> BogieList();
        Task UpdateBogieStatus(string bogieID);

        Task AddBogieSeat(string bogieID, string seatName);
        Task<IEnumerable<BogieSeat>> SeatList();
        Task UpdateSeatStatus(string seatID);


    }
}
