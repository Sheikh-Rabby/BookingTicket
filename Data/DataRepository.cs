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

    }
}
