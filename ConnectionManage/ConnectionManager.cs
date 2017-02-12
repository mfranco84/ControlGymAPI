using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace ConnectionManage
{
    public class ConnectionManager
    {
        private readonly string _connectionString;

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        public ConnectionManager(string connectionString)
        {
            try
            {
                this._connectionString = connectionString;
            }
            catch (Exception exception)
            {
                //Log4Net.WriteLog(exception, Log4Net.LogType.Error);
            }
        }

        public SqlConnection CreateConnection()
        {
            SqlConnection connection = null;
            try
            {
                connection = new SqlConnection(this._connectionString);
            }
            catch (Exception exception)
            {
                //Log4Net.WriteLog(exception, Log4Net.LogType.Error);
            }
            return connection;
        }

        public SqlCommand CreateCommand(SqlConnection cnn)
        {
            SqlCommand sqlcommand = null;
            try
            {
                sqlcommand = new SqlCommand(this._connectionString, cnn);
            }
            catch (Exception exception)
            {
                //Log4Net.WriteLog(exception, Log4Net.LogType.Error);
            }
            return sqlcommand;
        }
    }
}
