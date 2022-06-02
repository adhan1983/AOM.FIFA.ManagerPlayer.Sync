using gRPCClubClient;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces
{
    public interface IClubgRPCServiceClient
    {
        Task<ClubReply> InsertClubAsync(ClubRequest request);
    }
}
