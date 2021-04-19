using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RDC.Tests.PersonalFinances.DataAccess
{
    public static class DataAccessBase
    {
        private const string ConnString = "Server=GGPC;Database=DBRDCPERSONALFINANCE;Trusted_Connection=True";

        public static void ExecuteProc(string procName, IEnumerable<DynamicParameters> parameters)
        {
            using var connection = new SqlConnection(ConnString);
            connection.Execute(procName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }

        public static IEnumerable<T> GetProcResult<T>(string procName, DynamicParameters parameters)
        {
            using var connection = new SqlConnection(ConnString);
            return connection.Query<T>(procName, parameters, commandType: System.Data.CommandType.StoredProcedure);
        }
    }
}
