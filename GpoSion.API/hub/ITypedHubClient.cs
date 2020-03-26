using System.Threading.Tasks;

namespace GpoSion.API.hub
{
    public interface ITypedHubClient
    {
        Task BroadcastMessage(string type, string payload);
    }
}