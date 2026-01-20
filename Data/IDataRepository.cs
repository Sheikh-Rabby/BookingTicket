using Layout.Models;

namespace Layout.Data
{
    public interface IDataRepository
    {
        Task<IEnumerable<Train>> TrainList();
        Task AddTrains(string trainName);
        Task IsActive(string trainId);
        Task<IEnumerable<Station>> StationList();
        Task AddStations(string stationName);
        Task StationIsActive(string stationId);
        Task<IEnumerable<Train>> RouteTrainList();
        Task AddRoute(string trainId, string routeList);
        Task<IEnumerable<Trainclass>> Classlist();
        Task AddTrainClass(string className);
        Task ClassIsActive(string classID);
        Task<IEnumerable<TrainBogie>> BogieList();


    }
}
