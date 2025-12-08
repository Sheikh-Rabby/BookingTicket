using Layout.Models;

namespace Layout.Data
{
    public interface IDataRepository
    {
        Task<List<Train>> TrainList();
    }
}
