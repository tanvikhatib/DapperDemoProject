using Dapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace APIDemo.DataAccess.Interfaces
{
    /// <summary>
    /// Idapper interface has definitions of three generic methods
    /// </summary>
    public interface IDapper
    {
        List<T> RunProcedureForAll<T>(string storeprocedure, DynamicParameters parameters, string connectionString);
        T RunProcedureForSingle<T>(string storeprocedure, DynamicParameters parameters, string connectionString);
        int ItemExecutor(string storeprocedure, DynamicParameters parameters, string connectionString);
    }
}
