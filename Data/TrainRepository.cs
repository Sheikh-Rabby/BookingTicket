using Dapper;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using TrainBooking.Models;

namespace TrainBooking.Data
{
    public class TrainRepository:ITrainRepository
    {
        private readonly string _connectionString;

        public TrainRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }
        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }


        [HttpPost]
        public async Task<SearchTrainDetails> SearchTrain(SearchTrain searchTrain)
        {
            using var connection = CreateConnection();
            var trains = await connection.QueryMultipleAsync(

                "dbo.SearchTrain",
                new
                {   from_station =  searchTrain.from_station,
                    to_station   =  searchTrain.to_station,
                    findDate     =  searchTrain.findDate
                },
                commandType: CommandType.StoredProcedure

                );



            var trainDetails = (await trains.ReadAsync<TrainDetailsDto>()).ToList();
            var trainBogie = (await trains.ReadAsync<TrainDetailsDto>()).ToList();
            var trainBogieSeat = (await trains.ReadAsync<TrainDetailsDto>()).ToList();

            var result = new SearchTrainDetails
            {
                TrainDetails = trainDetails,
                TrainBogie = trainBogie,
                TrainBogieSeat = trainBogieSeat
            };

            return result;

        }
    }
}
