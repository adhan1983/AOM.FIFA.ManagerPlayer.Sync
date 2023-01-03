using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.FIFAManagerRequest;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Clubs;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Services
{
    public class SyncJobClubService : ISyncJobClubService
    {
        private readonly IClubgRPCServiceClient _clubRPCServiceClient;
        private readonly IHttpClientFactoryService _httpClientServiceImplementation;
        public SyncJobClubService(IHttpClientFactoryService httpClientServiceImplementation, IClubgRPCServiceClient clubRPCServiceClient)
        {
            this._httpClientServiceImplementation = httpClientServiceImplementation;
            this._clubRPCServiceClient = clubRPCServiceClient;
        }

        public async Task<Pagination> GetPaginationClubAsync(int totalItemsPerPage)
        {
            var response = await _httpClientServiceImplementation.GetClubsAsync(new Request { MaxItemPerPage = totalItemsPerPage, Page = 1 });

            return response.pagination;
        }
        public async Task<SyncPageData> SyncJobClubsAsync(int totalItemsPerPage, SyncPageData syncPageData)
        {
            
            var response = await _httpClientServiceImplementation.
                                    GetClubsAsync(new Request { Page = syncPageData.Page, MaxItemPerPage = totalItemsPerPage });

            RemoveSourceWillNotBeSync(response, syncPageData);

            foreach (var item in response.items)
            {
                try
                {
                    var clubRequest = new FIFAManagerClubRequest { Name = item.name, SourceId =  item.id, SourceLeagueId = item.league.Value };
                    
                    var clubReply = await _httpClientServiceImplementation.SendToFifaManagerClubAsync(clubRequest);
                    
                    if (clubReply.id > 0)
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
                }

            }           

            return syncPageData;
        }

        private ClubListResponse RemoveSourceWillNotBeSync(ClubListResponse response, SyncPageData syncPageData)
        {
            var itemsNeedToBeRemoved = response.items.Where(x => x.league == null).ToList();

            foreach (var item in itemsNeedToBeRemoved)
            {
                var sourceWithoutSync = new SourceWithoutSyncData
                {
                    SourceId = item.id,
                    SyncPageId = syncPageData.Id
                };

                syncPageData.SourcesWithoutSync.Add(sourceWithoutSync);

                syncPageData.TotalDosNotSynchronized++;
            }

            response.items.RemoveAll(x => itemsNeedToBeRemoved.Contains(x));

            return response;
        }
    }
}
