using AOM.FIFA.ManagerPlayer.Sync.Application.gRPCClient.Services.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.Jobs.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Application.SourceWithoutSync.Data;
using AOM.FIFA.ManagerPlayer.Sync.Application.SyncPage.Data;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using gRPCNationClient;
using System;
using System.Threading.Tasks;

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

        public async Task<SyncPageData> SyncJobNationAsync(int totalItemsPerPage, SyncPageData syncPageData)
        {

            var response = await _httpClientServiceImplementation.
                                    GetNationsAsync(new Request { Page = syncPageData.Page, MaxItemPerPage = totalItemsPerPage });

            foreach (var item in response.items)
            {
                try
                {
                    var nationRequest = new NationRequest { Name = item.name, SourceId =  item.id };
                    
                    var nationReply = await _nationRPCServiceClient.InsertNationAsync(nationRequest);
                    
                    if (nationReply.Id > 0)
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
