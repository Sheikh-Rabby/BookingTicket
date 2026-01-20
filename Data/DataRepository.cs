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

        #region train

        public async Task<IEnumerable<Train>> TrainList()
        {
            using var connection = CreateConnection();
            var trains = await connection.QueryAsync<Train>(
                "dbo.trainList",

                 commandType: CommandType.StoredProcedure
                    );
         return trains;

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
        #endregion

        #region station
        public async Task<IEnumerable<Station>> StationList()
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryAsync<Station>(

                "dbo.stationList",
                commandType: CommandType.StoredProcedure
                );
            return stations;
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
        #endregion

        #region route
        public async Task<IEnumerable<Train>> RouteTrainList()
        {
            using var connection = CreateConnection();
            var trains = await connection.QueryAsync<Train>(
                "dbo.trainList",

                 commandType: CommandType.StoredProcedure
                    );
            return trains;

        }

        public async Task AddRoute(string trainId,string routeList)
        {
            using var connection = CreateConnection();
            var routestation = await connection.QueryAsync(

                "dbo.[Trainroutedetails]", new { trainId = trainId , routeList = routeList },
                commandType: CommandType.StoredProcedure
                );

        }
        #endregion

        #region trainClass

        public async Task AddTrainClass(string className)
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryAsync(

                "dbo.AddClass", new { className = className },
                commandType: CommandType.StoredProcedure
                );

        }




        public async Task<IEnumerable<Trainclass>> Classlist()
        {
            using var connection = CreateConnection();
            var Trainclass = await connection.QueryAsync<Trainclass>(

                "dbo.Classlist",
                commandType: CommandType.StoredProcedure
                );
            return Trainclass;
        }

        public async Task ClassIsActive(string classID)
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryAsync(

                "dbo.classIsActive", new { classID = classID },
                commandType: CommandType.StoredProcedure
                );

        }

        #endregion


        #region trainBogie

        public async Task<IEnumerable<TrainBogie>> BogieList()
        {
            using var connection = CreateConnection();
            var Trainclass = await connection.QueryAsync<TrainBogie>(

                "dbo.bogieList",
                commandType: CommandType.StoredProcedure
                );
            return Trainclass;
        }

        #endregion


    }
}
