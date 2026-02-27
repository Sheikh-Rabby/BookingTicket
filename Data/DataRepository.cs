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

        //Generic method for executing stored procedures

        private async Task<IEnumerable<T>> QueryAsync<T>(string sql,object?param=null,CommandType commandType = CommandType.StoredProcedure)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<T>(sql, param, commandType: commandType);
        }

        private async Task<T>QueryFirstOrDefaultAsync<T>(string sql,object?param=null,CommandType commandType = CommandType.StoredProcedure)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, commandType: commandType);
        }







        #region train

        //public async Task<IEnumerable<Train>> TrainList()
        //{
        //    using var connection = CreateConnection();
        //    var trains = await connection.QueryAsync<Train>(
        //        "dbo.trainList",

        //         commandType: CommandType.StoredProcedure
        //            );
        // return trains;

        //}

        public async Task<IEnumerable<Train>> TrainList()
        {
            return await QueryAsync<Train>("dbo.trainList");
        }

        //public async Task<ResponseSms> AddTrains(string trainName)
        //{
        //    using var connection = CreateConnection();
        //    var result = await connection.QueryFirstOrDefaultAsync<ResponseSms>(
        //        "dbo.AddTrain", new { trainName = trainName },
        //        commandType:CommandType.StoredProcedure
                
        //        );
        //    return result;

        //}

        public async Task<ResponseSms> AddTrains(string trainName)
        {
            return await QueryFirstOrDefaultAsync<ResponseSms>("dbo.AddTrain", new { trainName = trainName });
        }
     
        public async Task UpdateTrainStatus(string trainId)
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

        public async Task<ResponseSms> AddStations(string stationName)
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryFirstOrDefaultAsync<ResponseSms>(

                "dbo.AddStation", new { stationName = stationName },
                commandType: CommandType.StoredProcedure
                );
            return stations;
            
        }
        public async Task UpdateStationStatus(string stationId)
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

        public async Task UpdateClassStatus(string classID)
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

        public async Task<IEnumerable<TrainBogie>> BogieListBYId(string trainId)
        {
            using var connection = CreateConnection();
            var Trainclass = await connection.QueryAsync<TrainBogie>(

                " select * from Train t left join trainbogie tb on t.trainID=tb.trainId where t.trainId=@trainId",
                  new { trainId = trainId }
                );
            return Trainclass;

        }



        public async Task AddTrainBogie(string bogieName,string trainID,string classID)
        {
            using var connection = CreateConnection();
            var trainBogie = await connection.QueryAsync(

                "dbo.AddTrainBogie", new { bogieName = bogieName, classID=classID,trainID= trainID },
                commandType: CommandType.StoredProcedure
                );

        }

        public async Task UpdateBogieStatus(string bogieID)
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryAsync(

                "dbo.bogieStatusUpdate", new { bogieID = bogieID },
                commandType: CommandType.StoredProcedure
                );

        }



        #endregion


        #region Seat
        public async Task<IEnumerable<BogieSeat>> SeatList()
        {
            using var connection = CreateConnection();
            var BogieSeat = await connection.QueryAsync<BogieSeat>(

                "dbo.seatList",
                commandType: CommandType.StoredProcedure
                );
            return BogieSeat;
        }


        public async Task AddBogieSeat(string bogieID, string seatName)
        {
            using var connection = CreateConnection();
            var trainBogie = await connection.QueryAsync(

                "dbo.AddBogieSeat", new { bogieID = bogieID, seatName = seatName },
                commandType: CommandType.StoredProcedure
                );

        }

        public async Task UpdateSeatStatus(string seatID)
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryAsync(

                "dbo.seatStatusUpdate", new { seatID = seatID },
                commandType: CommandType.StoredProcedure
                );

        }


        #endregion

        #region TrainOffDay
        public async Task<IEnumerable<TrainOffDay>> TrainOffDay()
        {
            using var connection = CreateConnection();
            var trains = await connection.QueryAsync<TrainOffDay>(
                "select " +
                "tfd.offDayID," +
                "tfd.trainID," +
                "tfd.off_Day," +
                " tfd.isActive," +
                "t.trainName " +
                " from TrainOffDay tfd" +
                " inner join Train t on tfd.trainID=t.trainID"
                );
            return trains;

        }

        public async Task AddTrainOffDay(string trainId, string offDay)
        {
            using var connection = CreateConnection();
            var trainBogie = await connection.QueryAsync(

                "dbo.OffDayForTrain", new { trainId = trainId, offDay = offDay },
                commandType: CommandType.StoredProcedure
                );

        }

        public async Task UpdateTrainOffDayStatus(string offdayID)
        {
            using var connection = CreateConnection();
            var stations = await connection.QueryAsync(

                "update TrainOffDay set isActive = case when isActive=1 then 0 else 1 end  where offdayID=@offdayID", new { offdayID = offdayID }
               
                );

        }



        #endregion


        public async Task<IEnumerable<TrainDetails>> DetailsForTrain()
        {
            using var connection = CreateConnection();
            var trains = await connection.QueryAsync<TrainDetails>(
               "select td.id,td.trainId,td.price,t.trainName,s.stationName as from_station,st.stationName as To_station from Train_Details td " +
               "\r\nleft join Train t on td.trainId=t.trainID" +
               " \r\nleft join station s on td.from_station=s.stationID" +
               " \r\njoin station st on td.to_station=st.stationID"
                );
            return trains;
        }


        public async Task AddTrainDetails(TrainDetails trainDetails)
        {
            using var connection = CreateConnection();
            await connection.QueryAsync(
              "[dbo].[AddTrainDetails]", 
              new 
              {   trainName = trainDetails.trainName, 
                  classId=trainDetails.classId,
                  from_station = trainDetails.from_station,
                  to_Station = trainDetails.to_station,
                  price = trainDetails.price
              });
        }




    }
}
