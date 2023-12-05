using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMWPFUserInterface.Library.Models
{
    public class ProductModel
    {
        //separated models into both dlls in order to keep api and wpf project separate
        //also wpf doesn't have ability to access db
        //using api oauth2.0 to have it in wpf as well
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
    }
}
