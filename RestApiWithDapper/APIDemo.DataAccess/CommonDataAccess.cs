
using APIDemo.DataAccess.Interfaces;
using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace APIDemo.DataAccess
{
    public class CommonDataAccess :IDapper
    {
        private readonly IConfiguration Config; //create object of Iconfiguration interface

        public CommonDataAccess(IConfiguration config)
        {
            Config = config; //set the Config object
        }

        /// <summary>
        /// This is a generic method used to get all records from the database, it takes three parameters storeprocedure name, dynamic parameters and name of connection string mentioned in the appsettings 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeprocedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public List<T> RunProcedureForAll<T>(string storeprocedure, DynamicParameters parameters, string connectionString)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(connectionString)))
            {
                return dbConnection.Query<T>(storeprocedure, parameters, commandType: CommandType.StoredProcedure).ToList(); //use query method in the IDbconnection of dapper to get all records
            }
        }

        /// <summary>
        /// This is a generic method used to insert or update records in the database, it takes three parameters storeprocedure name, dynamic parameters and name of connection string mentioned in the appsettings 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="storeprocedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public T RunProcedureForSingle<T>(string storeprocedure, DynamicParameters parameters, string connectionString)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(connectionString)))
            {
                return dbConnection.Query<T>(storeprocedure, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault(); //use query method in the IDbconnection of dapper to update or create record in the database
            }
        }

        /// <summary>
        /// This is a generic method used to delete the record from the database, it takes three parameters storeprocedure name, dynamic parameters and name of connection string mentioned in the appsettings 
        /// </summary>
        /// <param name="storeprocedure"></param>
        /// <param name="parameters"></param>
        /// <param name="connectionString"></param>
        /// <returns></returns>
        public int ItemExecutor(string storeprocedure, DynamicParameters parameters, string connectionString)
        {
            using (IDbConnection dbConnection = new SqlConnection(Config.GetConnectionString(connectionString)))
            {
                return dbConnection.Execute(storeprocedure, parameters, commandType: CommandType.StoredProcedure); //use Excute method in the IDbconnection of dapper to delete the record
            }
        }
    }
}
