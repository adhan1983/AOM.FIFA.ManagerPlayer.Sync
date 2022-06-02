using gRPCLeagueClient;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces
{
    public interface ILeaguegRPCServiceClient
    {
        Task<LeagueReply> InsertLeagueAsync(LeagueRequest request);
    }
}
