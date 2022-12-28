using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces
{
    public interface IDistributeGRPCServiceCache
    {
        Task<string> GetAccessToken();
    }
}
