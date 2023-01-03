using System;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.FIFAManagerRequest;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;

namespace AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Services
{
    public class SyncJobNationService : ISyncJobNationService
    {
        private readonly IHttpClientFactoryService _httpClientServiceImplementation;
        
        private readonly INationgRPCServiceClient _nationRPCServiceClient;

        public SyncJobNationService(IHttpClientFactoryService httpClientServiceImplementation, INationgRPCServiceClient nationRPCServiceClient)
        {
            this._httpClientServiceImplementation = httpClientServiceImplementation;
            this._nationRPCServiceClient = nationRPCServiceClient;
        }

        public async Task<Pagination> GetPaginationNationAsync(int totalItemsPerPage)
        {
            var response = await _httpClientServiceImplementation.GetNationsAsync(new Request { MaxItemPerPage = totalItemsPerPage, Page = 1 });

            return response.pagination;
        }

        public async Task<SyncPageData> SyncJobNationAsync(int totalItemsPerPage, SyncPageData syncPageData)
        {

            var response = await _httpClientServiceImplementation.
                                    GetNationsAsync(new Request { Page = syncPageData.Page, MaxItemPerPage = totalItemsPerPage });

            foreach (var item in response.items)
            {
                try
                {
                    var nationRequest = new FIFAManagerNationRequest { Name = item.name, SourceId =  item.id };
                    
                    var nationResponse = await _httpClientServiceImplementation.SendToFifaManagerNationAsync(nationRequest);
                    
                    if (nationResponse.id > 0)
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
    }
}
