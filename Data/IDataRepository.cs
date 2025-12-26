using Layout.Models;

namespace Layout.Data
{
    public interface IDataRepository
    {
        Task<List<Train>> TrainList();
        Task AddTrains(string trainName);
        Task IsActive(string trainId);
        Task<List<Station>> StationList();
        Task AddStations(string stationName);
        Task StationIsActive(string stationId);
        Task<List<Train>> RouteTrainList();
        Task AddRoute(string trainId, string routeList);


    }
}
