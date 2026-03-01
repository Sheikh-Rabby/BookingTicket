using Dapper;
using Layout.Models;
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
        public async Task<SearchTrainResult> SearchTrain(SearchTrain searchTrain)
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

            var trainDetails = (await trains.ReadAsync<TrainDetailDto>()).ToList();
            var trainBogie = (await trains.ReadAsync<BogieDto>()).ToList();
            var trainBogieSeat = (await trains.ReadAsync<SeatDto>()).ToList();

            var result = new SearchTrainResult
            {
                Trains = trainDetails,
                Bogies = trainBogie,
                Seats = trainBogieSeat
            };

            return result;

        }
        //public async Task<IEnumerable<TrainDetailsDto>> TrainSeatByBogie(SearchTrain searchTrain)
        //{
        //    using var connection = CreateConnection();
        //    var trains = await connection.QueryAsync<TrainDetailsDto>(
        //        "dbo.TrainSeatByBogie", 
        //        new 
        //        {   @from_station=searchTrain.from_station,
        //            @to_station=searchTrain.to_station,
        //            @findDate=searchTrain.findDate,
        //            @trainName=searchTrain.trainName
        //        },
        //        commandType: CommandType.StoredProcedure
        //        );
        //    return trains;
        //}
    }
}
