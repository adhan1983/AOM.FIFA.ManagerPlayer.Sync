using gRPCNationClient;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces
{
    public interface INationgRPCServiceClient
    {
        Task<NationReply> InsertNationAsync(NationRequest request);
    }
}
