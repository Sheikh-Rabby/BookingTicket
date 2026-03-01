using TrainBooking.Models;

namespace TrainBooking.Data
{
    public interface ITrainRepository
    {
        Task <SearchTrainResult> SearchTrain(SearchTrain searchTrain);
        //Task<IEnumerable<TrainDetailDto>> TrainSeatByBogie(SearchTrain searchTrain);
    }
}
