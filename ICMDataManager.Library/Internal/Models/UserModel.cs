using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMDataManager.Library.Internal.Models
{
    public class UserModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddresse { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
