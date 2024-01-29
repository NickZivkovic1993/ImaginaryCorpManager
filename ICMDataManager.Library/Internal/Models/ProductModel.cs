using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMDataManager.Library.Internal.Models
{
//    SELECT [Id], [ProductName], [Description], 
//	[QuantityInStock] [IsTaxable]
    public class ProductModel
    {
        // triple comments 
        /// <summary>
        /// Unique identifier for a given product
        /// </summary>
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public decimal RetailPrice { get; set; }
        public int QuantityInStock { get; set; }
        public bool IsTaxable { get; set; }
    }
}
