using ICMDataManager.Library.Internal.DataAccess;
using ICMDataManager.Library.Internal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMDataManager.Library.DataAccess
{
    public class UserData
    {
        public List<UserModel> GetUserById(string Id)
        {
            SqlDataAccess sql = new SqlDataAccess();

            //Dont forget to change the hardcoding of DefaultConnection

            //specified T generic by UserModel , in U generic entered dynamic
            //dynamic -- Dapper function to allow you to use version of annonymous class with a fixed type

            // pass in a new object ID from input and put it into Id prop
            var p = new { Id = Id }; // pass it into LoadData  -- Has to be in the same assebly

            var output = sql.LoadData<UserModel, dynamic>("dbo.spUserLookup", p, "ICMData");

            return output;
            //Also add unit testing
        }
    }
}
