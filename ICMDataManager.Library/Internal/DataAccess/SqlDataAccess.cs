using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;

namespace ICMDataManager.Library.Internal.DataAccess
{
    //changed to internal class so it has to be used from inside a library
    //Check if functional , if not revert to public class
    //Otherwise keep internal to separate data even further

    internal class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public List<T> LoadData<T,U>(string storedProcedure,U parameters,string connectionStringName) 
        {
            string connectionString= GetConnectionString(connectionStringName);
            
            using(IDbConnection connection = new SqlConnection(connectionString)) 
            {
                //Take the connection string (connection)
                //Query<T> generic type model that i want each row to be 
                //pass storedProcedure by name , parameters type U (also generic)
                //and connectionStringName to get full connection string by using GetConnectionString method
                //and asign it storedProcedure type and return all rows

                List<T> rows = connection.Query<T>(storedProcedure, parameters, 
                    commandType: CommandType.StoredProcedure).ToList();

                return rows;
            }
        }

        //T U V W usual name for generics thats why T here is a generic
        public void SaveData<T>(string storedProcedure,T parameters,string connectionStringName)
        {
            string connectionString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //async?
                //-----> do it later
                connection.Execute(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
