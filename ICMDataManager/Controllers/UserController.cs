using ICMDataManager.Library.DataAccess;
using ICMDataManager.Library.Internal.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace ICMDataManager.Controllers
{
    [System.Web.Http.Authorize]
    [System.Web.Http.RoutePrefix("api/User")]
    public class UserController : ApiController
    {
        //no Id in the method , it has to come from the logged in user
        public List<UserModel> GetById()
        {
            string userId = RequestContext.Principal.Identity.GetUserId();
            UserData data = new UserData();

            return data.GetUserById(userId);
        }        
        
    }
}
