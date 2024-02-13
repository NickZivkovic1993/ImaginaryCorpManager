using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICMWPFUserInterface.Library.Helpers
{
    public class ConfigHelper : IConfigHelper
    {
        public decimal GetTaxRate()
        {
            decimal output = 0;
            // Pull from App.Config taxRate 
            string rateText = ConfigurationManager.AppSettings["taxRate"];

            bool isValidTaxRate = Decimal.TryParse(rateText, out output);

            if (isValidTaxRate == false)
            {
                throw new ConfigurationErrorsException("Tax rate is not set up properly!");
            }
            return output;
        }
    }
}
