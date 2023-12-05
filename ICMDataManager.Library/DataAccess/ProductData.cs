using ICMDataManager.Library.Internal.DataAccess;
using ICMDataManager.Library.Internal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMDataManager.Library.DataAccess
{
    public class ProductData
    {
        //model from userdata to keep with the restful principles
        // all controllers
        public List<ProductModel> GetProducts()
        {
            SqlDataAccess sql = new SqlDataAccess();

            var output = sql.LoadData<ProductModel, dynamic>("dbo.spProduct_GetAll", new { }, "ICMData");

            return output;
            //Also add unit testing if applicable

        }
    }
}
