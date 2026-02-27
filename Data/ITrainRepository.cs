using TrainBooking.Models;

namespace TrainBooking.Data
{
    public interface ITrainRepository
    {
        Task <SearchTrainDetails> SearchTrain(SearchTrain searchTrain);
    }
}
