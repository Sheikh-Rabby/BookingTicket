using Dapper;
using Layout.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Layout.Data
{
    public class DataRepository : IDataRepository
    {
        private readonly string _connectionString;

        public DataRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection") ?? "";
        }
        private IDbConnection CreateConnection()
        {
            return new SqlConnection(_connectionString);
        }


        public async Task<List<Train>> TrainList()
        {
            using var connection = CreateConnection();
            var trains = await connection.QueryAsync<Train>(
                "dbo.trainList",

                 commandType: CommandType.StoredProcedure
                    );
         return trains.ToList();

        }
        
        public async Task AddTrains(string trainName)
        {
            using var connection = CreateConnection();
            var trains = await connection.QueryAsync(
                "dbo.AddTrain", new { trainName = trainName },
                commandType:CommandType.StoredProcedure
                
                );

        }
     
        public async Task IsActive(string trainId)
        {
            {
                using var connection = CreateConnection();
                var trains = await connection.QueryAsync(
                    "dbo.isActive", new { trainId = trainId },
                    commandType: CommandType.StoredProcedure

                    );

            }
        }

        public async Task<List<Station>> StationList()
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryAsync<Station>(

                "dbo.stationList",
                commandType: CommandType.StoredProcedure
                );
            return stations.ToList();
        }

        public async Task AddStations(string stationName)
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryAsync(

                "dbo.AddStation", new { stationName = stationName },
                commandType: CommandType.StoredProcedure
                );
            
        }
        public async Task StationIsActive(string stationId)
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryAsync(

                "dbo.stationIsActive", new { stationId = stationId },
                commandType: CommandType.StoredProcedure
                );

        }
        public async Task<List<Train>> RouteTrainList()
        {
            using var connection = CreateConnection();
            var trains = await connection.QueryAsync<Train>(
                "dbo.trainList",

                 commandType: CommandType.StoredProcedure
                    );
            return trains.ToList();

        }


    }
}
