using ICMWPFUserInterface.Library.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ICMWPFUserInterface.Library.Api
{
    public interface IProductEndpoint
    {
        Task<List<ProductModel>> GetAll();
    }
}