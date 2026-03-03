using TrainBooking.Models;

namespace TrainBooking.Data
{
    public interface ITrainRepository
    {
        Task <SearchTrainResult> SearchTrain(SearchTrain searchTrain);
        Task<IEnumerable<SeatViewModel>> TrainSeatByBogie(string bogieId,string trainId);
        Task<IEnumerable<BogieViewModel>> TrainBogieByClass(string classId, string trainId);
    }
}
