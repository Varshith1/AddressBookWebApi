using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace AddressBookWebAPI.Repository.Dapper
{
    public class DapperContext
    {
        public string _connectionString { get; set; }

        private IDbConnection _connection;
        public DapperContext(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("Default");
            _connection = new SqlConnection(_connectionString);
        }
        public IDbConnection Connection
        {
            get
            {
                return _connection;
            }
        }
    }
}
