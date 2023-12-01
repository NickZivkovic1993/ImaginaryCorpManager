using ICMWPFUserInterface.Models;
using System.Threading.Tasks;

namespace ICMWPFUserInterface.Helpers
{
    public interface IAPIHelper
    {
        Task<AuthenticatedUser> Authenticate(string username, string password);
    }
}