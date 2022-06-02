using gRPCPlayerClient;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces
{
    public interface IPlayergRPCServiceClient
    {
        Task<PlayerReply> InsertPlayerAsync(PlayerRequest request);
    }
}
