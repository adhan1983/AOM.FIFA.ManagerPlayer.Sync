using System;
using gRPCLeagueClient;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Services
{
    public class SyncJobLeagueService : ISyncJobLeagueService
    {
        private readonly ILeaguegRPCServiceClient _leaguegRPCServiceClient;
        private readonly IHttpClientFactoryService _httpClientServiceImplementation;
        public SyncJobLeagueService(IHttpClientFactoryService httpClientServiceImplementation, ILeaguegRPCServiceClient leaguegRPCServiceClient)
        {
            this._httpClientServiceImplementation = httpClientServiceImplementation;
            this._leaguegRPCServiceClient = leaguegRPCServiceClient;
        }
        public async Task<SyncPageData> SyncJobLeaguesAsync(int totalItemsPerPage, SyncPageData syncPageData)
        {
            var response = await _httpClientServiceImplementation.
                                    GetLeaguesAsync(new Request { Page = syncPageData.Page, MaxItemPerPage = totalItemsPerPage });

            foreach (var item in response.items)
            {
                try
                {
                    var leagueRequest = new LeagueRequest { Name = item.name, SourceId =  item.id };
                    
                    var leagueReply = await _leaguegRPCServiceClient.InsertLeagueAsync(leagueRequest);
                    
                    if (leagueReply.Id > 0)
                        syncPageData.TotalSynchronized++;
                }
                catch (Exception ex)
                {
                    syncPageData.TotalDosNotSynchronized++;

                    var sourceWithoutSync = new SourceWithoutSyncData
                    {
                        SourceId = item.id,
                        SyncPageId = syncPageData.Id
                    };

                    syncPageData.SourcesWithoutSync.Add(sourceWithoutSync);

                    throw;
                }

            }           

            return syncPageData;
        }
    }
}
