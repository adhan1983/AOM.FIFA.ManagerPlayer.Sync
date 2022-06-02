using System;
using System.Net.Http;
using System.Threading.Tasks;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Extensions;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Base;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Clubs;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Nation;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Player;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Utils.Interfaces;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.Responses.Leagues;
using AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient.Interfaces;


namespace AOM.FIFA.ManagerPlayer.Sync.Gateway.HttpFactoryClient
{
    public class HttpClientFactoryService : IHttpClientFactoryService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IFIFAGatewayConfig _fifaGatewayConfig;
        private readonly IFIFAUrl _url;
        private readonly IFIFAUrlQueryString _queryString;

        public HttpClientFactoryService(IHttpClientFactory httpClientFactory, IFIFAGatewayConfig fifaGatewayConfig, IFIFAUrl url, IFIFAUrlQueryString queryString)
        {
            this._httpClientFactory = httpClientFactory;
            this._fifaGatewayConfig = fifaGatewayConfig;
            this._url = url;
            this._queryString = queryString;
        }
        public async Task<LeagueListResponse> GetLeaguesAsync(Request request)
        {
            string urlLeague = string.Concat(_url.league, _queryString.Page);

            return await SendRequestAsync<LeagueListResponse>(request, urlLeague);
        }

        public async Task<ClubListResponse> GetClubsAsync(Request request)
        {
            string urlClub = string.Concat(_url.club, _queryString.Page);

            return await SendRequestAsync<ClubListResponse>(request, urlClub);
        }

        public async Task<PlayerListResponse> GetPlayersAsync(Request request)
        {
            string urlPlayer = string.Concat(_url.player, _queryString.Page);

            return await SendRequestAsync<PlayerListResponse>(request, urlPlayer);
        }

        public async Task<NationListResponse> GetNationsAsync(Request request)
        {
            string urlLeague = string.Concat(_url.nation, _queryString.Page);

            return await SendRequestAsync<NationListResponse>(request, urlLeague);
        }

        private async Task<TResponse> SendRequestAsync<TResponse>(Request request, string url) where TResponse : class
        {
            using (var httpClient = _httpClientFactory.CreateClient(_fifaGatewayConfig.FIFAClient))
            {
                string urlRequest = string.Concat(httpClient.BaseAddress, url, request.Page, _queryString.Limit, request.MaxItemPerPage);

                var requestMessage = new HttpRequestMessage
                {
                    Method = HttpMethod.Get,
                    RequestUri = new Uri(urlRequest),
                    Headers =
                    {
                        { _fifaGatewayConfig.FIFAApiKey , _fifaGatewayConfig.FIFAApiToken },
                    },
                };

                using (var response = await httpClient.SendAsync(requestMessage, HttpCompletionOption.ResponseHeadersRead))
                {
                    var responseMessage = response.EnsureSuccessStatusCode();

                    var result = await responseMessage.DeserializeResponseObj<TResponse>();

                    return result;
                }
            }

        }

    }
}
